import * as React from 'react';
import * as Styles from './vnavbar-styles..scss';
import { Chat32Regular, Heart32Regular, Person32Regular, Search28Regular, Search32Regular } from '@fluentui/react-icons';
import { Link, useNavigate } from 'react-router-dom';

export interface Props {
}

export enum NavBarOptions {
  Start,
  Search,
  Fav,
  Chat,
  Profile
}

const VNavBar = (props: Props) => {
  const naviate = useNavigate();

  const openPage = (option: NavBarOptions) => {
    switch (option) {
      case NavBarOptions.Start:
        naviate('/start')
      case NavBarOptions.Search:
        naviate('/search')
      case NavBarOptions.Fav:
        naviate('/favorites')
      case NavBarOptions.Profile:
        naviate('/profile')
    }
  }
  return (
    <div className={Styles.vnavbar}>
      <button className={Styles.startButton} onClick={() => openPage(NavBarOptions.Start)}>
        <img src="/images/navicon.png" alt="" style={{ width: '35px', height: '35px' }} />
        &ensp;
        <p>Start</p>
      </button>
      <button className={Styles.navButton} onClick={() => openPage(NavBarOptions.Search)}>
        <Search32Regular />
      </button>
      <button className={Styles.navButton} onClick={() => openPage(NavBarOptions.Fav)}>
        <Heart32Regular />
      </button>
      <button className={Styles.navButton} onClick={() => openPage(NavBarOptions.Chat)}>
        <Chat32Regular />
      </button>
      <button className={Styles.navButton} onClick={() => openPage(NavBarOptions.Profile)}>
        <Person32Regular />
      </button>
    </div>
  );
}

export default VNavBar;