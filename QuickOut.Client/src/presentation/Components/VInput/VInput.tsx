import { Input } from '@fluentui/react-components';
import * as React from 'react';
import * as Styles from './vinput-styles.scss';
import { ThemeType } from '../Theme';

export interface Props {
  placeholder?: string
  id?: string
  type: string
  onChange?: (e: string) => void
  theme: ThemeType
}

const VInput = (props: Props) => {
  return (
    <input 
      className={props.theme == ThemeType.Light ? Styles.vinputLight : Styles.vinputDark}
      type={props.type} 
      placeholder={props.placeholder} 
      onChange={(e) => props.onChange(e.target.value)}
    /> 
   );
}
 
export default VInput;