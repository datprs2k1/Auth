import React from 'react';
import PropTypes from 'prop-types';
import { Outlet } from 'react-router-dom';

App.propTypes = {};

function App(props) {
  return <Outlet />;
}

export default App;
