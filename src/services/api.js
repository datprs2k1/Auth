import axios from 'axios';
import { store } from './../stores/index';

const state = store.getState();

const token = state.user.token;

const api = axios.create({
  baseURL: 'https://localhost:7080',
  headers: {
    'Content-Type': 'application/json',
    Authorization: `Bearer ${token}`,
  },
});

export default api;
