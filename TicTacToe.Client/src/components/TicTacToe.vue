<template>
    <div class="container">
      <div class="row">
        <div class="col-6 col-xs-12 m-auto">
          <PlayerInfo class="mb-4" :playerType="'Player X'" :id="details.playerXId" :username="details.playerXUsername" :totalWins="details.playerXTotalWins" />
          <PlayerInfo :playerType="'Player O'" :id="details.playerOId" :username="details.playerOUsername" :totalWins="details.playerOTotalWins" />
        </div>
        <div class="col-6 col-xs-12">
          <GameBoard
          :cells="cells"
          :winner="winner"
          :details="details"
          @makeMove="makeMove"
        />
        </div>
        
      </div>
      <div class="row mt-5" v-if="details.status === 'Completed'">
        <button @click="createNewGame()" type="submit" class="col-auto me-5 btn btn-primary">Play Again (same player)</button>
        <button @click="navigateToHomePage()" type="submit" class="col-auto btn btn-primary">Play New Game (different player)</button>
      </div>
    </div>
  </template>
  
  <script>
  import apiService from '../services/apiService';
  import PlayerInfo from './PlayerInfo.vue';
  import GameBoard from './GameBoard.vue';
  
  export default {
    name: 'TicTacToe',
    props: {
      id: String,
    },
    data() {
      return {
        cells: [
          { id: 0, value: null },
          { id: 1, value: null },
          { id: 2, value: null },
          { id: 3, value: null },
          { id: 4, value: null },
          { id: 5, value: null },
          { id: 6, value: null },
          { id: 7, value: null },
          { id: 8, value: null },
        ],
        currentPlayer: 'X',
        winner: null,
        gameId: this.id,
        details: {},
      };
    },
    async mounted() {
      try{
        await this.getDetails(this.id);
      } catch(ex){
        console.log(ex);
      }
    },
    methods: {
      navigateToHomePage(){
            this.$router.push('/');
        },
      async getDetails(id) {
        this.details = await apiService.getGameDetails(id);
      },
      async saveGame() {
        this.gameId = await apiService.saveGame({
          gameId: this.id,
          winnerId: this.winnerId,
        });
      },
      async createNewGame() {
        this.winner = null;
        this.winnerId = null;
        this.cells = [
                { id: 0, value: null },
                { id: 1, value: null },
                { id: 2, value: null },
                { id: 3, value: null },
                { id: 4, value: null },
                { id: 5, value: null },
                { id: 6, value: null },
                { id: 7, value: null },
                { id: 8, value: null },
            ];
        const players = {
          playerXId: this.details.playerXId,
          playerOId: this.details.playerOId,
        };
        this.gameId = await apiService.createGame(players);
        this.$router.push({ name: 'TicTacToe', params: { id: this.gameId } });
        await this.getDetails(this.gameId);
      },
      makeMove(cell) {
        if (!cell.value && !this.winner && this.details.status !== 'Completed') {
          cell.value = this.currentPlayer;
          this.checkWinner();
          this.currentPlayer = this.currentPlayer === 'X' ? 'O' : 'X';
        }
      },
      async checkWinner() {
        const winConditions = [
          [0, 1, 2],
          [3, 4, 5],
          [6, 7, 8],
          [0, 3, 6],
          [1, 4, 7],
          [2, 5, 8],
          [0, 4, 8],
          [2, 4, 6],
        ];
  
        for (const condition of winConditions) {
          const [a, b, c] = condition;
          const isTied = this.cells.every((cell) => cell.value != null);
          if (
            this.cells[a].value &&
            this.cells[a].value === this.cells[b].value &&
            this.cells[a].value === this.cells[c].value
            || isTied
          ) {
            this.winner = isTied ? null : this.cells[a].value;
            this.winnerId =
              this.winner === 'X'
                ? this.details.playerXId
                : this.winner === 'O'
                ? this.details.playerOId
                : null;
            await this.saveGame();
            await this.getDetails(this.gameId);
            break;
          }
        }
      },
    },
    components: {
      PlayerInfo,
      GameBoard,
    },
  };
  </script>
  