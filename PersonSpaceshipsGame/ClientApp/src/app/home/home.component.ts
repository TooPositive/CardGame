import { Component } from '@angular/core';
import { CardTypeDto } from '../Dtos/CardTypeDto'
import { CardGameService } from '../cardGame/cardGameService'
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { PlayableCard } from '../models/cards/PlayableCard';
import { Player } from '../models/players/Player';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})

@Injectable()
export class HomeComponent {
  selectedStartCardType: CardTypeDto;
  cardGameService: CardGameService;

  // cards 
  player1Cards: PlayableCard[] = [];
  player2Cards: PlayableCard[] = [];

  //TODO: Implement to allow more users
  firstPlayedCard: PlayableCard;  
  secondPlayedCard: PlayableCard;  

  //TODO: better user move tracking
  isPlayer1Move = true;
  presentingRoundResult = false;

  isPlaying = false;
  isGameEnded = false;

  constructor(private http: HttpClient) {
    this.cardGameService = new CardGameService(http);
  }

  startCardTypeChange() {
    console.log(`changed ${this.selectedStartCardType.name}`);
  }

  async startGameClicked() {
    let response = await this.cardGameService.getStartingGameCards(this.selectedStartCardType.name);
    if (response.length > 0) {
      //TODO: Better handling more users
      console.log(response);
      let playersCards = this.cardGameService.getGroupedPlayerCards(response);
      this.player1Cards = playersCards[0];
      this.player2Cards = playersCards[1];
      this.isPlaying = true;
    }
  }

  // TODO: move logic to api, create rounds, every move should be approve by api instead of just js
  receiveCardClickedMessage($event) {
    let cardObject = JSON.parse($event) as PlayableCard;
    this.cardPlayed(cardObject);
  }


  //TODO: create better logic for rounds
  cardPlayed(cardClicked: PlayableCard) {

    let card = this.getAllPlayingCards().filter(x => x.id == cardClicked.id && x.player.id == cardClicked.player.id)[0];
    //TODO: better error handling
    if (!card) {
      console.log(`error didn't find clicked card in players hand.`)
      return;
    }

    if (this.isPlayer1Move)
      this.firstPlayedCard = card;
    else
      this.secondPlayedCard = card;

    console.log(card.getName());

    this.removeCardFromHand(card);
    this.endMove();

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

  endMove() {
    //TODO: figure out better move logic
    if (this.isPlayer1Move && this.firstPlayedCard)
      this.isPlayer1Move = !this.isPlayer1Move;
    else if (!this.isPlayer1Move && this.secondPlayedCard)
      this.endRound();
    else
      console.log(`One of the players didn't place their card!`)
  }

  endRound() {
    this.presentingRoundResult = true;    
    this.isPlayer1Move = true;
    // api call to service with cards played
    // add points to player
  }
}
