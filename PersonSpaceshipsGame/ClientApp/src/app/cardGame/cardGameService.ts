import { HttpClient } from '@angular/common/http';
import { CardTypeDto } from '../Dtos/CardTypeDto'



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

  startGame() {
    console.log(`starting game`);
  }

}
