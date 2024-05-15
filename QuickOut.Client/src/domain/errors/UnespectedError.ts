import { error } from "console";

export class UnespectedError extends Error {
  constructor() {
    super("Algo deu errado, repita a operação")
    this.name = "UnespectedError"
  }
}