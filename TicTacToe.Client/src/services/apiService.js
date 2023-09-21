/* eslint-disable no-useless-catch */

import router from '@/routes';
import axios from 'axios';

const apiClient = axios.create({
  baseURL: 'http://localhost:5079/api/games',
  headers: {
    'Content-Type': 'application/json',
  },
});

// Request interceptor
apiClient.interceptors.request.use(
    (config) => {
      return config;
    },
    (error) => {
      router.push({ name: 'ErrorPage' })
      return Promise.reject(error);
    }
  );
  
  // Response interceptor
  apiClient.interceptors.response.use(
    (response) => {
      return response;
    },
    (error) => {
      router.push({ name: 'ErrorPage' })

      return Promise.reject(error);
    }
  );
  

export default {
  async getGameDetails(id) {
    try {
      const response = await apiClient.get(`/${id}`);
      var data = response.data;
      
      if(data.description)
      throw response.data;

      return data;
    } catch (error) {
      throw error;
    }
  },

  async createPlayers({playerXUsername, playerOUsername}) {
    try {
      const response = await apiClient.post('/', {playerXUsername, playerOUsername});
      var data = response.data;
      
      if(data.description)
      throw response.data;

      return data;
    } catch (error) {
      throw error;
    }
  },

  async saveGame({gameId, winnerId}) {
    try {
      const response = await apiClient.put('/save', {gameId, winnerId});
      var data = response.data;

      if(data.description)
      throw response.data;

      return data;
    } catch (error) {
      throw error;
    }
  },

  async createGame({playerXId, playerOId}) {
    try {
      const response = await apiClient.post('/new', {playerXId, playerOId});
      var data = response.data;
      
      if(data.description)
      throw response.data;

      return data;
    } catch (error) {
      throw error;
    }
  },

};
