import {
    HISTORY_READ_START,
    HISTORY_READ_SUCCESS,
    HISTORY_READ_FAILED,
    HISTORY_GRID_STATE_CHANGED,
} from '../actions/history';

const initialState = {
    data: {},
    isLoading: false,
    gridState: {
        page: 1,
        pageSize: 20,
        sort: {},
    },
};

export const history = (state = initialState, action) => {
    switch (action.type) {
        case HISTORY_READ_START:
            return {
                ...state,
                isLoading: true,
                gridState: action.gridState,
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
        case HISTORY_GRID_STATE_CHANGED:
            return {
                ...state,
                gridState: action.gridState,
            };
        default:
            return state
    }
}