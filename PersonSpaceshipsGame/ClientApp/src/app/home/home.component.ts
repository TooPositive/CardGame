import { Component } from '@angular/core';
import { CardTypeDto } from '../Dtos/CardTypeDto'
import { CardGameService } from '../cardGame/cardGameService'
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})

@Injectable()
export class HomeComponent {
  //cardTypes: CardTypeDto[];// = [{ name: "Persons" }, { name: "Spaceships" }];
  selectedStartCardType: CardTypeDto;
  cardGameService: CardGameService;

  constructor(private http: HttpClient) {
    this.cardGameService = new CardGameService(http);
    console.log(`from component ${this.cardGameService.cardTypes}`);
  }

  startCardTypeChange() {
    console.log(`changed ${this.selectedStartCardType.name}`);
  }

  startGameClicked() {
    this.cardGameService.startGame();
  }

}
