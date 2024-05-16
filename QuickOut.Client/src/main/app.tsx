import * as React from 'react';
import * as Styles from './app.scss';
import Login from '@/presentation/pages/Login/Login';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import { Feed } from '@/presentation/pages/Feed/Feed';
const App = () => {
  return (
    <>
      <BrowserRouter>
        <Routes>
          <Route path='/' Component={() => <Login />}/>
          <Route path='/feed' Component={() => <Feed />}/>
        </Routes>
      </BrowserRouter>
    </>
  );
}

export default App;