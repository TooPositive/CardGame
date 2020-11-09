import { Component, ViewEncapsulation, Input, Output, ContentChild, TemplateRef, EventEmitter } from '@angular/core';
import { PlayableCard } from '../../../models/cards/PlayableCard';

@Component({
  selector: 'app-handCards',
  templateUrl: './handCards.template.html',
  styleUrls: ['./handCards.template.css']
})
export class HandCardsComponent {
  @Input()
  inputPlayingCards: PlayableCard[];
  @Output() messageEvent = new EventEmitter<string>();

  ngOnChanges(changePlayableCard: any) {
    let value = changePlayableCard.inputPlayingCards.currentValue as PlayableCard[];
    //console.log(`init HandCardsComponent from: ${value[0].getName()}`);
    console.log(`init HandCardsComponent from: ${changePlayableCard.inputPlayingCards.currentValue[0]}`);
    this.inputPlayingCards = value;
  }

  cardClicked(card: PlayableCard) {
    //TODO: Figure out the better way to notify about card click event
    //this.messageEvent.emit(`Hand card clicked: from player - ${card.player.id}, card - ${card.id}`);
    this.messageEvent.emit(JSON.stringify(card));
  }
}
