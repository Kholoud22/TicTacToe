<template>
    <div class="row">
      <h6 class="mt-2 text-start col col-xs-12">{{ playerType }} - ({{ username }})</h6>
      <input
        type="text"
        style="width: auto;"
        class="form-control col-auto col-xs-12"
        :id="id"
        :playerType="playerType"
        disabled
        :value="totalWins"
      />
    </div>
  </template>
  
  <script>
  export default {
    name: 'PlayerInfo',
    props: {
      username:String,
      id: String,
      totalWins: Number,
      playerType:String
    },
  };
  </script>
  