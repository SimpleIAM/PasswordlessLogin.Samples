<template>
    <div>
        <h2>Sign Out Page</h2>
        <p>{{message}}</p>
    </div>
</template>

<script>
    import Vue from 'vue';
    import api from '../../api.js';

    export default {
        data: function () {
            return {
                message: 'Signing out...',
            };
        },
        beforeMount: function () {
            api.signOut().then(data => {
                this.$store.dispatch('initialize').then(() => {
                    this.message = "You have been signed out";
                }).catch(() => {
                    this.message = "You have been signed out but some data was not cleared. Please close your browser tab.";
                });
            }).catch(err => {
                this.message = "Sign out failed";
            });
        }
    };
</script>

<style lang="scss">
</style>
