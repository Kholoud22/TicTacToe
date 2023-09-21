<template>
  <div class="row">
    <h1>Players</h1>
    <form @submit.prevent="createPlayers">
      <div class="container">
        <div class="row">
          <!-- Player X -->
          <div class="col-md-6 col-xs-12">
            <h6>Player X</h6>
            <div class="mb-3">
              <label for="usernameX" class="form-label">Username:</label>
              <input
                type="text"
                class="form-control"
                id="usernameX"
                v-model="playerXUsername"
                required
              />
            </div>
          </div>

          <!-- Player O -->
          <div class="col-md-6 col-xs-12">
            <h6>Player O</h6>
            <div class="mb-3">
              <label for="usernameO" class="form-label">Username:</label>
              <input
                type="text"
                class="form-control"
                id="usernameO"
                v-model="playerOUsername"
                required
              />
            </div>
          </div>
        </div>
      </div>

      <button type="submit" class="btn btn-primary">Submit</button>
    </form>
  </div>
</template>

<script>
import apiService from '../services/apiService';

export default {
  name: 'AddPlayer',
  data() {
    return {
      playerXUsername: '',
      playerOUsername: '',
    };
  },
  methods: {
    async createPlayers() {
      try {
        const players = {
          playerXUsername: this.playerXUsername,
          playerOUsername: this.playerOUsername,
        };

        const gameId  = await apiService.createPlayers(players);

        this.$router.push({ name: 'TicTacToe', params: { id: gameId } });
      } catch (error) {
        console.error('Error creating players:', error);
      }
    },
  },
};
</script>


