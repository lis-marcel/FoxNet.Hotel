<template>
    <div>
        <button @click="LogData">lisi hotel</button>
    </div>
</template>

<script lang="ts">
import Consts from "../consts";

export default {
    methods: {
        LogData() {
            console.log(Consts.API);
        }
    }
}

</script>