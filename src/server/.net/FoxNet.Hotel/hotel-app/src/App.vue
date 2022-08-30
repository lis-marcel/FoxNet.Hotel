<script setup lang="ts">
import { RouterLink, RouterView } from "vue-router";
import Menu from "./components/Menu.vue";
import Login from "./components/Login.vue";
</script>

<template>
  <Menu />

  <router-view />
</template>