<template>
<div>
  <v-app-bar color="azul" dark>
      <v-app-bar-nav-icon @click="drawer = true"></v-app-bar-nav-icon>
      <v-toolbar-title>T&M Consulting</v-toolbar-title>
    </v-app-bar>

    <v-navigation-drawer v-model="drawer" absolute temporary>
      <v-list nav dense>
        <v-list-item-group active-class="light-blue--text text--accent-4">
          <v-list-item :to="{name:'home'}">
            <v-list-item-icon >
              <v-icon>home</v-icon>
            </v-list-item-icon>
            <v-list-item-title>Home</v-list-item-title>
          </v-list-item>
          <v-list-item :to="{name:'createUsuario'}">
            <v-list-item-icon>
              <v-icon>how_to_reg</v-icon>
            </v-list-item-icon>
            <v-list-item-title>Registrar Usuario</v-list-item-title>
          </v-list-item>
          <v-list-item :to="{name:'listadoUsuario'}">
            <v-list-item-icon>
              <v-icon>supervisor_account</v-icon>
            </v-list-item-icon>
            <v-list-item-title>Listado de Usuarios</v-list-item-title>
          </v-list-item>
          <v-list-item :to="{name:'createRol'}">
            <v-list-item-icon>
              <v-icon>next_week</v-icon>
            </v-list-item-icon>
            <v-list-item-title>Registrar Rol</v-list-item-title>
          </v-list-item>
          <v-list-item :to="{name:'listadoRol'}">
            <v-list-item-icon>
              <v-icon>view_list</v-icon>
            </v-list-item-icon>
            <v-list-item-title>Listado de Roles</v-list-item-title>
          </v-list-item>
          <v-list-item :to="{name:'login'}">
            <v-list-item-icon>
              <v-icon>exit_to_app</v-icon>
            </v-list-item-icon>
            <v-list-item-title>Cerrar Sesion</v-list-item-title>
          </v-list-item>
        </v-list-item-group>
      </v-list>
    </v-navigation-drawer>

</div>
</template>

<script>
//import appbar from '@/components/appbar.vue';
export default {
  name: 'App',

  data: () => {
    return {
      drawer: false,
    
    }

  },
  

};
</script>
