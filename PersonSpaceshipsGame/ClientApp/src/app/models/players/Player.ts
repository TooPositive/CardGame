import { PlayableCard } from "../cards/PlayableCard";

export class Player {
  id: string;
  points: number;
  cards: PlayableCard[];
  hasWon: boolean;

  constructor(id: string, points: number, cards: PlayableCard[]) {
    this.id = id;
    this.points = points;
    this.cards = cards;
    this.hasWon = false;
  }
}
