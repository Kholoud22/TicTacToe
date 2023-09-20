<template>
  <div class="row">
    <h1 class="display-4">Players</h1>
    <form @submit.prevent="createPlayers">
      <div class="container">
        <div class="row">
          <div class="col-md-6 col-xs-12">
            <h6 class="display-6">Player X</h6>
            <div class="mb-3">
              <label for="username" class="form-label">Username:</label>
              <input type="text" class="form-control" id="usernameX" v-model="playerXUsername" />
            </div>

          </div>
          <div class="col-md-6 col-xs-12">
            <h6 class="display-6">Player O</h6>
            <div class="mb-3">
              <label for="username" class="form-label">Username:</label>
              <input type="text" class="form-control" id="usernameO" v-model="playerOUsername" />
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
      playerOUsername: ''
    };
  },
  methods: {
    async createPlayers(){
      try {
        let players = {
          playerXUsername: this.playerXUsername,
          playerOUsername: this.playerOUsername
        }
        this.gameId = await apiService.createPlayers(players);
        const router = this.$router;
        router.push(`game/${this.gameId}`);
        console.log(this.gameId);
      } catch (error) {
        console.error('Error loading game details:', error);
      }
    }
  }
}
</script>

