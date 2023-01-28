import { createSlice } from '@reduxjs/toolkit';
import api from './../../services/api';

export const userSlice = createSlice({
  name: 'user',
  initialState: {
    user: {},
    isAuthenticated: false,
    token: '',
    expried: '',
  },
  reducers: {
    login: async (state, action) => {
      const { email, password } = action.payload;

      const response = await api.post('/api/User/signin', {
        email,
        password,
      });

      console.log(response);
    },
  },
});

export const { login } = userSlice.actions;
export default userSlice.reducer;
