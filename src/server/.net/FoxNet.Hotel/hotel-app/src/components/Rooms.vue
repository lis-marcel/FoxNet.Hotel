<template>
    <div>
        <h1>Lisi hotel</h1>
        <button @click="fetchRooms">fetch data</button>
    </div>
</template>

<script lang="ts">
import Consts from "../consts";
import { ref, computed, onMounted } from "vue"; 
export default {
    data() {
        return {
            rooms: {
                number: null,
                bedsAmount: null,
                price: null,
                bathroom: null,
                booked: null
            }
        }
    },

    methods: {
        fetchRooms: function() {
            fetch(Consts.API.concat('rooms'), {
                headers: {
                    'Content-Type': 'application/json',
                    'Access-Control-Allow-Methods': 'GET',
                    'Access-Control-Allow-Origin': 'https://localhost:5001/api',
                }
            })
            .then(response => response.json())
            .then((data) => data.rooms)
            .catch(error => console.error)
        }
    }
}

</script>