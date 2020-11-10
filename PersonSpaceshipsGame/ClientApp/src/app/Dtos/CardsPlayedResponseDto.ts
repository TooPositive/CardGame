import { Player } from "../models/players/Player";
import { CardResponseResult } from "../models/cards/CardType";

export interface CardsPlayedResponseDto {
  winner: Player;
  result: CardResponseResult;
}
