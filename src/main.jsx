import React from 'react';
import ReactDOM from 'react-dom/client';
import App from './App';
import router from './routes';
import { RouterProvider } from 'react-router-dom';
import { Provider } from 'react-redux';
import { store } from './stores/index';
import CssBaseline from '@mui/material/CssBaseline';

import '@fontsource/roboto/300.css';
import '@fontsource/roboto/400.css';
import '@fontsource/roboto/500.css';
import '@fontsource/roboto/700.css';

ReactDOM.createRoot(document.getElementById('root')).render(
  <React.StrictMode>
    <CssBaseline />
    <Provider store={store}>
      <RouterProvider router={router} />
    </Provider>
  </React.StrictMode>
);
