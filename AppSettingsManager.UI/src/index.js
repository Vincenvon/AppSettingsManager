import React from 'react';
import ReactDOM from 'react-dom';
import { Provider } from 'react-redux';
import Layout from './layout';
import { store } from './redux';
import { HashRouter } from 'react-router-dom';

const render = () => {
    ReactDOM.render(
        <Provider store={store}>
            <HashRouter>
                <Layout />
            </HashRouter>
        </Provider>,
        document.getElementById('application'),
    );
}

document.addEventListener('DOMContentLoaded', function () {
    render();
});
