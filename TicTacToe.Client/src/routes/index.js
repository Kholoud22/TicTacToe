import { createRouter, createWebHistory } from 'vue-router';
import AddPlayer from '../components/players.vue';
import GameBoard from '../components/gameBoard.vue';
import ErrorPage from '../components/error.vue';

const routes = [
  {
    path: '/',
    component: AddPlayer,
  },
  {
    path: '/game/:id',
    name:'gameBoard',
    component: GameBoard,
    props: true
  },
  {
    path: '/:catchAll(.*)*',
    name: 'errorPage',
    component: ErrorPage
  }
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router;
