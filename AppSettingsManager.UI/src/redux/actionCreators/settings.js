import {
    SETTINGS_READ_START,
    SETTINGS_READ_SUCCESS,
    SETTINGS_READ_FAILED,
    SETTINGS_UPDATE_START,
    SETTINGS_UPDATE_SUCCESS,
    SETTINGS_UPDATE_FAILED,
    SETTINGS_JSON_VALUE_CHANGED,
} from '../actions/settings';

export const settingsReadStart = () => ({
    type: SETTINGS_READ_START
});

export const settingsReadSuccess = ({ data }) => ({
    type: SETTINGS_READ_SUCCESS,
    data,
});

export const settingsReadFailed = ({ error }) => ({
    type: SETTINGS_READ_FAILED,
    error,
});

export const settingsUpdateStart = ({ data }) => ({
    type: SETTINGS_UPDATE_START,
    data,
});

export const settingsUpdateSuccess = ({ data }) => ({
    type: SETTINGS_UPDATE_SUCCESS,
    data,
});

export const settingsUpdateFailed = ({ error }) => ({
    type: SETTINGS_UPDATE_FAILED,
    error,
});

export const settingsValueChanged = ({ value }) => ({
    type: SETTINGS_JSON_VALUE_CHANGED,
    value,
})