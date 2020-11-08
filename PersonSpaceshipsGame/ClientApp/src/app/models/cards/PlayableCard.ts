import { Player } from "../players/Player";
import { CardType } from "./CardType";

export abstract class PlayableCard {
  cardType: CardType;
  id: string;
  name: string;
  player: Player;

  constructor(id: string, name: string, player: Player) {
    this.id = id;
    this.name = name;
    this.player = player;
  }

  getName() { return this.name; }
  getCardType() { return CardType[this.cardType] };
  abstract getPower();
}
