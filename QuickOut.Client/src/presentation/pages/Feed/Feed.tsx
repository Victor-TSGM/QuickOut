import * as React from 'react';
import * as Styles from './feed-styles.scss';
import { VSideBar } from '@/presentation/Components/VSideBar/VSideBar';
import { VNotification } from '@/presentation/Components/VNotification/VNotification';
import { VBanner } from '@/presentation/Components/VBanner/VBanner';
import { estabilishmentData } from '@/data/fakeData/EstabilishmentData';
import { VEstabilishmentCard } from '@/presentation/Components/VEstabilishmentCard/VEstabilishmentCard';

export interface Props {

}

export const Feed = (props: Props) => {
  const [showNotifications, setShowNotifications] = React.useState<boolean>(false);


  return (
    <div className={Styles.feed}>
      <div className={Styles.header}>
        <VSideBar onSelect={(id: number) => { console.log(id) }} />
        <VNotification />
      </div>
      <div className={Styles.banners}>
        <VBanner />
      </div>
      <div className={Styles.contentConainer}>
        <h1 className={Styles.contentTitle}>Veja os estabelecimentos da sua cidade</h1>
        <div className={Styles.content}>
          {
            estabilishmentData.map(item => {
              return (
                <VEstabilishmentCard item={item} onSelect={() => {}}/>
              )
            })
          }
        </div>
      </div>
      <div className={Styles.nav}></div>
    </div>
  );
}