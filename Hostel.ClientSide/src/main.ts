import { createApp } from "vue";
import App from "./App.vue";
import router from "./router";
import store from "./store";
import axiosConfig from "./shared/baseHttp";
import "font-awesome/css/font-awesome.min.css";

axiosConfig;

const app = createApp(App);

app.component(
  "VueFontawesome",
  require("vue-fontawesome-icon/VueFontawesome.vue").default
);
app.use(store);
app.use(router).mount("#app");
