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
  cardGameService: CardGameService;

  constructor(private http: HttpClient) {
    this.cardGameService = new CardGameService(http);
  }

  initCardsDropdown() {
    this.cardGameService.initCardTypes();
  }

  async startGameClicked() {
    await this.cardGameService.startGameClicked();
  }

  // TODO: move logic to api, create rounds, every move should be approve by api instead of just js
  receiveCardClickedMessage($event) {
    let cardObject = JSON.parse($event) as PlayableCard;
    this.cardGameService.cardPlayed(cardObject);
  }

}
