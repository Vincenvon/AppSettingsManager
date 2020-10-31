import {
    LOGIN_CHANGED,
    LOGIN_SIGN_IN_START,
    LOGIN_SIGN_IN_FAILED,
    LOGIN_SIGN_IN_SUCCESS
} from '../actions/login';

export const loginChanged = login => ({
    type: LOGIN_CHANGED,
    login,
});

export const loginSignInStart = login => ({
    type: LOGIN_SIGN_IN_START,
    login,
});

export const loginSignInSuccess = ({ token }) => ({
    type: LOGIN_SIGN_IN_SUCCESS,
    token,
});

export const loginSignInFailed = ({ error }) => ({
    type: LOGIN_SIGN_IN_FAILED,
    error,
});
