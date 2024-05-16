import * as React from 'react';
import * as Styles from './vbanner-styles.scss';
import { BannerViewModel } from '@/domain/models/BannerViewModel';
import Slider from "react-slick";
import { bannersData } from '@/data/fakeData/BannerData';

export interface Props {

}

export const VBanner = (props: Props) => {
  
  const renderBanners = (items: BannerViewModel[]) => {
    var settings = {
      dots: true,
      infinite: true,
      speed: 500,
      slidesToShow: 1,
      slidesToScroll: 1,
    }

    return (
      <div className={Styles.bannerSlider}>
        <Slider {...settings}>
          {
            items.map(item => {
              return (
                <div key={item.id} className={Styles.banner}>
                  <a href={item.sourceLink}>
                    <img src={item.image} alt=""/>
                  </a>
                </div>
              )
            })
          }
        </Slider>
      </div>
    )
  }

  return (
    <div className={Styles.vbanner}>
      {renderBanners(bannersData)}
    </div>
  );
}