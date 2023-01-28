import { createSlice } from '@reduxjs/toolkit';

export const userSlice = createSlice({
  name: 'user',
  initialState: {
    user: {},
    isAuthenticated: false,
    token: '',
    expried: '',
  },
  reducers: {
    login: (state, action) => {
      console.log('Hello');
    },
  },
});

export const { login } = userSlice.actions;
export default userSlice.reducer;
