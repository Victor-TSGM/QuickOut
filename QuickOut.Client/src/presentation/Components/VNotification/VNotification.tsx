import * as React from 'react';
import * as Styles from './vnotification-styles.scss';
import { Alert20Filled, ChevronLeft24Filled, Mail20Filled } from '@fluentui/react-icons';
import { NotificationViewModel } from '@/domain/models/NotificationViewModel';

export interface Props {

}


export const notificationData : NotificationViewModel[] = [
  {
    id: 1,
    title: "Oferta!",
    content: "Parabêns, você acaba de ganhar um descondo de 10% para adquirir o QuickOutPlus ainda hoje.",
    readed: false

  },
  {
    id: 2,
    title: "Ei, vamos conversar?",
    content: "Você sabe que no Brasil existem cerca de 8.7 milhões de pessoas que estão passando fome? Nós do time QuickOut enfatizamos a importância da solidariedade, doe qualquer valor para instituições confiáveis.",
    readed: false
  }
]

export const VNotification = ({ }: Props) => {
  const [isOpened, setIsOpened] = React.useState<boolean>(false);
  const [selected, setSelected] = React.useState<number>();

  const renderNotification = (opened: boolean) => {
    if (!opened) {
      return (
        <button
          className={Styles.icon}
          onClick={() => setIsOpened(true)}
        >
          <Alert20Filled />
        </button>
      )
    } else {
      return (
        <div className={Styles.fullNotification}>
          <div className={Styles.header}>
            <button className={Styles.closeButton} onClick={() => setIsOpened(false)}>
              <ChevronLeft24Filled />&ensp;
            </button>
            <h2 className={Styles.title}>Notificações</h2>
          </div>
          <div className={Styles.notificationList}>
            {
              notificationData.map(item => {
                return (
                  <div className={Styles.notificationItem}
                    onClick={() => {
                      if (selected == item.id) {
                        setSelected(0)
                      } else {
                        setSelected(item.id)
                        item.readed = true
                      }
                    }}
                  >
                    <p>
                      <Mail20Filled />&ensp;{item.title}
                    </p>
                    {
                      selected == item.id
                        ? <div className={Styles.notificationContent}>
                          {item.content}
                        </div>
                        : <></>
                    }
                  </div>
                )
              })
            }
          </div>
        </div>
      )
    }
  }


  return (
    <div className={Styles.vnotification}>
      {renderNotification(isOpened)}
    </div>
  );
}