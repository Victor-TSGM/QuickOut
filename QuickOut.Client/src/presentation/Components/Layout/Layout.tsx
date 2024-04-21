import { FontawesomeObject, IconDefinition, IconProp } from '@fortawesome/fontawesome-svg-core';
import './Layout.css';
import { FontAwesomeIcon, FontAwesomeIconProps } from '@fortawesome/react-fontawesome';
import * as React from 'react';
import { Routes, useNavigate } from 'react-router-dom';
import { faHome, faList } from '@fortawesome/free-solid-svg-icons';

export class MenuItems {
  id: number
  title: string
  route: string
  icon?: IconDefinition
}

export interface Props {
  title?: string
  menuItems: MenuItems[]
  children: React.ReactElement[]
}

const Layout = (props: Props) => {
  const navigate = useNavigate();
  const [fullMenu, setFullMenu] = React.useState<boolean>(false)
  const [selected, setSelected] = React.useState<number>();

  return (
    <div className="layout-container">
      <div className={fullMenu ? "layout-sidebar-full" : "layout-sidebar"} >
        <button key={Math.random()} className="btn sidebar-item-start p-3" onClick={() => setFullMenu(!fullMenu)}>
          <FontAwesomeIcon icon={faList} />
        </button>
        <button key={Math.random()} className={`btn sidebar-item${selected == 0 ? '-selected' : ''} p-3 `} onClick={() => {
          setSelected(0)
          setFullMenu(false)
          navigate('/')
        }}>
          {fullMenu ? "Home" : ''}
          <FontAwesomeIcon icon={faHome} />
        </button>
        {
          props.menuItems.map(item => {
            return <button key={Math.random()} className={`btn sidebar-item${selected == item.id ? '-selected' : ''} p-3 `} onClick={() => {
              setSelected(item.id)
              setFullMenu(false)
              navigate(item.route)
            }}>
              {fullMenu ? item.title : ''}
              <FontAwesomeIcon icon={item.icon} />
            </button>
          })
        }
      </div>
      <div className="layout-header">
        <div className="header-title">{props.title}</div>
      </div>
      <div className="layout-content">
        <Routes>
          {props.children.map(route => route)}
        </Routes>
      </div>
    </div>
  );
}

export default Layout;