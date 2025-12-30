function authFetch(url, options = {}) {
    const token = localStorage.getItem('jwt');

    options.headers = {
        ...options.headers,
        'Authorization': 'Bearer ' + token
    };

    return fetch(url, options);
}
