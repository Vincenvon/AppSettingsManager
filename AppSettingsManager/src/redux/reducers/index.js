import { combineReducers } from 'redux';
import { settings } from './settings';
import { history } from './history';

const appReducer = combineReducers({
    settings,
    history,
})

export default appReducer;
