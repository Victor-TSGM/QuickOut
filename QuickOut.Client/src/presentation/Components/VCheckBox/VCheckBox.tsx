import * as React from 'react';
import * as Styles from './vcheckbox-styles.scss';
import { ThemeType } from '../Theme';

export interface Props {
  title?: string
  checked: boolean
  onCheck: () => void
  theme: ThemeType
}

const VCheckBox = (props: Props) => {
  return (
    <div className={Styles.vcheckbox}>
      <input
        className={props.theme == ThemeType.Light ? Styles.vcheckboxLight : Styles.vcheckboxDark}
        type="checkbox"
        title={props.title}
        checked={props.checked}
        onChange={() => props.onCheck}
      />
      <label className={props.theme == ThemeType.Light ? Styles.vcheckboxLabelLight : Styles.vcheckboxLabelDark} >
        {props.title}
      </label>
    </div>
  );
}

export default VCheckBox;