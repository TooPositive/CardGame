import { of, Observable } from 'rxjs';
import { TestBed, ComponentFixture } from '@angular/core/testing';
import { ComponentFactory, Component, DebugElement, Type } from '@angular/core';
import { FixedSizeVirtualScrollStrategy } from '@angular/cdk/scrolling';
import { CardGameService } from '../cardGame/cardGameService';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { PersonCard } from '../models/cards/PersonCard';
import { Player } from '../models/players/Player';
import { SpaceshipCard } from '../models/cards/SpaceshipCard';
import { HomeComponent } from './home.component';
import { CardTypeDto } from '../Dtos/CardTypeDto';
import { CardType } from '../models/cards/CardType';
import { PlayableCard } from '../models/cards/PlayableCard';


//TODO: add UI tests
describe('CardGameService', () => {
  let service: CardGameService;
  let component: HomeComponent;
  let fixture: ComponentFixture<HomeComponent>;
  let de: DebugElement;
  let httpMock: HttpTestingController;

  beforeEach(async () => {
    TestBed.configureTestingModule({
      declarations: [HomeComponent],
      imports: [HttpClientTestingModule],
      providers: [CardGameService]
    })
      .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HomeComponent);
    component = fixture.componentInstance;
    service = TestBed.get(CardGameService);
    de = fixture.debugElement;
    httpMock = fixture.debugElement.injector.get<HttpTestingController>(HttpTestingController as Type<HttpTestingController>);
    let expectedResponse = [{ "name": "Persons" } as CardTypeDto, { "name": "Spaceships" } as CardTypeDto];
    service.cardTypes = expectedResponse;
  });

  afterEach(() => {
    httpMock.verify();
  });

  it('service be created', () => {
    expect(component).toBeTruthy();
  });

  it('assign player cards woks', async () => {
    let player1 = new Player('aaa', 0, []);
    let player2 = new Player('aaab', 0, []);


    const player1Cards = [
      new PersonCard('11', 'Card 1', player1, 15),
      new PersonCard('115', 'Card 2', player1, 10),
    ];
    let player2Cards = [
      new PersonCard('112', 'Card 3', player2, 10),
      new PersonCard('1125', 'Card 4', player2, 19),
    ];

    const peopleCardResponse = player1Cards.concat(player2Cards);

    service.assignCardsToPlayers(peopleCardResponse);

    expect(service.player1Cards).toEqual(player1Cards);
    expect(service.player2Cards).toEqual(player2Cards);
    expect(service.player1).toEqual(player1);
    expect(service.player2).toEqual(player2);
    expect(service.isPlaying).toBeTruthy();
  });

  it(`init game start game service state works`, () => {
    service.initGameServiceState();

    expect(service.selectedStartCardType).toBeNull();
    expect(service.firstPlayedCard).toBeNull();
    expect(service.secondPlayedCard).toBeNull();
    expect(service.isPlaying).toBeFalsy();
    expect(service.presentingRoundResult).toBeFalsy();
    expect(service.isGameEnded).toBeFalsy();
    expect(service.isPlayer1Move).toBeTruthy();
    expect(service.endRoundDecision).toEqual("");
    expect(service.player1Cards).toEqual([]);
    expect(service.player2Cards).toEqual([]);
  });

  it(`init game start works`, () => {
    service.initGameServiceState();

    expect(service.selectedStartCardType).toBeNull();
    expect(service.firstPlayedCard).toBeNull();
    expect(service.secondPlayedCard).toBeNull();
    expect(service.isPlaying).toBeFalsy();
    expect(service.presentingRoundResult).toBeFalsy();
    expect(service.isGameEnded).toBeFalsy();
    expect(service.isPlayer1Move).toBeTruthy();
    expect(service.endRoundDecision).toEqual("");
    expect(service.player1Cards).toEqual([]);
    expect(service.player2Cards).toEqual([]);
  });

  it(`start game click works`, async () => {
    let player1 = new Player('aaa', 0, []);
    let player2 = new Player('aaab', 0, []);


    const player1Cards = [
      new PersonCard('11', 'Card 1', player1, 15),
      new PersonCard('115', 'Card 2', player1, 10),
    ];
    let player2Cards = [
      new PersonCard('112', 'Card 3', player2, 10),
      new PersonCard('1125', 'Card 4', player2, 19),
    ];

    const peopleCardResponse = player1Cards.concat(player2Cards);

    service.selectedStartCardType = { "name": "Persons" } as CardTypeDto;
    spyOn(service, `getStartingGameCards`).and.returnValue(Promise.resolve<PlayableCard[]>(peopleCardResponse));
    await service.startGameClicked();

    // duplicated
    expect(service.player1Cards).toEqual(player1Cards);
    expect(service.player2Cards).toEqual(player2Cards);
    expect(service.player1).toEqual(player1);
    expect(service.player2).toEqual(player2);
    expect(service.isPlaying).toBeTruthy();
  });

});
