import { PlayableCard } from './PlayableCard';
import { Player } from '../players/Player';
import { CardType } from './CardType';

export class SpaceshipCard extends PlayableCard {
  cardType = CardType.Spaceship;
  id: string;
  name: string;
  player: Player;
  crewCount: number;

  constructor(id: string, name: string, player: Player, crewCount: number) {
    super(id, name, player);
    this.crewCount = crewCount;
  }

  getPower() {
    return this.crewCount;
  }
}
