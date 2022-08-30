<template>
    <nav class="navbar navbar-expand-lg navbar-light bg-light">
        <router-link to="/" class="navbar-brand">FN-Hotel</router-link>
        <ul class="navbar-nav">
            <li class="nav-item active">
                <a class="nav-link" href="#">Cart</a>
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