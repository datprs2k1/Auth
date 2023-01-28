import { configureStore } from '@reduxjs/toolkit';
import userSlice from './user/index';

export const store = configureStore({
  reducer: {
    user: userSlice,
  },
});
