import * as React from 'react';
import * as Styles from './vestabilishmentCard-styles.scss';
import { EstabilishmentViewModel } from '@/domain/models/EstabilishmentViewModel';

export interface Props {
  item: EstabilishmentViewModel
  onSelect: (id: number) => void
}

export const VEstabilishmentCard = (props: Props) => {
  return ( 
    <div key={props.item.id} className={Styles.vestabilishmentCard}>
        <div className={Styles.card}>
          <img src={props.item.logoType} alt="" />
        </div>
    </div>
  );
}