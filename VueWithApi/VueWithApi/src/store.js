import Vue from 'vue';
import Vuex from 'vuex';
import api from './api.js';

Vue.use(Vuex);

export default new Vuex.Store({
    state: {
        initializationFailed: false,
        initialized: false,
        minimumPasswordStrength: 30,
        minimumPasswordLength: 8,
        permissions: [],
        user: {
            username: '?',
            email: '?',
            isAuthenticated: false
        },
    },
    getters: {
        initializationFailed: state => state.initializationFailed,
        initialized: state => state.initialized,
        minimumPasswordStrength: state => state.minimumPasswordStrength,        
        minimumPasswordLength: state => state.minimumPasswordLength,        
        signedIn: state => typeof(state.user.isAuthenticated) !== 'undefined' && state.user.isAuthenticated === true ? true : false,
        user: state => state.user,
        canViewProfile: state => state.permissions.includes('view-profile'),
        canSetPassword: state => state.permissions.includes('set-password'),
    },
    actions: {
        initialize(context) {
            return new Promise((resolve, reject) => {
                api.getAppInfo().then(data => {
                    context.commit('setAppInfo', data);
                    resolve();
                }).catch(err => {
                    console.log(err);
                    context.commit('fatalError');
                    reject('Initialization failed');
                });
            });
        }        
    },
    mutations: {
        setAppInfo(state, payload) {
            state.initialized = true;
            state.minimumPasswordStrength = payload.minimumPasswordStrength;
            state.minimumPasswordLength = payload.minimumPasswordLength;
            
            state.user = payload.user;
            state.permissions = payload.permissions;
        },
        fatalError(state) {
            state.initializationFailed = true;
        },
    }
});