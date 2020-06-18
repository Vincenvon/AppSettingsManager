import {
    HISTORY_READ_START,
    HISTORY_READ_SUCCESS,
    HISTORY_READ_FAILED,
} from '../actions/history';

const initialState = {
    data: {},
    isLoading: false,
};

export const history = (state = initialState, action) => {
    switch (action.type) {
        case HISTORY_READ_START:
            return {
                ...state,
                isLoading: true,
            };
        case HISTORY_READ_SUCCESS:
            return {
                ...state,
                isLoading: false,
                data: action.data,
            };
        case HISTORY_READ_FAILED:
            return {
                ...state,
                isLoading: false,
            };
        default:
            return state
    }
}