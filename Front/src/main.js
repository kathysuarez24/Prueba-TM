import Vue from 'vue'
import Vuex from 'vuex'
import App from './App.vue'
import store from './store'
import router from './router'
import vuetify from './plugins/vuetify';
import 'roboto-fontface/css/roboto/roboto-fontface.css'
import 'material-design-icons-iconfont/dist/material-design-icons.css'
import axios from 'axios'
import VueAxios from 'vue-axios'
Vue.use(Vuex);
 
Vue.use(VueAxios, axios)

Vue.config.productionTip = false

new Vue({
  store,
  axios,
  router,
  vuetify,
  render: h => h(App)
}).$mount('#app')
