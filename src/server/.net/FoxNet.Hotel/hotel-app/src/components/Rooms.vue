<template>
    <h2>items {{ cartItemsCounter }}</h2>
    
    <div class="card" style="width: 18rem;" v-for="room in Rooms" v-bind:key="room.id">
        <img class="card-img-top" src="..." alt="Card image cap">
        <div class="card-body">
            <h5 class="card-title"> {{ room.number }} </h5>
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

<script lang="ts">
import { useRooms } from "../data/rooms";
import { useCart } from "../composables/useCart";

export default {

    setup(props: any, context: any) {
        const { fetchRooms, Rooms } = useRooms();
        const { addToCart, cartItemsCounter, CartItems } = useCart();

        fetchRooms();

        return {
            Rooms,
            addToCart,
            cartItemsCounter,
        };
    },
}

</script>

<style scoped>
    .card {
        display: inline-block;
        text-align: center;
        margin: 1em;
        padding: 1em;
    }
</style>