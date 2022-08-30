import { createRouter, createWebHistory } from "vue-router";
import Login from '../components/Login.vue';
import Rooms from '../components/Rooms.vue';
import Register from '../components/Register.vue';
import Account from '../components/Account.vue';

const routes = [
  { 
    path: '/',
    name: 'Login',
    component: Login 
  },
  { 
    path: '/rooms',
    name: 'Rooms',
    component: Rooms
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