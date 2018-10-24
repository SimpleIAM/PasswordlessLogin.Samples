<template>
    <div>
        <h2>Home</h2>
        <div>
            Protected Message: {{message}}
        </div>
    </div>
</template>

<script>
    import Vue from 'vue';
    import api from '../../api.js';

    export default Vue.extend({
        data() {
            return {
                message: '',
            };
        },
        beforeMount() {
            api.tryToGetProtectedInfoButDontRedirectIfUnauthenticated().then(data => {
                this.message = data.message;
            }).catch(err => {
                if (typeof (err.response.status) !== 'undefined' && err.response.status == 401) {
                    this.message = 'Please sign in to see the message.';
                }
                else {
                    this.message = err.message ? err.message : 'An error occurred';
                }
            });
        }
    });
</script>

<style lang="scss">
    
</style>
