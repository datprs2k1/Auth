import React from 'react';
import PropTypes from 'prop-types';
import { Box, Button, Container, Grid, Link, TextField, Typography } from '@mui/material';
import ArrowBackIcon from '@mui/icons-material/ArrowBack';
import FacebookIcon from '@mui/icons-material/Facebook';
import GoogleIcon from '@mui/icons-material/Google';
import { NavLink } from 'react-router-dom';
import { useForm } from 'react-hook-form';
import { yupResolver } from '@hookform/resolvers/yup';
import * as yup from 'yup';
import { useDispatch } from 'react-redux';
import { login } from '../stores/user/index';

Login.propTypes = {};

function Login(props) {
  const schema = yup
    .object({
      email: yup.string().email().required(),
      password: yup.string().required(),
    })
    .required();

  const {
    register,
    handleSubmit,
    formState: { errors, touchedFields },
  } = useForm({
    resolver: yupResolver(schema),
  });

  const dispatch = useDispatch();
  const onSubmit = async (data) => {
    dispatch(login(data));
  };

  return (
    <div>
      <Box
        component="main"
        sx={{
          alignItems: 'center',
          display: 'flex',
          flexGrow: 1,
          minHeight: '100%',
        }}
      >
        <Container maxWidth="sm">
          <form onSubmit={handleSubmit(onSubmit)}>
            <Box sx={{ my: 3 }}>
              <Typography color="textPrimary" variant="h4">
                Sign in
              </Typography>
              <Typography color="textSecondary" gutterBottom variant="body2">
                Sign in on the internal platform
              </Typography>
            </Box>

            <TextField
              {...register('email')}
              error={Boolean(touchedFields.email && errors.email)}
              helperText={touchedFields.email && errors.email?.message}
              fullWidth
              label="Email Address"
              margin="normal"
              variant="outlined"
              type="email"
              name="email"
            />

            <TextField
              {...register('password')}
              error={Boolean(touchedFields.password && errors.password)}
              helperText={touchedFields.password && errors.password?.message}
              fullWidth
              label="Password"
              margin="normal"
              type="password"
              variant="outlined"
              name="password"
            />
            <Box sx={{ py: 2 }}>
              <Button color="primary" fullWidth size="large" type="submit" variant="contained">
                Sign In Now
              </Button>
            </Box>
            <Typography color="textSecondary" variant="body2">
              Don&apos;t have an account?{' '}
              <Link
                to="/register"
                variant="subtitle2"
                underline="hover"
                sx={{
                  cursor: 'pointer',
                }}
              >
                Sign Up
              </Link>
            </Typography>
          </form>
        </Container>
      </Box>
    </div>
  );
}

export default Login;
