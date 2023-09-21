<template>
    <div class="error">
      <h1>Something went wrong</h1>
      <p>it may be wrong url or something else for now please go to home page</p>
      <button @click="navigateToHomePage" type="submit" class="col-auto btn btn-link">home page</button>
    </div>
  </template>
  
  <script>
  export default {
    name:'errorPage',
    methods:{
        navigateToHomePage(){
            this.$router.push('/');
        }
    }
  };
  </script>
  
  <style scoped>
  .error {
    text-align: center;
    padding: 20px;
    background-color: #ffcccc;
    border: 1px solid #ff0000;
    border-radius: 5px;
  }
  </style>
  