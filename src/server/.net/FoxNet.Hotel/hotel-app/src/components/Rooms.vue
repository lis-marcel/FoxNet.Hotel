<template>
    <h1>FN-Rooms</h1><br>

    <div v-for="room in Rooms" v-bind:key="room.id" class="room__container">
        <h2> {{ room.number }} </h2>
    </div>

</template>

<script lang="ts">
import Consts from "../consts";
export default {

    data() {
        name: 'Rooms'
        return {
            Rooms: []
        }
    },

    methods: {
        fetchData: function() {
            const URI = Consts.API.concat('rooms');
            const headers = {
                'Content-Type': 'application/json',
                'Access-Control-Allow-Methods': 'GET',
                'Access-Control-Allow-Origin': `${URI}`
            }

            fetch(URI, { headers })
            .then(response => response.json())
            .then((data) => (this.Rooms = data))
            .catch(error => console.log(error));
        }
    },

    mounted() {
        this.fetchData();
    }

}

</script>

<style scoped>
    .room__container {
        text-align: center;
        background-color: rgb(133, 133, 133);
        margin: 1em;
        padding: 1em;
    }
</style>