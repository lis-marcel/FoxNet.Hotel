<template>
    <nav class="navbar navbar-expand-lg navbar-light bg-light">
        <router-link to="/rooms" class="navbar-brand">FN-Hotel</router-link>
        <ul class="navbar-nav">
            <li class="nav-item active">
                <router-link to='/cart' class="nav-link">Cart</router-link>
            </li>
            <li class="nav-item">
                <router-link to='/account' class="nav-link">Account</router-link>
            </li>
            <li class="nav-item">
                <a class="nav-link" href="#">Bookings</a>
            </li>
        </ul>
    </nav>
</template>

<script lang="ts">
    export default {}
</script>