<template>
    <div class="home">
        {{ msg }}
        testng heref
        <img alt="Vue logo" src="../assets/logo.png" />
        <HelloWorld msg="Welcome to Your Vue.js App" />
    </div>
</template>

<script>
import axios from 'axios';
import HelloWorld from '@/components/HelloWorld.vue';

export default {
    name: 'home',
    components: {
        HelloWorld
    },
    data() {
        return { msg: '' };
    },
    created() {
        axios.get('http://192.168.1.16:7001/api').then(res => {
            this.msg = res.data.result;
        });
    }
};
</script>
