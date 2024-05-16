import * as React from 'react';
import * as Styles from './vsidebar-styles.scss';
import { ThemeType } from '../Theme';
import { ChevronLeft16Filled, ChevronLeft24Filled, History16Regular, History20Filled, History20Regular, List20Filled, List24Filled, Location16Filled, Location20Filled, Person16Regular, Person20Filled, Person20Regular } from '@fluentui/react-icons';
import { Switch } from '@fluentui/react-components';

export interface Props {
  onSelect: (id: number) => void
}

export const sideBarData = [
  {
    id: 1,
    icon: <Person20Filled />,
    title: "Conta"
  },
  {
    id: 2,
    icon: <History20Filled />,
    title: "Histórico"
  },
  {
    id: 3,
    icon: <Location20Filled />,
    title: "Endereços"
  },
]

export const VSideBar = (props: Props) => {
  const [isOpen ,setIsOpen ] = React.useState<boolean>(false);

  const renderSidebar = (opened: boolean) => {
    if (!opened) {
      return (
        <button
          className={Styles.icon}
          onClick={() => setIsOpen(true)}
        >
          <List24Filled />
        </button>
      )
    } else {
      return (
        <div className={Styles.fullSideBar}>
          <div className={Styles.sidebarHeader}>
            <button className={Styles.closeButton} onClick={() => setIsOpen(false)}>
              <ChevronLeft24Filled />
            </button>
          </div>
          <ul className={Styles.sidebarItemList}>
            {
              sideBarData.map(item => {
                return (
                  <li key={item.id} className={Styles.sidebarItem} onClick={() => props.onSelect(item.id)}>
                    {item.icon}&ensp;{item.title}
                  </li>
                )
              })
            }
          </ul>
        </div>
      )
    }
  }

  return (
    <div className={Styles.vsidebar}>
      {renderSidebar(isOpen)}
    </div>
  );
}