import { createRouter, createWebHistory, RouteRecordRaw } from "vue-router";
import Auth from "../pages/authentication/authentication.vue";
import Dashboard from "../pages/dashboard/dashboard.vue";

const routes: Array<RouteRecordRaw> = [
  {
    path: "/",
    redirect: "/auth",
  },
  {
    path: "/auth",
    name: "auth",
    component: Auth,
    meta: { requiresUnauth: true },
  },
  {
    path: "/dashboard",
    name: "dashboard",
    component: Dashboard,
    meta: { requiresAuth: true },
  },
  {
    path: "/:catchAll(.*)",
    redirect: "/auth",
  },
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

router.beforeEach((to, _, next) => {
  const token = localStorage.getItem("access_token");

  if (to.meta.requiresAuth && !token) {
    next("/login");
  }
  if (to.meta.requiresUnauth && token) {
    next("/dashboard");
  } else {
    next();
  }
});

export default router;
