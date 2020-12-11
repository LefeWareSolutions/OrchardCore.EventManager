import axios from 'axios'; 
const instance = axios.create({
    baseURL: process.env.API_URL
     
});

instance.interceptors.request.use(request => { 
    return request
})

instance.interceptors.response.use(response => { 
    return response
})

// instance.defaults.headers.common['idLanguage'] = langId;

export default instance;

