import React from 'react';
import ReactDOM from 'react-dom';
import Layout from './layout';

const render = () => {
    ReactDOM.render(
        <Layout />,
        document.getElementById('application'),
    );
}

document.addEventListener('DOMContentLoaded', function () {
    render();
});
