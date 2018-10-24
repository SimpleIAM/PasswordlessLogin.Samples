<template>
    <div v-if="initializationFailed">
        Initialization failed
    </div>
    <div v-else-if="!initialized">
        Loading...
    </div>
    <div v-else id="app" class="app">
        <h1>Vue App</h1>
        <div class="menu">
            <router-link to="/">Home</router-link>
            <router-link v-if="canViewProfile" to="/myaccount">My Account</router-link>
            <router-link v-if="!signedIn" to="/signin">Sign In</router-link>
            <router-link v-if="!signedIn" to="/register">Register</router-link>
            <router-link v-if="signedIn" to="/signout">Sign Out</router-link>
        </div>
        <router-view></router-view>
    </div>
</template>

<script>
    import Vue from 'vue';
    import { mapGetters } from 'vuex';

    export default Vue.extend({
        data() {
            return {
            };
        },
        computed: {
            ...mapGetters([
                'initializationFailed',
                'initialized',
                'canViewProfile',
                'signedIn'
            ])
        },
    });
</script>

<style lang="scss">
    .app {
        max-width: 900px;
        margin: 0 auto;
    }
    .menu {
        display: flex;
    }
    .menu a {
        margin: 10px;       
    }
</style>
