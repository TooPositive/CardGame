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
    this.inputPlayingCards = value;
  }

  cardClicked(card: PlayableCard) {
    this.messageEvent.emit(JSON.stringify(card));
  }
}
