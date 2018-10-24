<template>
    <div class="passwordStrengthMeter">
        <meter class="passwordStrengthMeter_meter" :value="strengthInBits" min="0" :low="minStrengthInBits" :high="minStrengthInBits * 1.5" :optimum="minStrengthInBits * 2" :max="minStrengthInBits * 2" :title="strengthInBits + ' bits'">
            {{strengthInBits}} bits
        </meter>
        <div class="warning" v-show="warning">{{ warning }}</div>
        <div class="notification" v-show="suggestions.length > 0">
            <ul class="passwordStrengthMeter_suggestions">
                <li class="" v-for="item in suggestions">{{ item }}</li>
            </ul>
        </div>
    </div>
</template>

<script>
    import Vue from 'vue';
    import zxcvbn from 'zxcvbn';
    import { mapGetters } from "vuex";

    export default Vue.extend({
        props: {
            password: String,
            minStrengthInBits: {
                type: Number,
                default: 30
            }
        },
        data() {
            return {
                zxcvbnInfo: {},
            };
        },
        computed: {
            warning() {
                return this.zxcvbnInfo.feedback ? this.zxcvbnInfo.feedback.warning : null;
            },
            suggestions() {
                return this.zxcvbnInfo.feedback ? this.zxcvbnInfo.feedback.suggestions : [];
            },
            strengthInBits() {
                return this.zxcvbnInfo.guesses ? Math.floor(Math.log2(this.zxcvbnInfo.guesses)) : 0;
            },
        },
        watch: {
            password: function (val) {
                this.zxcvbnInfo = zxcvbn(this.password);
            },
        },
    });
</script>

<style lang="scss">
    .passwordStrengthMeter_meter {
        width: 100%;
        margin: 5px 0;
    }

    .passwordStrengthMeter_suggestions {
        margin: 0;
        padding: 0 0 0 15px;
    }
</style>
