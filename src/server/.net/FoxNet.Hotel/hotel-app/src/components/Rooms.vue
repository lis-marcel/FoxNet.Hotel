<script setup>
    import { ref, watch } from 'vue';
    import { useRooms } from "../composables/useRooms";
    import { useCart } from "../composables/useCart";

    const { Rooms, filtersOptions, fetchFilteredRooms } = useRooms();
    const { addToCart, cartItemsCounter } = useCart();

    watch(filtersOptions, async (oldFiltersOptions, newFiltersOptions) => {
        try {
            fetchFilteredRooms()
        } catch (e) {
            console.error(e);
        }
    });
</script>

<template>
    <div class="container">
        <div class="d-flex align-items-center">
            <label for="first_day" class="p-2">First day: </label>
            <input type="date" name="first_day" v-model="filtersOptions.FirstDay" />

            <label for="last_day" class="p-2">Last day: </label>
            <input type="date" name="last_day" v-model="filtersOptions.LastDay"/>
            <button type="submit" class="m-2 p-2" @click="fetchFilteredRooms()">Search</button>
        </div>
    </div>
    
    <div class="card" style="width: 18rem;" v-for="room in Rooms">
        <img class="card-img-top" src="..." alt="Card image cap">
        <div class="card-body">
            <h5 class="card-title"> {{ room.roomNumber }} </h5>
            <p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
        </div>
        <ul class="list-group list-group-flush">
            <li class="list-group-item">Beds: {{ room.bedsAmount }} </li>
            <li class="list-group-item">Bathroom: {{ room.bathroom }} </li>
            <li class="list-group-item">Price: {{ room.price }}$</li>
        </ul>
        <div class="card-body">
            <button type="button" class="btn btn-outline-success" @click="addToCart(room)">To Cart</button>
        </div>
    </div>

</template>

<style scoped>
    .card {
        display: inline-block;
        text-align: center;
        margin: 1em;
        padding: 1em;
    }
</style>