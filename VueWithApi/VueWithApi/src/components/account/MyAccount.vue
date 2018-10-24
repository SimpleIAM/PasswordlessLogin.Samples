<template>
    <div>
        <h2>My Account</h2>
        <div>
            Username: {{user.username}}
        </div>
        <div>
            Email: {{user.email}}
        </div>
        <router-link to="/setpassword">Set or Change Password</router-link>
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
                'user',
            ])
        },
    });
</script>

<style lang="scss">
    
</style>
