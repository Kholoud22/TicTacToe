<template>
    <div class="game-board">
      <div v-for="cell in cells" :key="cell.id" @click="handleCellClick(cell)">
        {{ cell.value }}
      </div>
    </div>
  </template>
  
  <script>
  export default {
    name: 'GameBoard',
    props: {
      cells: Array,
      winner: String,
      details: Object,
    },
    methods: {
      handleCellClick(cell) {
        if (!cell.value && !this.winner && this.details.status !== 'Completed') {
          this.$emit('makeMove', cell);
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
  