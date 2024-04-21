import * as React from 'react';
import './Login.css';
import { Input } from '@fluentui/react-components';

export interface Props {

}

const Login = (props: Props) => {
  return (
    <div className="g-0">
      <div className="col-12 d-flex flex-column login-container" style={{ height: '100vh', width: '100vw'}}>
        <div className="col-6 d-flex login-card">
          <div className="col-8 w-100 p-1"><Input placeholder='Email' style={{width: '50%', color : 'black', backgroundColor: 'white'}}></Input></div>
          <div className="col-8 w-100 p-1"><Input placeholder='Senha' style={{width: '50%',color : 'black', backgroundColor: 'white'}}></Input></div>
        </div>
      </div>
    </div>
  );
}

export default Login;