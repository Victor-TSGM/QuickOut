import { FuncionarioViewModel } from "./FuncionarioViewModel"
import { PostoViewModel } from "./PostoViewModel"
import { TurnoViewModel } from "./TurnoViewModel"

export class EscalaItemViewModel {
  id: number
  funcionario: FuncionarioViewModel
  dia: Date
  turno: TurnoViewModel
  posto: PostoViewModel
  status: EscalaStatus
}

export enum EscalaStatus {
  Pendente = 0,
  Presente = 1,
  Ausente = 2
}