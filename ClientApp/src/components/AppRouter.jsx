import React from 'react';

//here it's a file is named AppRoutes.js
import {Routes, Route} from 'react-router-dom';
import { privateRoutes, publicRoutes } from '../router/routes';
import { useContext } from 'react';
import { AuthContex } from '../context/insex';
import Loader from './UI/Loader/Loader';

const AppRouter = () => {
  const {isAuth, isLoading} = useContext(AuthContex);
  if(isLoading) return <Loader/>

  return(
      <Routes>
        {isAuth
          ?privateRoutes.map((route) => 
            <Route key={route.path} path={route.path} element = {route.component}></Route>)
          :publicRoutes.map((route) => 
            <Route key={route.path} path={route.path} element = {route.component}></Route>)}    
      </Routes>
  )
}

export default AppRouter;