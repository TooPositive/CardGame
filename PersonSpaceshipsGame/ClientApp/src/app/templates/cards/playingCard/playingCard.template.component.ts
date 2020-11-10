import { Component, ViewEncapsulation, Input, ContentChild, TemplateRef } from '@angular/core';
import { PlayableCard } from '../../../models/cards/PlayableCard';
import { PersonCard } from '../../../models/cards/PersonCard';
import { SpaceshipCard } from '../../../models/cards/SpaceshipCard';
import { CardType } from '../../../models/cards/CardType';

@Component({
  selector: 'app-playingCard',
  templateUrl: './playingCard.template.html',
  styleUrls: ['./playingCard.template.css']
})
export class PlayingCardComponent {
  @Input()
  inputPlayingCard: PlayableCard;
  personPlayingCard: PersonCard;
  spaceShipPlayingCard: SpaceshipCard;

  ngOnChanges(changePlayableCard: any) {
    //TODO: Better object creation, abstraction/factories/different components ?
    this.inputPlayingCard = changePlayableCard.inputPlayingCard.currentValue;
    switch (this.inputPlayingCard.cardType) {
      case CardType.Persons:
        this.personPlayingCard = this.inputPlayingCard as PersonCard;
        break;
      case CardType.Spaceship:
        this.spaceShipPlayingCard = this.inputPlayingCard as SpaceshipCard;
        break;

      default:
        console.log(`Card type not implemented ${this.inputPlayingCard.cardType}`); // TODO: Better exception handling
    }
  }
}
