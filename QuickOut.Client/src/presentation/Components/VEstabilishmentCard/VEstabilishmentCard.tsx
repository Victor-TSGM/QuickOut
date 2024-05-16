import * as React from 'react';
import * as Styles from './vestabilishmentCard-styles.scss';
import { EstabilishmentViewModel } from '@/domain/models/EstabilishmentViewModel';
import { Rating } from 'react-simple-star-rating';
import { Open12Filled } from '@fluentui/react-icons';

export interface Props {
  item: EstabilishmentViewModel
  onSelect: (id: number) => void
}

export const VEstabilishmentCard = (props: Props) => {
  return (
    <div key={Math.random()} className={Styles.vestabilishmentCard}>
      <div className={Styles.card}>
        <img className={Styles.cardImage} src={props.item.logoType} alt="" />
        <p className={Styles.title}>{props.item.name}</p>
        <div className={Styles.cardRating}>
          <Rating onClick={() => { }} initialValue={4.5} size={20} readonly allowHover={false} allowFraction />
          <p>{props.item.rating}</p>
        </div>
        <p className={Styles.updatedDate}>Atualizado:&nbsp;{props.item.lastUpdatedDate}</p>
        <div className={Styles.cardDetail}>
          <button className={Styles.detailButton} onClick={() => props.onSelect(props.item.id)}>
            Ver ofertas&nbsp;<Open12Filled />
            </button>
        </div>
      </div>
    </div>
  );
}