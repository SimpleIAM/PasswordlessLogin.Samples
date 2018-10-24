<template>
    <div class="focusBox">
        <h2>Forgot Password</h2>
        <div class="forgotPassword">
            <form @submit.prevent="submitForm" class="form">
                <div class="field field-stacked form_row">
                    <label class="field_label" for="email">Email</label>
                    <input class="field_element field_element-fullWidth register_email"
                           ref="email"
                           id="email"
                           v-model="email"
                           type="text"
                           placeholder="you@example.com">
                    <span v-if="emailError" class="field_error">{{emailError}}</span>
                </div>

                <div class="field form_row">
                    <button :disabled="!emailIsValid"
                            type="submit"
                            class="field_element field_element-fullWidth field_element-tall forgotPassword_button">
                        Get Password Reset Link
                    </button>
                </div>
                <div class="message message-notice register_message" v-if="message">
                    {{message}}
                </div>
            </form>
        </div>
    </div>
</template>

<script>
    import Vue from 'vue';
    import api from '../../api.js';

    export default {
        data: function () {
            return {
                email: '',
                emailError: '',
                message: ''
            };
        },
        computed: {
            emailIsValid: function () {
                if (this.email.length == 0) {
                    return false;
                }
                var testEl = document.createElement('input');
                testEl.type = 'email';
                testEl.value = this.email;
                return testEl.checkValidity();
            }
        },
        methods: {
            submitForm: function () {
                this.message = "Please wait...";
                api.sendPasswordResetMessage(this.email, '/')
                    .then(data => {
                        this.message = data.message ? data.message : 'Success';
                    })
                    .catch(error => {
                        this.message = error.message ? error.message : 'Something went wrong';
                    });
            }
        },
        mounted: function () {
            this.$nextTick(() => {
                this.$refs.email.focus();
            });
        }
    };
</script>

<style lang="scss">
</style>
