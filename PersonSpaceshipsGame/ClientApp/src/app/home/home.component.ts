import { Component } from '@angular/core';
import { CardTypeDto } from '../Dtos/CardTypeDto'
import { CardGameService } from '../cardGame/cardGameService'
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { PlayableCard } from '../models/cards/PlayableCard';

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
  player1PlayedCard: PlayableCard;  
  player2PlayedCard: PlayableCard;  


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

  receiveMessage($event) {
    console.log($event);
  }

}
