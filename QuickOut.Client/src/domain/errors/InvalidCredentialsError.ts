import { error } from "console";

export class InvalidCredentialsError extends Error {
  constructor() {
    super("Credenciais inválidas")
    this.name = "InvalidCredentialsError"
  }
}