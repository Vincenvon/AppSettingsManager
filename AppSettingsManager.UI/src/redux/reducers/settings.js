import {
    SETTINGS_READ_FAILED,
    SETTINGS_READ_START,
    SETTINGS_READ_SUCCESS,
    SETTINGS_UPDATE_FAILED,
    SETTINGS_UPDATE_START,
    SETTINGS_UPDATE_SUCCESS,
    SETTINGS_JSON_VALUE_CHANGED
} from '../actions/settings';

const initialState = {
    data: {},
    isLoading: false,
};

export const settings = (state = initialState, action) => {
    switch (action.type) {
        case SETTINGS_JSON_VALUE_CHANGED:
            return {
                ...state,
                data: {
                    json: action.value,
                },
            };
        case SETTINGS_UPDATE_START:
        case SETTINGS_READ_START:
            return {
                ...state,
                isLoading: true,
            };
        case SETTINGS_READ_SUCCESS:
        case SETTINGS_UPDATE_SUCCESS:
            return {
                ...state,
                isLoading: false,
                data: action.data,
            };
        case SETTINGS_READ_FAILED:
        case SETTINGS_UPDATE_FAILED:
            return {
                ...state,
                isLoading: false,
            };
        default:
            return state
    }
}