import { HISTORY_READ_FAILED, HISTORY_READ_START, HISTORY_READ_SUCCESS, HISTORY_GRID_STATE_CHANGED } from '../actions/history';

export const historyReadStart = ({ gridState }) => ({
    type: HISTORY_READ_START,
    gridState,
});

export const historyReadFailed = ({ error }) => ({
    type: HISTORY_READ_FAILED,
    error,
});

export const historyReadSuccess = ({ data }) => ({
    type: HISTORY_READ_SUCCESS,
    data
});

export const historyGridStateChanged = ({ gridState }) => ({
    type: HISTORY_GRID_STATE_CHANGED,
    gridState,
});
