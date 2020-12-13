<template>
  <div class="items">
    <div class="expand-btn">
      <vue-fontawesome
        @click="expand"
        icon="bars fa-fw"
        size="2"
        color="lightgray"
      ></vue-fontawesome>
      <label v-if="expandMenu">{{ props.hostel }}</label>
    </div>
    <div :class="expandMenu ? 'user-information' : 'user-information-expand'">
      <div>
        <label for="gravatar">Test user</label>
        <img
          @click="showLogout = !showLogout"
          class="gravatar"
          id="gravatar"
          src="http://www.gravatar.com/avatar/?d=mp"
          alt=""
        />
        <div
          @mouseleave="showLogout = false"
          class="logout-wrapper"
          v-if="showLogout"
        >
          <label class="logout-label" @click="logout">Logout</label>
        </div>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import { onBeforeUnmount, ref } from "vue";
import router from "@/router";

export default {
  name: "NavBar",
  props: ["hostel"],
  setup(props: any, context: any) {
    const expandMenu = ref(false);
    const showLogout = ref(false);
    const expand = () => {
      expandMenu.value = !expandMenu.value;
      context.emit("expand", expandMenu.value);
    };

    const logout = async () => {
      localStorage.removeItem("access_token");
      await router.replace("/login");
    };

    return { expand, expandMenu, logout, showLogout, props };
  },
};
</script>

<style lang="scss" scoped>
@import "../../../styles/variables.scss";

.logout-wrapper {
  position: fixed;
  top: 60px;
  right: 10px;
  height: 50px;
  background-color: white;
  width: 100px;
  justify-content: center;

  &:hover {
    background-color: $auth-background;

    .logout-label {
      color: white;
    }
  }

  .logout-label {
    margin: 0px !important;
    cursor: pointer;
  }
}

.items {
  display: flex;
  height: inherit;

  .expand-btn {
    display: flex;
    flex: 1;
    align-items: center;
    height: inherit;
    background-color: $auth-background;

    i {
      cursor: pointer;
      margin-left: 20px;
      &:hover {
        color: white !important;
      }
    }

    label {
      margin-left: 60px;
      font-size: 30px;
      color: lightgray;
      margin-top: 3px;
      font-weight: bold;
    }
  }

  .user-information-expand {
    flex: 20;
    height: inherit;
    display: flex;
    justify-content: flex-end;
    background-color: $dashboard-background;

    div {
      margin-right: $margin-20;
      height: inherit;
      align-items: center;
      display: flex;

      label {
        margin-right: 30px;
        font-weight: bold;
        color: $font-color;
        font-size: 20px;
      }

      .gravatar {
        height: 50px;
        width: 50px;
        border-radius: 50%;
        cursor: pointer;
      }
    }
  }

  .user-information {
    flex: 5;
    display: flex;
    justify-content: flex-end;
    height: inherit;
    background-color: $dashboard-background;

    div {
      margin-right: $margin-20;
      height: inherit;
      align-items: center;
      display: flex;

      label {
        margin-right: 30px;
        font-weight: bold;
        color: $font-color;
        font-size: 20px;
      }

      .gravatar {
        height: 50px;
        width: 50px;
        border-radius: 50%;
        cursor: pointer;
      }
    }
  }
}
</style>
