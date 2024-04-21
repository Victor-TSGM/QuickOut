import { TurnoViewModel } from '@/domain/models/TurnoViewModel';
import * as React from 'react';

export interface Props {

}

export const turnoDataSource : TurnoViewModel[] = [
  {
    id: 1,
    nome : 'Vigilância 01',
    horaInicial: 8,
    horaFinal: 17,
    horasTotais: 17 - 8,
  },
  {
    id: 2,
    nome : 'Vigilância 02',
    horaInicial: 8,
    horaFinal: 17,
    horasTotais: 17 - 8,
  },
  {
    id: 3,
    nome : 'Portaria 01',
    horaInicial: 8,
    horaFinal: 17,
    horasTotais: 17 - 8,
  },
  {
    id: 4,
    nome : 'Portaria 02',
    horaInicial: 8,
    horaFinal: 17,
    horasTotais: 17 - 8,
  },
  {
    id: 5,
    nome : 'Vigilância 02',
    horaInicial: 8,
    horaFinal: 17,
    horasTotais: 17 - 8,
  }
]

const TurnoIndex = (props: Props) => {
  const [selectedTurno, setSelectedTurno ] = React.useState<number>(0)


  return ( 
    <div className="col-12">Turnos</div>
   );
}
 
export default TurnoIndex;