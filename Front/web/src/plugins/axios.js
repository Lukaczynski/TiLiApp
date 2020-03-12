"use strict";

import Vue from 'vue';
import axios from "axios";
//let token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJzdHJpbmciLCJqdGkiOiJmMzJhN2ZjZC1iZmM1LTRhMTktOTYzNi0yNjA2ODM4MWY5NDEiLCJpYXQiOjE1ODM3MzQyNzksInJvbCI6ImFwaV9hY2Nlc3MiLCJpZCI6IjExOGY1NWVkLTQ2NTMtNDI4YS05N2ZlLTZhYTNkYzUyODhjOCIsIm5iZiI6MTU4MzczNDI3OSwiZXhwIjoxNTgzNzQxNDc5LCJpc3MiOiJ3ZWJBcGkiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjUwMDAvIn0.j7tB5uxogbWy11uPU7K5TJwsZcz4JbAsLO311kfPXm8"
// Full config:  https://github.com/axios/axios#request-config
//axios.defaults.baseURL = process.env.baseURL || process.env.apiUrl || 'https://localhost:32768/';
//axios.defaults.headers.common['Authorization'] = {Authorization: `Bearer ${token}`};
// axios.defaults.headers.post['Content-Type'] = 'application/x-www-form-urlencoded';
let config = {
  // baseURL: process.env.baseURL || process.env.apiUrl || ""
  // timeout: 60 * 1000, // Timeout
  //withCredentials: true, // Check cross-site Access-Control
};

const _axios = axios.create(config);
_axios.interceptors.response.use(function (response){
  console.log("response: ",response)
  
})
_axios.interceptors.request.use(
  function(config) {
    // Do something before request is sent
    return config;
  },
  function(error) {
    // Do something with request error
    console.log("Error: ",error);
    return Promise.reject(error);
  }
);

// Add a response interceptor
_axios.interceptors.response.use(
  function(response) {
    // Do something with response data
    return response;
  },
  function(error) {
    // Do something with response error
    return Promise.reject(error);
  }
);

Plugin.install = function(Vue) {
  Vue.axios = _axios;
  window.axios = _axios;
  Object.defineProperties(Vue.prototype, {
    axios: {
      get() {
        return _axios;
      }
    },
    $axios: {
      get() {
        return _axios;
      }
    },
  });
};

Vue.use(Plugin)

export default Plugin;
