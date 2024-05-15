import * as React from 'react';
import { ThemeType } from '../Theme';
import * as Styles from './vbutton-styles.scss';

export interface Props {
  text: string
  theme: ThemeType
  onSubmit: () => void
  icon?: React.ReactNode
}

const VButton = (props: Props) => {
  return ( 
    <button 
      className={
        props.theme == ThemeType.Light 
          ? Styles.vbuttonLight 
          : Styles.vbuttonDark
      }
      onClick={() => props.onSubmit()}
    >
      {props.text}
      &ensp;
      {props.icon ? props.icon : ''}
    </button>
   );
}
 
export default VButton;