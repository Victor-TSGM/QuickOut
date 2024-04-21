import { FuncionarioViewModel } from "./FuncionarioViewModel"
import { PostoViewModel } from "./PostoViewModel"
import { TurnoViewModel } from "./TurnoViewModel"

export class FolgaTrabalhadaViewModel {
  id: number
  funcionarioSubstituto: FuncionarioViewModel
  funcionarioSubstituido: FuncionarioViewModel
  turno: TurnoViewModel
  posto: PostoViewModel
}