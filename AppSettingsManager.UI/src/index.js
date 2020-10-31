import React from 'react';
import ReactDOM from 'react-dom';
import { Provider } from 'react-redux';
import Layout from './layout';
import { store, history } from './redux';
import { ConnectedRouter } from 'connected-react-router'

const render = () => {
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
