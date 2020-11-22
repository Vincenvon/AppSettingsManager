import { connectRouter } from 'connected-react-router';
import { combineReducers } from 'redux';
import { history } from './history';
import { login } from './login';
import { settings } from './settings';

const getAppReducer = historyRouter => combineReducers({
    settings,
    history,
    login,
    router: connectRouter(historyRouter),
})

export default getAppReducer;
