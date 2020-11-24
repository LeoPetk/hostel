import axios from "axios";

axios.defaults.baseURL = "https://localhost:44376/api/";
axios.interceptors.request.use((configuration) => {
  const token = localStorage.getItem("access_token");
  if (token) {
    configuration.headers = { Authorization: "Bearer " + " " + token };
  }
  return configuration;
});

export default axios;
