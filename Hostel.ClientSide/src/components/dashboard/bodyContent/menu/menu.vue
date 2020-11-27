<template>
  <div class="menu-wrapper">
    <div
      :class="menuItem.class"
      v-for="menuItem in menuItems"
      :key="menuItem.id"
    >
      <vue-fontawesome
        @click="menuItem.callback"
        :icon="menuItem.icon"
        :size="menuItem.size"
        :color="menuItem.color"
        :id="menuItem.id"
      ></vue-fontawesome>

      <label v-if="props.shouldExpand" :for="menuItem.id">
        {{ menuItem.name }}
      </label>
    </div>
  </div>
</template>

<script lang="ts">
import { reactive } from "vue";
import MenuItem from "../../../../shared/interfaces/menuItem";
import router from "@/router";

export default {
  name: "Menu",
  props: ["shouldExpand"],
  setup(props: any) {
    const menuItems: MenuItem[] = [
      {
        icon: "home fa-fw",
        size: 2,
        color: "lightgray",
        id: "home",
        name: "Rooms",
        callback: () => router.replace("/app/rooms"),
      },
      {
        icon: "calendar fa-fw",
        size: 2,
        color: "lightgray",
        id: "calendar",
        name: "Calendar",
        callback: () => router.replace("/app/calendar"),
      },
      {
        icon: "desktop fa-fw",
        size: 2,
        color: "lightgray",
        id: "board",
        name: "Crew Board",
        callback: () => router.replace("/app/board"),
      },
      {
        icon: "bar-chart fa-fw",
        size: 2,
        color: "lightgray",
        id: "statistic",
        name: "Statistic",
        callback: () => router.replace("/app/statistic"),
      },
      {
        icon: "file fa-fw",
        size: 2,
        color: "lightgray",
        id: "helpdesk",
        name: "Helpdesk",
        callback: () => router.replace("/app/help"),
      },
      {
        icon: "cog fa-fw",
        size: 2,
        color: "lightgray",
        id: "settings",
        class: "settings",
        name: "Settings",
        callback: () => router.replace("/app/setting"),
      },
    ];

    return { props, menuItems };
  },
};
</script>

<style lang="scss" scoped>
@import "../../../../styles/variables.scss";

.menu-wrapper {
  display: flex;
  height: calc(100vh - 100px);
  width: 100%;
  flex-direction: column;
  margin: $margin-20 0px $margin-20 $margin-20;

  div {
    margin-bottom: 20px;
    display: flex;
    align-items: baseline;

    label {
      margin-left: 60px;
      font-size: 23px;
      color: lightgray;
    }

    i {
      cursor: pointer;
      &:hover {
        color: white !important;
      }
    }
  }

  .settings {
    margin-bottom: 0px;
    margin-top: auto;
  }
}
</style>
