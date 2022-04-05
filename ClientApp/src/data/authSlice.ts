import { createSlice, PayloadAction } from '@reduxjs/toolkit'
import { IAuthSuccessResponse } from 'types';


export interface AuthState {
    access_token: string;
    authenticated: boolean;
}

const initialState: AuthState = {
    authenticated: false,
    access_token: window.sessionStorage.getItem('access_token') || '',
}


export const authSlice = createSlice({
    name: 'auth',
    initialState,
    reducers: {
        setToken: (state, action: PayloadAction<IAuthSuccessResponse>) => {
            state.authenticated = true;
            window.sessionStorage.setItem('access_token', action.payload.access_token)
            state.access_token = action.payload.access_token;
        },
        logout: (state) => {
            state.authenticated = false;
            state.access_token = '';
            window.sessionStorage.removeItem('access_token')
        }
    }
})

// Action creators are generated for each case reducer function
export const { setToken, logout } = authSlice.actions

export default authSlice.reducer