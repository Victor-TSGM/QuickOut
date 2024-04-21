import React from 'react'
import { BrowserRouter, Route, Routes, useRoutes } from 'react-router-dom'

import { faAdd, faArrowRight, faBox, faBusinessTime, faMinus, faNotesMedical, faPlus } from '@fortawesome/free-solid-svg-icons'
import { Home } from '@/presentation/pages/Home/Home'
import TurnoIndex from '@/presentation/pages/Turno/TurnoIndex'
import Layout from '@/presentation/Components/Layout/Layout'
import { icon } from '@fortawesome/fontawesome-svg-core'
import { Cadastros } from '@/presentation/pages/Cadastros/Cadastros'
import FuncionarioIndex from '@/presentation/pages/Funcionario/FuncionarioIndex'
import FuncionarioForm from '@/presentation/pages/Funcionario/CRUD/FuncionarioForm'
import Login from '@/presentation/pages/Login/Login'
// --> Pages

export const App = (): JSX.Element => {

  return (
    <>
      <BrowserRouter>
        <Routes>
          <Route key={Math.random()} path="/" element={<Login />} />,
        </Routes>
        {/* <Layout 
          menuItems={[
            {
              id: 1,
              title: 'Cadastros',
              route : '/cadastros',
              icon: faPlus
            }
          ]}
          children={[
            // <Route key={Math.random()} path="/*" element={<Home />} />,
            <Route key={Math.random()} path="/cadastros" element={<Cadastros />} />,
            <Route key={Math.random()} path="/funcionario" element={<FuncionarioIndex />} />,
            <Route key={Math.random()} path="/funcionario/novo" element={<FuncionarioForm  />} />
          ]}
        /> */}
      </BrowserRouter>
    </>
  )
}
