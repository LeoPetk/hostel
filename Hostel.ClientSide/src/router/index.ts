import { createRouter, createWebHistory, RouteRecordRaw } from "vue-router";
import Auth from "../pages/authentication/authentication.vue";
import Dashboard from "../pages/dashboard/dashboard.vue";
import Room from "../pages/room/room.vue";
import Calendar from "../pages/calendar/calendar.vue";
import Board from "../pages/board/board.vue";
import Helpdesk from "../pages/helpdesk/helpdesk.vue";
import Statistic from "../pages/statistic/statistic.vue";
import Setting from "../pages/setting/setting.vue";

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
    path: "/app",
    name: "dashboard",
    component: Dashboard,
    meta: { requiresAuth: true },
    children: [
      {
        path: "rooms",
        name: "rooms",
        component: Room,
        meta: { requiresAuth: true },
      },
      {
        path: "calendar",
        name: "calendar",
        component: Calendar,
        meta: { requiresAuth: true },
      },
      {
        path: "board",
        name: "board",
        component: Board,
        meta: { requiresAuth: true },
      },
      {
        path: "help",
        name: "helpdesk",
        component: Helpdesk,
        meta: { requiresAuth: true },
      },
      {
        path: "statistic",
        name: "statistic",
        component: Statistic,
        meta: { requiresAuth: true },
      },
      {
        path: "setting",
        name: "setting",
        component: Setting,
        meta: { requiresAuth: true },
      },
    ],
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
    next("/app");
  } else {
    next();
  }
});

export default router;
