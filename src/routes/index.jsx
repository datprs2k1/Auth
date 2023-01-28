import { createBrowserRouter, RouterProvider } from 'react-router-dom';
import Home from './../pages/Home';
import App from './../App';
import Login from './../pages/Login';
import Register from './../pages/Register';

const router = createBrowserRouter([
  {
    path: '/',
    element: <App />,
    children: [
      {
        path: '',
        element: <Home />,
      },
      {
        path: 'login',
        element: <Login />,
      },
      {
        path: 'register',
        element: <Register />,
      },
    ],
  },
]);

export default router;