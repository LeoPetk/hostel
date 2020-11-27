<template>
  <div class="app-wrapper">
    <div class="nav-wrapper">
      <div class="nav">
        <NavBar @expand="expandStatus" />
      </div>
    </div>
    <div class="body-wrapper">
      <div class="menu">
        <Menu :shouldExpand="shouldExpand" />
      </div>
      <div :class="shouldExpand ? 'content' : 'content-expand'">
        <router-view></router-view>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import { ref } from "vue";
import NavBar from "../../components/dashboard/navbar/navbar.vue";
import Menu from "../../components/dashboard/bodyContent/menu/menu.vue";

export default {
  name: "dashboard",
  components: {
    NavBar,
    Menu,
  },
  setup() {
    const shouldExpand = ref(false);
    const expandStatus = (expandValue: boolean) => {
      shouldExpand.value = expandValue;
    };

    return { expandStatus, shouldExpand };
  },
};
</script>

<style lang="scss" scoped>
@import "../../styles/variables.scss";

.app-wrapper {
  display: flex;
  flex-direction: column;
  overflow: hidden;
  height: 100vh;

  .nav-wrapper {
    display: flex;
    height: 60px;
    width: 100%;

    .nav {
      height: inherit;
      flex: 1;
    }
  }
  .body-wrapper {
    display: flex;
    width: 100%;
    height: calc(100vh - 60px);
    background-color: $dashboard-background;

    .menu {
      flex: 1;
      background-color: $auth-background;
    }

    .content {
      flex: 5;
    }

    .content-expand {
      flex: 20;
    }
  }
}
</style>
