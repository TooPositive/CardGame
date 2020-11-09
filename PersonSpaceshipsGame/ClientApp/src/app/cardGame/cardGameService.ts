import { HttpClient } from '@angular/common/http';
import { CardTypeDto } from '../Dtos/CardTypeDto'
import { CardType } from '../models/cards/CardType';
import { PersonCard } from '../models/cards/PersonCard';
import { SpaceshipCard } from '../models/cards/SpaceshipCard';
import { PlayableCard } from '../models/cards/PlayableCard';
import { PersonCardDto } from '../Dtos/PersonCardDto';



export class CardGameService {
  url: string = "https://localhost:44306/api";

  cardTypes: CardTypeDto[];

  constructor(private http: HttpClient) {
    this.cardTypes = this.getCardTypes();
  }


  getCardTypes(): CardTypeDto[] {
    let cardTypes: CardTypeDto[];

    this.http.get(`${this.url}/Game/GetCardTypes`).subscribe((data: CardTypeDto[]) => { console.log(data); this.cardTypes = data; });
    return cardTypes;
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
        break;
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

    console.log(dataToReturnGroupedByPlayer);
    return dataToReturnGroupedByPlayer;

  }
}