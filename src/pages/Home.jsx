import React, { useState } from 'react';
import PropTypes from 'prop-types';
import { Button } from '@mui/material';

Home.propTypes = {};

function Home(props) {
  return (
    <div>
      <h1>Home</h1>
      <Button variant="contained" color="success">
        Success
      </Button>
    </div>
  );
}

export default Home;
