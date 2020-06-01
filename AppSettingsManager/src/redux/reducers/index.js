import { combineReducers } from 'redux';
import { settings } from './settings';

const appReducer = combineReducers({
    settings,
})

export default appReducer;
