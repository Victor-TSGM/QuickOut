import * as React from 'react';
import * as Styles from './vproductcard-styles.scss';
import { ProductViewModel } from '@/domain/models/ProductViewModel';
import { productData } from '@/data/fakeData/ProductData';
import { promotionData } from '@/data/fakeData/PromotionData';

export interface Props {
  item: ProductViewModel
}



const VProductCard = (props: Props) => {

  const renderPromotionThumb = () => {
    if(props.item.promotionId == null) {
      return <></>
    }

    return (
      <div className={Styles.promotion}>
        <img src="/images/promotionicon.png" alt="" style={{width: '20px', height: '20px'}}/>
        &ensp;
        <p>R$ {(props.item.price - promotionData[0].promotionValue).toFixed(2)}</p>
      </div>
    )
  }
  return ( 
    <div className={Styles.vProductCard}>
      <img src={props.item.imageUrl} alt={props.item.name} />
      <p className={Styles.name}>{props.item.name}</p>
      <div className={Styles.price}>
        <p className={Styles.value}>R$ {props.item.price.toFixed(2)}</p>
        {renderPromotionThumb()}
      </div>
    </div>
   );
}
 
export default VProductCard;
