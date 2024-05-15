import * as React from 'react';
import { ThemeType } from '../Theme';
import * as Styles from './vlink-styles.scss';

export interface Props {
  text: string
  href: string
  theme: ThemeType
}

const VLink = (props: Props) => {
  return ( 
    <a href={props.href} className={props.theme == ThemeType.Light ? Styles.vlinkLight : Styles.vlinkDark}>
      {props.text}
    </a>
   );
}
 
export default VLink;