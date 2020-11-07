import { all, call, put, takeEvery } from 'redux-saga/effects';
import { apis } from 'root/apis';
import { loginSignInSuccess, loginSignInFailed } from '../actionCreators/login';
import { LOGIN_SIGN_IN_START, LOGIN_SIGN_IN_SUCCESS } from '../actions/login';
import { push } from 'connected-react-router';

function* watchSignIn({ login }) {
    try {
        const object = yield call(apis.login.signIn, login);
        const { accessToken } = object.data;
        yield put(loginSignInSuccess({ token: accessToken }));
    } catch (error) {
        yield put(loginSignInFailed({ error }));
    }
}

function* watchSignInSuccess({ token }) {
    window.localStorage.setItem('token', token);
    yield put(push('/'));
}

function* login() {
    yield all([
        takeEvery(LOGIN_SIGN_IN_START, watchSignIn),
        takeEvery(LOGIN_SIGN_IN_SUCCESS, watchSignInSuccess)
    ]);
}

export default login;