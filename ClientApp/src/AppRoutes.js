import Home from "./pages/Home";
import Order from "./pages/Order";
import Orders from "./pages/Orders";
import Profile from "./pages/Profile";
import Clients from "./pages/Clients";
import Company from "./pages/Company";
import Contractors from "./pages/Contractors";
import Customer from "./pages/Customer";
import Login from "./pages/Login";
import Error from "./pages/Error";
import Companies from "./pages/Companies";

const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: '/profile',
    element: <Profile/>
  },
  {
    path: '/order',
    element: <Order/>
  },
  {
    path: '/orders',
    element: <Orders/>
  },
  {
    path: '/customer',
    element: <Customer/>
  },
  {
    path: '/clients',
    element: <Clients/>
  },
  {
    path: '/company',
    element: <Company/>
  },  
  {
    path: '/companies',
    element: <Companies/>
  },
  {
    path: '/contractor',
    element: <Contractors/>
  },
  {
    path: '/login',
    element: <Login/>
  },
  {
    path: '/error',
    element: <Error/>
  }
];

export default AppRoutes;
