import { createRouter, createWebHistory } from 'vue-router';
import AddPlayer from '../components/Players.vue';
import TicTacToe from '../components/TicTacToe.vue';
import ErrorPage from '../components/ErrorPage.vue';

const routes = [
  {
    path: '/',
    component: AddPlayer,
  },
  {
    path: '/game/:id',
    name:'TicTacToe',
    component: TicTacToe,
    props: true
  },
  {
    path: '/:catchAll(.*)*',
    name: 'ErrorPage',
    component: ErrorPage
  }
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router;
