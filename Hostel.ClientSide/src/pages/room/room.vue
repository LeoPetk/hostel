<template>
  <div>
    <Rooms />
  </div>
</template>

<script lang="ts">
import { defineComponent, reactive } from "vue";
import Rooms from "../../components/room/room.component.vue";

export default defineComponent({
  name: "Room",
  components: {
    Rooms,
  },
});
</script>

<style scoped>
div {
  height: 100%;
}
</style>
