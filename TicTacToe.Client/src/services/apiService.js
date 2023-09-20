/* eslint-disable no-useless-catch */

import axios from 'axios';

const apiClient = axios.create({
  baseURL: 'http://localhost:5079/api/games',
  headers: {
    'Content-Type': 'application/json',
  },
});

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
