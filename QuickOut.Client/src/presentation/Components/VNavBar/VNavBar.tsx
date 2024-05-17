import * as React from 'react';
import * as Styles from './vnavbar-styles..scss';
import { Chat32Regular, Heart32Regular, Person32Regular, Search28Regular, Search32Regular } from '@fluentui/react-icons';

export interface Props {

}

const VNavBar = (props: Props) => {
  return (
    <div className={Styles.vnavbar}>
      <button className={Styles.startButton}>
        <img src="/images/navicon.png" alt="" style={{ width: '35px', height: '35px' }} />
        &ensp;
        <p>Start</p>
      </button>
      <button className={Styles.navButton}>
        <Search32Regular />
      </button>
      <button className={Styles.navButton}>
        <Heart32Regular />
      </button>
      <button className={Styles.navButton}>
        <Chat32Regular />
      </button>
      <button className={Styles.navButton}>
        <Person32Regular />
      </button>
    </div>
  );
}

export default VNavBar;