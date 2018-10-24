<template>
    <div class="focusBox">
        <h2>Set New Password</h2>
        <div class="setPassword">
            <div class="form_row field field-stacked">
                <label class="field_label">New Password</label>
                <input v-model="newPassword" type="password" class="field_element field_element-fullWidth" />
                <PasswordStrengthMeter :minStrengthInBits="minimumPasswordStrength" :password="newPassword"></PasswordStrengthMeter>
            </div>
            <div class="form_row field field-stacked">
                <label class="field_label">Repeat New Password</label>
                <input v-model="confirmPassword" type="password" class="field_element field_element-fullWidth" />
            </div>
            <div class="form_row field">
                <button :disable="!newPassword" @click="setPassword" class="field_element field_element-fullWidth field_element-tall setPassword_button">Set Password</button>
            </div>
            <div class="form_row field">
                <router-link to="/myaccount">Cancel</router-link>
            </div>
            <div v-if="message" class="notification">
                {{message}}
            </div>
        </div>
    </div>
</template>

<script>
    import Vue from 'vue';
    import { mapGetters } from 'vuex';
    import api from '../../api.js';
    import PasswordStrengthMeter from './PasswordStrengthMeter.vue';

    export default Vue.extend({
        data() {
            return {
                newPassword: '',
                confirmPassword: '',
                message: ''
            };
        },
        computed: {
            ...mapGetters([
                'minimumPasswordStrength',
                'minimumPasswordLength',
            ]),
        },
        watch: {
            newPassword: function (val) {
                this.message = '';
            },
            confirmPassword: function (val) {
                this.message = '';
            }
        },
        methods: {
            setPassword() {
                if (this.newPassword !== this.confirmPassword) {
                    this.message = 'Passwords do not match';
                }
                else if (this.newPassword.length < this.minimumPasswordLength) {
                    this.message = 'Password must be at least ' + this.minimumPasswordLength + ' characters long';
                }
                else {
                    api.setPassword(this.newPassword).then(data => {
                        this.$router.push(data.nextUrl ? data.nextUrl : '/');
                    }).catch(err => {
                        this.message = err.message;
                    });
                }
            }
        },
        components: {
            PasswordStrengthMeter
        }
    });
</script>

<style lang="scss">
</style>
