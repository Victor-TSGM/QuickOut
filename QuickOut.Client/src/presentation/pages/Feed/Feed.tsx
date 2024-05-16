import * as React from 'react';
import * as Styles from './feed-styles.scss';
import { VSideBar } from '@/presentation/Components/VSideBar/VSideBar';
import { VNotification } from '@/presentation/Components/VNotification/VNotification';
import { VBanner } from '@/presentation/Components/VBanner/VBanner';

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

      {/* ícone de menu  e ícone de notificação*/}

    </div>
  );
}