import * as React from 'react';
import * as Styles from './vbanner-styles.scss';
import { BannerViewModel } from '@/domain/models/BannerViewModel';
import Slider from "react-slick";

export interface Props {

}

const bannersData: BannerViewModel[] = [
  {
    id: 1,
    title: 'QuickOutPlus',
    image: './images/banner01.png',
    sourceLink: ''
  },
  {
    id: 2,
    title: 'QuickOutPlus',
    image: './images/banner02.png',
    sourceLink: ''
  },
  {
    id: 3,
    title: 'QuickOutPlus',
    image: './images/banner03.png',
    sourceLink: ''
  }
]

export const VBanner = (props: Props) => {
  const [currentBanner, setCurrentBanner] = React.useState<number>(1);



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