import { HttpClient, HttpHeaders } from '@angular/common/http';
import { CardTypeDto } from '../Dtos/CardTypeDto'
import { CardType, CardResponseResult } from '../models/cards/CardType';
import { PersonCard } from '../models/cards/PersonCard';
import { SpaceshipCard } from '../models/cards/SpaceshipCard';
import { PlayableCard } from '../models/cards/PlayableCard';
import { PersonCardDto } from '../Dtos/PersonCardDto';
import { Player } from '../models/players/Player';
import { Observable } from 'rxjs';
import { CardsPlayedResponseDto } from '../Dtos/CardsPlayedResponseDto';
import { Injectable } from '@angular/core';


@Injectable()
export class CardGameService {
  url: string = "https://localhost:44306/api";


  selectedStartCardType: CardTypeDto;
  cardTypes: CardTypeDto[];
  // cards 
  player1Cards: PlayableCard[] = [];
  player2Cards: PlayableCard[] = [];

  player1: Player;
  player2: Player;

  //TODO: Implement to allow more users
  firstPlayedCard: PlayableCard;
  secondPlayedCard: PlayableCard;

  //TODO: better user move tracking
  isPlayer1Move = true;
  presentingRoundResult = false;

  endRoundDecision: string;

  isPlaying = false;
  isGameEnded = false;

  constructor(private http: HttpClient) {
    
  }


  initCardTypes() {
    let cardTypes: CardTypeDto[];
    this.http.get(`${this.url}/Game/GetCardTypes`).subscribe((data: CardTypeDto[]) => { this.cardTypes = data; });
    this.cardTypes = cardTypes;
  }

  async getStartingGameCards(selectedCardType: string): Promise<any[]> {
    let data = await this.http.get(`${this.url}/Game/GetStartingGamesCards/${selectedCardType}`).toPromise();
    let dataToReturn = [];

    //TODO: think about open/close principle
    switch (selectedCardType.trim()) {
      case "Person":
        let personCardData = data as PersonCard[];
        personCardData.forEach(x => {
          dataToReturn.push(new PersonCard(x.id, x.name, x.player, x.mass));
        });
        return dataToReturn as PersonCard[];
      case "Spaceship":
        let spaceshipCardData = data as SpaceshipCard[];
        spaceshipCardData.forEach(x => {
          dataToReturn.push(new SpaceshipCard(x.id, x.name, x.player, x.crewCount));
        });
        return dataToReturn as SpaceshipCard[];
      default:
        console.log(`Wrong selected card type.`); // TODO: better error handling
        return [];
    }
  }

  getGroupedPlayerCards(cards: PlayableCard[]) {
    let players = cards.map(x => x.player.id).filter((value, index, array) => array.indexOf(value) === index);
    var dataToReturnGroupedByPlayer = [];
    for (var i = 0; i < players.length; i++) {
      dataToReturnGroupedByPlayer.push(cards.filter(x => x.player.id === players[i]));
    }
    return dataToReturnGroupedByPlayer;
  }

  async postRoundPlayedCards(cards: PlayableCard[]): Promise<CardsPlayedResponseDto> {
    let player: Player;
    var headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.post<CardsPlayedResponseDto>(`${this.url}/Game/PostRoundPlayedCards`, JSON.stringify(cards), { headers: headers }).toPromise();
  }

  async startGameClicked() {
    let response = await this.getStartingGameCards(this.selectedStartCardType.name);
    if (response.length > 0) {
      //TODO: Better handling more users + refactor assigining users
      this.assignCardsToPlayers(response);
    }
  }

  public assignCardsToPlayers(cardResponse: any[]) {
    let playersCards = this.getGroupedPlayerCards(cardResponse);
    this.player1Cards = playersCards[0];
    this.player1 = this.player1Cards[0].player;
    this.player2Cards = playersCards[1];
    this.player2 = this.player2Cards[0].player;
    this.isPlaying = true;
  }

  public initGameServiceState() {
    this.selectedStartCardType = null;
    this.isPlaying = false;
    this.endRoundDecision = "";
    this.isPlayer1Move = true;
    this.firstPlayedCard = null;
    this.secondPlayedCard = null;
    this.presentingRoundResult = false;
    this.isGameEnded = false;
    this.player1Cards = [];
    this.player2Cards = [];
  }

  //TODO: create better logic for rounds
  async cardPlayed(cardClicked: PlayableCard) {
    let card = this.getAllPlayingCards().filter(x => x.id === cardClicked.id && x.player.id === cardClicked.player.id)[0];
    //TODO: better error handling
    if (!card) {
      console.log(`error didn't find clicked card in players hand.`)
      return;
    }

    if (this.isPlayer1Move)
      this.firstPlayedCard = card;
    else
      this.secondPlayedCard = card;

    this.removeCardFromHand(card);
    await this.endMove();
  }

  getAllPlayingCards(): PlayableCard[] {
    return this.player1Cards.concat(this.player2Cards);
  }

  removeCardFromHand(card: PlayableCard) {
    if (this.isPlayer1Move)
      this.player1Cards = this.player1Cards.filter(x => x.id !== card.id);
    else
      this.player2Cards = this.player2Cards.filter(x => x.id !== card.id);
  }

  async endMove() {
    //TODO: figure out better move logic
    if (this.isPlayer1Move && this.firstPlayedCard) {
      this.isPlayer1Move = !this.isPlayer1Move;
      console.log(`end of player 1 move`);
    }
    else if (!this.isPlayer1Move && this.secondPlayedCard) {
      console.log(`end of player 2 move`);
      await this.endRound();
    }
    else
      console.log(`One of the players didn't place their card!`)
  }

  async endRound() {
    let roundCards: PlayableCard[] = [this.firstPlayedCard, this.secondPlayedCard];
    let roundResult = await this.postRoundPlayedCards(roundCards) as CardsPlayedResponseDto;
    this.addPointsToWinnerPlayer(roundResult);
    this.presentingRoundResult = true;
  }

  //TODO: refactor 
  addPointsToWinnerPlayer(roundResult: CardsPlayedResponseDto) {
    if (!roundResult.winner) {
      this.endRoundDecision = CardResponseResult[roundResult.result];
      return;
    }

    if (this.player1.id === roundResult.winner.id) {
      this.player1.points = roundResult.winner.points;
      this.endRoundDecision = `Player 1 Won`;
    }
    else if (this.player2.id === roundResult.winner.id) {
      this.player2.points = roundResult.winner.points;
      this.endRoundDecision = `Player 2 Won`;
    }
    else
      console.log(`Cannot add points to player. Didn't find player with id ${roundResult.winner.id}`);
  }
}
