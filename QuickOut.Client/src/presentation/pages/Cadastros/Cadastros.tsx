import React from 'react'
import './Cadastros.css'
import { type ServicesDefinition } from '@/presentation/providers/ServicesDefinition'
import { type IBoilerplateService } from '@/domain/interfaces/IBoilerplateService'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import {  faCalendarAlt, faClock, faFileLines, faGears, faLocation, faMapPin, faPerson, faPlus, faPlusSquare, faUniversalAccess } from '@fortawesome/free-solid-svg-icons'
import {  useNavigate } from 'react-router-dom'

export interface Props {

}

export const Cadastros = (porps: Props): JSX.Element => {
  const navigate = useNavigate();
  return (
    <div className="g-0">
      <div className="col-12 cadastros-content p-2">
        <button className="btn btn-primary d-flex flex-column p-3 cadastros-widget" onClick={() => {
          navigate("/funcionario")
        }}>
          <FontAwesomeIcon icon={faPerson} />
          <p></p>
          Funcionários
        </button>
        <button className="btn btn-primary d-flex flex-column p-3 cadastros-widget"onClick={() => {
          navigate("/turno")
        }}>
          <FontAwesomeIcon icon={faClock} />
          <p></p>
          Turnos
        </button>
        <button className="btn btn-primary d-flex flex-column p-3 cadastros-widget"onClick={() => {
          navigate("/posto")
        }}>
          <FontAwesomeIcon icon={faMapPin} />
          <p></p>
          Postos
        </button>
      </div>
    </div>
  )
}
