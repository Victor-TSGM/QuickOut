import * as React from 'react';
import * as Styles from './login-styles.scss';
import { ArrowEnterFilled } from '@fluentui/react-icons';
import { ThemeType } from '@/presentation/Components/Theme';
import VButton from '@/presentation/Components/VButton/VButton';
import VCheckBox from '@/presentation/Components/VCheckBox/VCheckBox';
import VInput from '@/presentation/Components/VInput/VInput';
import VLink from '@/presentation/Components/VLink/VLink';

const Login = () => {
  const [email, setEmail] = React.useState<string>(null);
  const [password, setPassword] = React.useState<string>(null);

  const doLogin = () => {

  }

  return (
    <div className={Styles.login}>
      <form className={Styles.form} action="">
        <VInput placeholder='Email' type='email' onChange={(e) => setEmail(e)} theme={ThemeType.Light}/>
        <VInput placeholder='Senha'type='password'onChange={(e) => setEmail(e)} theme={ThemeType.Light}/>
        <div className={Styles.formOptions}>
          <VCheckBox title='Continuar conectado' checked={false} onCheck={() => {}} theme={ThemeType.Dark}/>
          <VLink text='Esqueci a senha' href='#' theme={ThemeType.Light}/>
        </div>
        <div className={Styles.formActions}>
          <VButton 
            text='Entrar' icon={<ArrowEnterFilled />} 
            theme={ThemeType.Light} onSubmit={() => {}}/>
            <VButton 
            text='Registrar' 
            theme={ThemeType.Dark} onSubmit={() => {}}/>
        </div>
      </form>
    </div>
  );
}

export default Login;