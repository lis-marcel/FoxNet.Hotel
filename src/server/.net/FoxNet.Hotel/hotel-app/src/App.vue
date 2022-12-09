<script setup lang="ts">
import { RouterLink, RouterView } from "vue-router";
import Menu from "./components/Menu.vue";
</script>

<template>
  <Menu />

  <router-view />
</template>