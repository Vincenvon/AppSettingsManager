import axios from 'axios';

export const apis = {
    settings: {
        read: () => axios.get('api/settings'),
        update: json => axios.post('api/settings', json),
    }
};