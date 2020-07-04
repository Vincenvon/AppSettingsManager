import { all } from 'redux-saga/effects';
import history from './history';
import settings from './settings';

export default function* rootSaga() {
    yield all([
        settings(),
        history(),
    ]);
};