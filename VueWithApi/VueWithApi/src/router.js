import Vue from 'vue';
import VueRouter from 'vue-router';
import Home from './components/app/Home.vue';
import SignIn from './components/auth/SignIn.vue';
import SignOut from './components/auth/SignOut.vue';
import Register from './components/auth/Register.vue';
import ForgotPassword from './components/auth/ForgotPassword.vue';
import MyAccount from './components/account/MyAccount.vue';
import SetPassword from './components/account/SetPassword.vue';

Vue.use(VueRouter);

const router = new VueRouter({
    routes: [
        {
            name: 'Home',
            path: '/',
            component: Home,
        },
        {
            name: 'SignIn',
            path: '/signin',
            component: SignIn,
        },
        {
            name: 'SignOut',
            path: '/signout',
            component: SignOut,
        },
        {
            name: 'Register',
            path: '/register',
            component: Register,
        },
        {
            name: 'ForgotPassword',
            path: '/forgotpassword',
            component: ForgotPassword,
        },
        {
            name: 'MyAccount',
            path: '/myaccount',
            component: MyAccount,
        },
        {
            name: 'SetPassword',
            path: '/setpassword',
            component: SetPassword,
        },
    ],
    mode: 'history'
});

export default router;