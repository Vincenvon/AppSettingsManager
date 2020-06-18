import { all, call, put, takeEvery } from 'redux-saga/effects';
import { apis } from 'root/apis';
import { historyReadFailed, historyReadSuccess } from '../actionCreators/history';
import { HISTORY_READ_START } from '../actions/history';

function* readStart() {
    try {
        const { data } = yield call(apis.history.read);
        yield put(historyReadSuccess({ data }));
    } catch (error) {
        yield put(historyReadFailed({ error }));
    }
}

function* history() {
    yield all([
        takeEvery(HISTORY_READ_START, readStart),
    ]);
}

export default history;