import { createHashHistory } from 'history'
import { applyMiddleware, createStore, compose } from 'redux'
import createSagaMiddleware from 'redux-saga'
import getAppReducer from './reducers'
import { routerMiddleware } from 'connected-react-router'
import rootSaga from './sagas'

export const history = createHashHistory()

const sagaMiddleware = createSagaMiddleware()

export const store = createStore(
    getAppReducer(history),
    compose(applyMiddleware(sagaMiddleware, routerMiddleware))
)

sagaMiddleware.run(rootSaga);
