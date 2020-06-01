import React from 'react';
import ReactDOM from 'react-dom';
import { Provider } from 'react-redux';
import Layout from './layout';
import { store } from './redux';

const render = () => {
    ReactDOM.render(
        <Provider store={store}>
            <Layout />
        </Provider>,
        document.getElementById('application'),
    );
}

document.addEventListener('DOMContentLoaded', function () {
    render();
});
