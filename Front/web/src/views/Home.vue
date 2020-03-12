<template>
  <div>
    <h2>Homepage</h2>
    <div v-for="user in users" :key="user"><span>{{ user.userName }}</span>  <span>{{ user.id }}</span>  <span>{{ user.email }}</span></div>
  </div>
</template>

<script>
// @ is an alias to /src
//import HelloWorld from '@/components/HelloWorld.vue'
import axios from "axios";
export default {
  name: 'Home',
  data: function() {
    return {
      err: "",
      users: []
    };
  },
  created: function() {
    axios
      .get("https://localhost:32768/api/Accounts")
      .then(result => {
        console.log(result);
        this.users = result.data.users;
      })
      .catch(err => {
        this.err = err;
      });
  },
  components: {
    //HelloWorld
  }
}
</script>
