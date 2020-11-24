<template>
  <div class="form-container">
    <form @submit.prevent="submitForm">
      <div class="empty"></div>
      <div class="content">
        <div>
          <input
            :class="{ 'error-input': !isFormValid.username }"
            id="username"
            type="text"
            placeholder="Username"
            v-model.trim="loginModel.username"
            autocomplete="off"
          />
        </div>
        <div>
          <input
            :class="{ 'error-input': !isFormValid.password }"
            id="password"
            type="password"
            placeholder="Password"
            v-model.trim="loginModel.password"
          />
        </div>
        <div
          class="error"
          v-if="!isFormValid.username || !isFormValid.password"
        >
          <p>Please enter a valid username and password!</p>
        </div>
        <div class="button-container">
          <button>Login</button>
        </div>
      </div>
    </form>
  </div>
</template>

<script>
import { computed, reactive, ref, watch } from "vue";
import axios from "axios";
import router from "@/router";
import useValidation from "../../hooks/formValidation";

export default {
  name: "login-form",
  setup() {
    const loginModel = reactive({
      username: "",
      password: "",
    });

    const isFormValid = reactive({
      username: true,
      password: true,
    });

    const validateToken = async () => {
      const regex = /^[A-Za-z0-9-_=]+\.[A-Za-z0-9-_=]+\.?[A-Za-z0-9-_.+/=]*$/;

      if (regex.test(localStorage.getItem("access_token"))) {
        await router.replace("/dashboard");
      } else {
        localStorage.removeItem("access_token");
        alert("Invalid token");
      }
    };

    const submitForm = async () => {
      isFormValid.username = true;
      isFormValid.password = true;

      const validation = useValidation([
        loginModel.username,
        loginModel.password,
      ]);

      if (validation.includes(false)) {
        isFormValid.username = validation[0];
        isFormValid.password = validation[1];
        return;
      }

      try {
        const response = await axios.post("Authentication/Login", loginModel);
        localStorage.setItem("access_token", response.data);
        await validateToken();
      } catch (error) {
        alert(error);
      }
    };

    return { loginModel, submitForm, isFormValid };
  },
};
</script>

<style lang="scss" scoped>
@import "../../styles/variables.scss";

.error-input {
  border-bottom: 2px solid $error !important;

  &::placeholder {
    color: $error !important;
  }
}
.form-container {
  background-color: $login-form-background;
  border: 2px solid black;
  border-radius: 30px;
  height: 350px;
  width: 300px;

  form {
    display: flex;
    flex-direction: column;
    height: 100%;
    .empty {
      flex: 1;
    }
    .content {
      flex: 2;

      div {
        display: flex;
        justify-content: center;
        height: 30px;
        margin-bottom: 5px;

        input {
          background-color: transparent !important;
          border: none;
          outline: none;
          border-bottom: 2px solid #a7a5a5;
          color: #b3b1b1;

          &::placeholder {
            color: #a7a5a5;
          }
        }
      }

      .error {
        p {
          color: $error;
          margin-top: 10px;
        }
      }

      .button-container {
        margin-top: 10px;
        button {
          background-color: rgba(37, 85, 134, 0.8);
          border-radius: 30px;
          border: 1px solid rgba(22, 53, 83, 0.8);
          color: white;
          width: 120px;
          outline: none;
          cursor: pointer;

          &:hover {
            background-color: rgba(57, 114, 172, 0.8);
          }
        }
      }
    }
  }
}
</style>
