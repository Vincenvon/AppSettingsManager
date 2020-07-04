import { all, call, put, takeEvery } from 'redux-saga/effects';
import { apis } from 'root/apis';
import { settingsReadFailed, settingsReadSuccess, settingsUpdateFailed, settingsUpdateSuccess } from '../actionCreators/settings';
import { SETTINGS_READ_START, SETTINGS_UPDATE_START } from '../actions/settings';

function* readStart() {
    try {
        const { data } = yield call(apis.settings.read);
        yield put(settingsReadSuccess({ data }));
    } catch (error) {
        yield put(settingsReadFailed({ error }));
    }
}

function* updateStart({ data }) {
    try {
        const { data: updatedData } = yield call(apis.settings.update, data);
        yield put(settingsUpdateSuccess({ data: updatedData }));
    } catch (error) {
        yield put(settingsUpdateFailed({ error }));
    }
}

function* settings() {
    yield all([
        takeEvery(SETTINGS_READ_START, readStart),
        takeEvery(SETTINGS_UPDATE_START, updateStart),
    ]);
}

export default settings;