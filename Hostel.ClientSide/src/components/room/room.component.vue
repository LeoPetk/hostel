<template>
  <div class="wrapper">
    <div class="room-holder" v-for="room in rooms" :key="room.id">
      {{ room.name }}
    </div>
  </div>
</template>

<script lang="ts">
import { defineComponent, onMounted, ref } from "vue";
import axios from "axios";

export default defineComponent({
  name: "Rooms",
  setup() {
    const rooms = ref();
    onMounted(async () => {
      const response = await axios.get("Room/rooms");
      rooms.value = response.data;
    });

    return { rooms };
  },
});
</script>

<style lang="scss" scoped>
@import "../../styles/variables.scss";

.wrapper {
  height: 100%;
  display: flex;
  flex-wrap: wrap;
  justify-content: space-evenly;
  align-items: flex-start;
  margin: 10px;

  .room-holder {
    cursor: pointer;
    display: flex;
    height: 150px;
    box-shadow: 4px 5px #272627;
    background-color: $auth-background;
    justify-content: center;
    align-items: center;
    color: white;
    margin: 10px;
    flex: 1;

    &:hover {
      background-color: #af71af;
    }
  }
}
</style>
