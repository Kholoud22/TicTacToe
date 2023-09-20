<template>
    <div class="container">
        <div class="row">
            <div class="col-6 col-xs-12 m-auto">
                <div class="row mb-3">
                    <h6 for="playerX" class="col-lg mt-2 text-start">Player X - {{details.playerXUsername}}</h6>
                    <input type="text" style="width: auto;" class="col-auto form-control" id="playerX" disabled v-model="details.playerXTotalWins" />
                </div>
                
                <div class="row">
                    <h6 for="playerO" class="col-lg mt-2 text-start">Player O - {{details.playerOUsername}}</h6>
                    <input type="text" style="width: auto;" class="col-auto form-control" id="playerO" disabled v-model="details.playerOTotalWins" />
                </div>

            </div>
            <div class="game-board col-6 col-xs-12">
                <div v-for="cell in cells" :key="cell.id" @click="makeMove(cell)">
                    {{ cell.value }}
                </div>
            </div>
        </div>
        <div class="row mt-5">
            <button type="submit" class="col-auto me-5 btn btn-primary" @click="createNewGame">Play Again (same player)</button>
            <button type="submit" class="col-auto btn btn-primary">Play new Game (different player)</button>
        </div>
    </div>
  </template>
  
  <script>
  import apiService from '../services/apiService';

  export default {
    name: 'GameBoard',
    props: {
    id: String
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
        currentPlayer: "X",
        winner: null,
        winnerId:null,
        gameId: this.id,
        details: {}
      };
    },
    mounted(){
    this.getDetails(this.id);
    },
    methods: {
        async getDetails(id){
            this.details = await apiService.getGameDetails(id)
        },
        async saveGame(){
            this.gameId = await apiService.saveGame({gameId: this.id, winnerId: this.winnerId})
        },
        async createNewGame(){
            if(!this.winner)
            await this.saveGame();

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
            this.gameId = await apiService.createGame({playerXId: this.details.playerXId, playerOId: this.details.playerOId});
            this.$router.push({ name: 'gameBoard', params: { id: this.gameId } });

            console.log(this.gameId);
            await this.getDetails(this.gameId);
        },
      makeMove(cell) {
        console.log(this.details)
        if (!cell.value && !this.winner && this.details.status != "Completed") {
          cell.value = this.currentPlayer;
          this.checkWinner();
          this.currentPlayer = this.currentPlayer === "X" ? "O" : "X";
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
          if (
            this.cells[a].value &&
            this.cells[a].value === this.cells[b].value &&
            this.cells[a].value === this.cells[c].value
          ) {
            this.winner = this.cells[a].value;
            this.winnerId = this.winner === "X" ? this.details.playerXId : this.winner === "O" ? this.details.playerOId : null;
            await this.saveGame();
            await this.getDetails(this.gameId);
            break;
          }
        }
      },
    },
  };
  </script>
  
  <style scoped>
  .game-board {
    display: grid;
    grid-template-columns: repeat(3, 100px);
  }
  
  .game-board div {
    width: 100px;
    height: 100px;
    display: flex;
    align-items: center;
    justify-content: center;
    font-size: 2em;
    border: 1px solid #333;
    cursor: pointer;
  }
  </style>
  