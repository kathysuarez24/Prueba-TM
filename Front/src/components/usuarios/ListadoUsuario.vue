<template>
<div>
  <appbar> </appbar>
  <v-container grid-list-xl>
    
    <v-card class="elevation-3">
      <v-data-table :headers="headers" :items="data" :search="search" sort-by="id" class="elevation-3">     
        <template v-slot:top>    
            <v-system-bar color="indigo darken-2" dark></v-system-bar>
            <v-toolbar flat color="indigo">          
                <v-toolbar-title class="white--text">USUARIOS</v-toolbar-title>
                <v-divider class="mx-4" inset vertical></v-divider> 
                <v-spacer></v-spacer>              
            </v-toolbar>
            <v-col cols="3" sm="3">
                <v-text-field v-model="search" append-icon="search" label="Buscar" single-line hide-details></v-text-field>
            </v-col>
        </template>

        <!-- Columna de botones de Acciones-->
        <template v-slot:item.accion="{ item }"> 
            <v-btn class="mr-2" fab dark small color="verde" @click="editar(item.id)">
              <v-icon dark>create</v-icon>
            </v-btn>   
            <v-btn class="mr-2" fab dark small color="warning" @click="borrar(item.id)">
              <v-icon dark>delete</v-icon>
            </v-btn>
        </template>

        <template v-slot:item.edadcal="{ item }"> 
            <p>{{parseInt((new Date() - new Date(item.fecha_Nac)) / (1000*60*60*24*365))}}</p> 
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
            edadcal:'',
            nombre:'',
            apellido:'',  
            telefono:'', 
            direccion:'',
            email:'',
            rolModelId:'',
            fecha_Nac:'',
            
            headers: [
              { text: 'Nombre', value: 'nombre'},
              { text: 'Apellido', value: 'apellido'},
              { text: 'Telefono', value:'telefono'},
              { text: 'Direccion', value:'direccion'},
              { text: 'Email', value: 'email'},
              { text: 'Rol', value: 'rolModelId'},
              { text: 'Edad', value: 'edadcal'},
              { text: 'Acciones', value: 'accion', sortable: false },
            ],   

        }
      },

      components:{
      appbar

    },

      created()
      {
        let self = this;
        self.getAll();
      },

      methods: {
        getAll(){
          let self = this;
          self.$store.state.services.UsuarioService
          .getAll()
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
                this.telefono='' 
                this.direccion=''  
                this.apellido=''
                this.email=''
                this.rolModelId=''
                this.fecha_Nac=''
        },
      
        editar (id) {    
          this.redirect(`/editUsuario/${id}`)
        },

        borrar (id) { 
          let self= this;
          var resp = confirm("¿Está seguro de borrar el usuario?");
          if (resp == true) 
          {
            self.$store.state.services.UsuarioService
            .delete(id)
            .then ( () => {
                  self.getAll()
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