import { all, call, put, takeEvery } from 'redux-saga/effects';
import { apis } from 'root/apis';
import { historyReadFailed, historyReadStart, historyReadSuccess } from '../actionCreators/history';
import { HISTORY_GRID_STATE_CHANGED, HISTORY_READ_START } from '../actions/history';

function* readStart({ gridState }) {
    try {
        const { data } = yield call(apis.history.read, gridState);
        yield put(historyReadSuccess({ data }));
    } catch (error) {
        yield put(historyReadFailed({ error }));
    }
}

function* watchGridStateChanged({ gridState }) {
    yield put(historyReadStart({ gridState }));
}

function* history() {
    yield all([
        takeEvery(HISTORY_READ_START, readStart),
        takeEvery(HISTORY_GRID_STATE_CHANGED, watchGridStateChanged)
    ]);
}

export default history;