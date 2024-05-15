import React from 'react';
import ReactDOM from 'react-dom/client';
import App from './App';

let root = ReactDOM.createRoot(document.getElementById('main') as HTMLElement);

root.render(
  <React.StrictMode>
      <App />
  </React.StrictMode>,
);