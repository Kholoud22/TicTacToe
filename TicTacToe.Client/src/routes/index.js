import { createRouter, createWebHistory } from 'vue-router';
import AddPlayer from '../components/players.vue';
import GameBoard from '../components/gameBoard.vue';

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
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router;
