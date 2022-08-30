import { createRouter, createWebHistory } from "vue-router";
import Rooms from '../components/Rooms.vue';
import Login from '../components/Login.vue';
import Register from '../components/Register.vue';
import Account from '../components/Account.vue';

const routes = [
  { 
    path: '/',
    name: 'Rooms',
    component: Rooms
  },
  { 
    path: '/login',
    name: 'Login',
    component: Login 
  },
  { 
    path: '/register',
    name: 'Register',
    component: Register 
  },
  { 
    path: '/account',
    name: 'Account',
    component: Account 
  },
]

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL), routes
});

export default router;