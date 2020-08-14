import Vue from 'vue';
import Vuetify from 'vuetify/lib';

Vue.use(Vuetify);

export default new Vuetify({
  theme: {
      options: {
        customProperties: true,
      },
    themes: {
      light: {
        primary: '#ee44aa',
        secondary: '#424242',
        accent: '#82B1FF',
        error: '#FF5252',
        info: '#2196F3',
        success: '#4CAF50',
        warning: '#FFC107',
        azul: '#13232f',
        verde: '#00BCD4',
        indigo2: '#303f9f',
      },
    },
  },
  icons: {
    iconfont: 'md',
  },
});
