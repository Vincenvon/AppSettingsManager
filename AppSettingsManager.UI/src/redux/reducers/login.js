import {
    LOGIN_CHANGED,
    LOGIN_SIGN_IN_START,
    LOGIN_SIGN_IN_SUCCESS,
    LOGIN_SIGN_IN_FAILED,
} from '../actions/login';

const initialState = {
    userName: '',
    password: '',
    token: '',
};

export const login = (state = initialState, action) => {
    switch (action.type) {
        case LOGIN_CHANGED:
            return {
                ...state,
                ...action.login,
            };
        case LOGIN_SIGN_IN_SUCCESS:
            return {
                ...state,
                token: action.token,
            };
        default:
            return state
    }
}