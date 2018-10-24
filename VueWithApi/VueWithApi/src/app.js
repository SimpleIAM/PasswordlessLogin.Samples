import Vue from 'vue'
import App from './components/app/App.vue'
import store from './store.js';
import router from './router.js';

store.dispatch('initialize').then(() => {

    router.beforeEach((to, from, next) => {
        if (to.name === null) {
            next({ name: 'Home' });
        }
        if (to.name === 'MyAccount' && !store.getters.canViewAccount) {
            next(false);
        }
        if (to.name === 'SetPassword' && !store.getters.canSetPassword) {
            next(false);
        }
        next();
    });

    new Vue({
        el: '#app',
        router,
        store,
        render: h => h(App)
    });

}).catch(err => {
    // application should show an error 
});