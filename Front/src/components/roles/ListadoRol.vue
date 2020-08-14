<template>
<div>
  <appbar> </appbar>
  <v-container grid-list-xl> 
    <v-card class="elevation-3 mx-auto" max-width="900">
      <v-data-table :headers="headers" :items="data" :search="search" sort-by="id" class="elevation-3">     
        <template v-slot:top>    
            <v-system-bar color="indigo darken-2" dark></v-system-bar>
            <v-toolbar flat color="indigo">          
                <v-toolbar-title class="white--text">ROLES</v-toolbar-title>
                <v-divider class="mx-4" inset vertical></v-divider> 
                <v-spacer></v-spacer>              
            </v-toolbar>
            <v-col cols="4" sm="4">
                <v-text-field v-model="search" append-icon="search" label="Buscar" single-line hide-details></v-text-field>
            </v-col>
        </template>

        <!-- Botones de Acciones-->
        <template v-slot:item.accion="{ item }"> 
            <v-btn class="mr-2" fab dark small color="verde" @click="editar(item.id)">
              <v-icon dark>create</v-icon>
            </v-btn>   
            <v-btn class="mr-2" fab dark small color="warning" @click="borrar(item.id)">
              <v-icon dark>delete</v-icon>
            </v-btn>
        </template>
      </v-data-table>

      <!-- Configuración Snackbar-->
      <template>
        <div class="text-center ma-2">
          <v-snackbar v-model="snackbar">
            {{ textSnack }}
            <v-btn color="info" text @click="snackbar = false">Cerrar</v-btn>
          </v-snackbar>
        </div>
      </template>     
    </v-card>

  </v-container> 

  </div>
  
</template>

<script>
import appbar from '@/components/appbar.vue';

export default {
  
    data () {
        return {
            data:[],
            loading: false,
            search: '', 
            snackbar: false,    
            textSnack: 'texto snackbar',  
            id: '',
            nombre:'',
            descripcion:'',
           
            headers: [
              { text: 'Nombre', value: 'nombre'},
              { text: 'Descripcion', value: 'descripción'},
              { text: 'Acciones', value: 'accion', sortable: false},
            ],   
        }
      },

      components:{
      appbar

    },

      created()
      {
        let self = this;
        self.getAllRol();
      },
      
      methods: {
        getAllRol(){
          let self = this;
          self.$store.state.services.RolService
          .getAllRol()
          .then(r => {
          self.data = r.data;
        }).catch(() => {
          this.snackbar = true
          this.textSnack = '¡Error Inesperado!'
        })    
        },

       
        LimpiarCampos()
        {
          this.nombre=''
          this.descripcion='' 
        },
      
        editar (id) {    
          this.redirect(`/editRol/${id}`)
          console.log(id);
        },

        borrar (id) { 
          let self= this;
          var resp = confirm("¿Está seguro de borrar el rol?");
          if (resp == true) 
          {
            self.$store.state.services.RolService
            .delete(id)
            .then ( () => {
                  self.getAllRol()
                  this.snackbar = true
                  this.textSnack = 'Se eliminó el registro.' 
            })
            .catch ( () => {
                  this.snackbar = true
                  this.textSnack = 'No Se eliminó el registro.' 
            })                  
          } 
          else 
          { 
            this.snackbar = true
            this.textSnack = 'Operación cancelada.' 
          }
      },

          cancelar () {
            this.dialog = false
            this.LimpiarCampos()
          },

          redirect(path){
            this.$router.push(path);
          }
      }
}
</script>