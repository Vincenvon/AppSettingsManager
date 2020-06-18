import { HISTORY_READ_FAILED, HISTORY_READ_START, HISTORY_READ_SUCCESS } from '../actions/history';

export const historyReadStart = () => ({
    type: HISTORY_READ_START,
});

export const historyReadFailed = ({ error }) => ({
    type: HISTORY_READ_FAILED,
    error,
});

export const historyReadSuccess = ({ data }) => ({
    type: HISTORY_READ_SUCCESS,
    data
});
