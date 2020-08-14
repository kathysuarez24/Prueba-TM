<template>
<div>
  <appbar> </appbar>
  <v-container > 
    <v-card class="elevation-3 mx-auto" max-width="800">
      <v-system-bar color="indigo darken-2" dark></v-system-bar>
      <v-toolbar flat color="indigo"> 
        <v-toolbar-title class="white--text">EDITAR ROL: {{this.nombre}} </v-toolbar-title>
      </v-toolbar>
      <v-divider class="mx-4" inset vertical></v-divider> 
      <v-spacer></v-spacer> 

      <!--Formulario-->
      <v-form ref="form" v-model="valid" lazy-validation>
        <v-row cols="8">
          <v-col lg="6"> 
              <v-text-field class="ml-10" v-model="nombre" :rules="nombreRules" label="Nombre" required></v-text-field>
          </v-col>
          </v-row>
          <v-row cols="8">
          <v-col lg="10">
              <v-text-field class="ml-10" v-model="descripcion" :rules="descripcionRules" label="Descripcion" required></v-text-field>
          </v-col>
        </v-row>
          <v-col class="text-center"> 
            <v-btn color="verde" class="ml-8" @click="Guardar" :disabled="!valid"> Guardar </v-btn>
          </v-col> 
    </v-form> 

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
  name: "EditRol",
  data: () => {
    return {
      valid: true,
      id:"",
      nombre: "",
      nombreRules: [v => !!v || "El nombre es requerido"],
      descripcion: "",
      descripcionRules: [v => !!v || "La descripción es requerida"],
      snackbar: false, // mensaje del snackbar   
      textSnack: 'texto snackbar', //texto que se ve en el snackbar 
      };
    },
    
    components:{
      appbar

    },

  created() {
        let self = this;
        self.get(self.$route.params.id);
      },

  methods: {
      get(id){
          if(id == undefined) return
          let self = this;
          self.$store.state.services.RolService
          .get(id)
          .then(r=>{
            self.id = r.data.id;
            self.nombre = r.data.nombre;
            self.descripcion = r.data.descripción;
             })
        },

      Guardar() {
        let self = this;
        this.$refs.form.validate();
          {
            self.$store.state.services.RolService
                .update({
                  'id': this.id,
                  'nombre': this.nombre,
                  'descripción':this.descripcion,
                })
                .then(() => {
                  this.snackbar = true
                  this.textSnack = '¡Rol Modificado!'
                  this.LimpiarCampos();
                  this.redirect('/ListadoRol');
                })
                .catch(()=> {
                  this.snackbar = true
                  this.textSnack = '¡Error inesperado!'
                })
        }
      },

      LimpiarCampos(){
          this.nombre=''
          this.descripcion=''
      },

      redirect(path){
            this.$router.push(path);
        }
  }
};
</script>
