import { PlayableCard } from './PlayableCard';
import { Player } from '../players/Player';
import { CardType } from './CardType';

export class PersonCard extends PlayableCard {
  cardType: CardType;
  id: string;
  name: string;
  player: Player;
  mass: number;

  constructor(id: string, name: string, player: Player, mass: number) {
    super(id, name, player);
    this.mass = mass;
  }

  getPower() {
    return this.mass;
  }
}
