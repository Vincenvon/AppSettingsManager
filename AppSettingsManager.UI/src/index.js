import React from 'react';
import ReactDOM from 'react-dom';
import { Provider } from 'react-redux';
import Layout from './layout';
import { configureStore, history } from './redux';
import { ConnectedRouter } from 'connected-react-router'

const render = () => {
    const { store } = configureStore();

    ReactDOM.render(
        <Provider store={store}>
            <ConnectedRouter history={history}>
                <Layout />
            </ConnectedRouter>
        </Provider>,
        document.getElementById('application'),
    );
}

document.addEventListener('DOMContentLoaded', function () {
    render();
});
