<template>
  <div class="container">
    <div class="header">
      <div class="empty"></div>
      <div class="header-content">
        <h1>Welcome to Hostel</h1>
      </div>
      <div class="form-content">
        <login-form></login-form>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import { defineComponent, ref } from "vue";
import loginForm from "../../components/login/login.vue";

export default defineComponent({
  components: {
    loginForm,
  },
});
</script>

<style lang="scss" scoped>
@import "../../styles/variables.scss";

.container {
  display: flex;
  background-color: $auth-background;
  height: 100vh;
  justify-content: center;

  .header {
    display: flex;
    justify-content: center;
    flex-direction: column;

    .header-content {
      display: flex;
      justify-content: center;
    }

    .empty {
      flex: 1;
    }
    .form-content {
      flex: 3;
    }
  }
  h1 {
    color: white;
  }
}
</style>
