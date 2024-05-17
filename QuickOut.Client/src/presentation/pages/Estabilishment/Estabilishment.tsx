import * as React from 'react';
import * as Styles from './estabilishment-styles.scss';
import { categoriyData } from '@/data/fakeData/CategoryData';
import { EstabilishmentViewModel } from '@/domain/models/EstabilishmentViewModel';
import { Rating } from 'react-simple-star-rating';
import VInput from '@/presentation/Components/VInput/VInput';
import { ThemeType } from '@/presentation/Components/Theme';
import { VNotification } from '@/presentation/Components/VNotification/VNotification';
import { ProductViewModel } from '@/domain/models/ProductViewModel';
import { productData } from '@/data/fakeData/ProductData';
import VProductCard from '@/presentation/Components/VProductCard/VProductCard';

export interface Props {
  item: EstabilishmentViewModel
  onClose: () => void
}

const Estabilishment = (props: Props) => {
  const [currentCategory, setCurrentCategory] = React.useState<number>(0);
  const [searchData, setSearchData] = React.useState<string>('');
  const [allProducts, setAllProducts] = React.useState<ProductViewModel[]>();
  const [products, setProducts] = React.useState<ProductViewModel[]>();

  React.useEffect(() => {
    setAllProducts(productData.filter(x => x.establishmentId == props.item.id))
  }, [])

  const renderCategoriesBar = () => {
    return <ul className={Styles.categotyBar}>
      <li key={Math.random()} className={currentCategory == 0 ? Styles.categoryItemSelected : Styles.categoryItem} onClick={() => setCurrentCategory(0)}>Todos</li>
      {
        categoriyData.map(item => {
          return (
            <li key={Math.random()} className={currentCategory == item.id ? Styles.categoryItemSelected : Styles.categoryItem} onClick={() => setCurrentCategory(item.id)}>{item.name}</li>
          )
        })
      }
    </ul>
  }

  const renderProducts = (products: ProductViewModel[], currentCategory: number, searchValue: string) => {
    let auxProducts: ProductViewModel[] = [];

    if (products == undefined) return;

    if (currentCategory == 0) {
      auxProducts = products
    } else {
      auxProducts = products.filter(x => x.categoryId == currentCategory)
    }

    if (searchValue != '') {
      auxProducts = products.filter(x => x.name.toLowerCase().includes(searchValue))
    }

    return (
      auxProducts.map(item => {
        return <div className={Styles.productCell}>
          <VProductCard item={item} />
        </div>
      })
    )
  }



  return (
    <div className={Styles.estabilishment}>
      <div className={Styles.header}>
        <div className={Styles.buttons}>
          <button onClick={() => props.onClose()}>Voltar</button>
        </div>
        <div className={Styles.data}>
          <div className={Styles.logo}>
            <img src={props.item.logoType} alt={props.item.name} />
          </div>
          <div className={Styles.infos}>
            <div className={Styles.name}>
              <p>{props.item.name}</p>
            </div>
            <div className={Styles.rating}>
              <Rating onClick={() => { }} initialValue={4.5} size={20} readonly allowHover={false} allowFraction />
              <p>{props.item.rating}</p>
            </div>
            <div className={Styles.address}>
              <p>{props.item.address}</p>
            </div>
          </div>
        </div>
      </div>
      <div className={Styles.filters}>
        <div className={Styles.search}>
          <VInput type='text' placeholder='Buscar produtos' theme={ThemeType.Light} onChange={(e) => setSearchData(e)} />
        </div>
        {renderCategoriesBar()}
      </div>
      <div className={Styles.content}>
        {renderProducts(allProducts, currentCategory, searchData)}
      </div>
    </div>
  );
}

export default Estabilishment;