import axios from 'axios';
import { useState } from 'react';

axios.interceptors.request.use(function (config) {
    const token = window.localStorage.getItem('token', token);
    return {
        ...config, headers: {
            ...config.headers && {},
            authorization: token ? `Bearer ${token}` : undefined
        }
    };
}, function (error) {
    return Promise.reject(error);
});

axios.interceptors.response.use(function (response) {
    return response;
}, function (error) {
    if (error.response.status === 401)
        window.location.href = '#/login';
    return Promise.reject(error);
});


export const apis = {
    settings: {
        read: () => axios.get('api/settings'),
        update: json => axios.post('api/settings', json),
    },

    history: {
        read: gridState => axios.post('api/history', gridState),
    },

    login: {
        signIn: login => axios.post('api/login', login),
    },
}; 