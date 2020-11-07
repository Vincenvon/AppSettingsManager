import { createHashHistory } from 'history'
import { applyMiddleware, createStore, compose } from 'redux'
import createSagaMiddleware from 'redux-saga'
import getAppReducer from './reducers'
import { routerMiddleware } from 'connected-react-router'
import rootSaga from './sagas'

export const history = createHashHistory();

const sagaMiddleware = createSagaMiddleware();

export const configureStore = () => {
    const middlewares = [sagaMiddleware, routerMiddleware(history)];
    const rootReducer = getAppReducer(history);
    const store = createStore(rootReducer, applyMiddleware(...middlewares));

    sagaMiddleware.run(rootSaga);

    return { store };
};
