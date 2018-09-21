<template>
  <div class="hello">
    <input type="txet" placeholder="请输入文字" v-model="msg" @keypress.enter="enter">
    <p>{{upper}}</p>
  </div>
</template>

<script>
export default {
  data () {
    return {
      msg: 'hello'
    }
  },
  methods:{
    enter () {
      alert(this.msg);
    }
  },
  computed: {
    upper () {
      return this.msg.toUpperCase();
    }
  }
}
</script>

<style scoped>
  input {
    width: 200px;
    height: 20px;
  }
  p {
    color: red;
  }
</style>