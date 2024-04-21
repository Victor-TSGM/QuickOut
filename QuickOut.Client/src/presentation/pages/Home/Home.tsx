import React from 'react'
import './Home.css'
import { type ServicesDefinition } from '@/presentation/providers/ServicesDefinition'
import { type IBoilerplateService } from '@/domain/interfaces/IBoilerplateService'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import {  faCalendarAlt, faFileLines, faGears, faPerson, faPlus, faPlusSquare, faUniversalAccess } from '@fortawesome/free-solid-svg-icons'
import {  useNavigate } from 'react-router-dom'

export interface Props {

}

export const Home = (porps: Props): JSX.Element => {
  const navigate = useNavigate();
  return (
    <div className="g-0">
      <div className="col-12 home-content p-2">
        <button className="btn btn-primary d-flex flex-column p-3 home-widget" onClick={() => {
          navigate("/escala")
        }}>
          <FontAwesomeIcon icon={faCalendarAlt} />
          <p></p>
          Escala
        </button>
        <button className="btn btn-primary d-flex flex-column p-3 home-widget"onClick={() => {
          navigate("/cadastros")
        }}>
          <FontAwesomeIcon icon={faPlus} />
          <p></p>
          Cadastros
        </button>
        <button className="btn btn-primary d-flex flex-column p-3 home-widget">
          <FontAwesomeIcon icon={faFileLines} />
          <p></p>
          Relatórios
        </button>
        <button className="btn btn-primary d-flex flex-column p-3 home-widget">
          <FontAwesomeIcon icon={faGears} />
          <p></p>
          Configurações
        </button>
      </div>
    </div>
  )
}
