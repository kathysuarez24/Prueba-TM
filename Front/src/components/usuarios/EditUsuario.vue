<template>
<div>
  <appbar> </appbar>
  <v-container > 
    <v-card class="elevation-3 mx-auto" max-width="900">
      <v-system-bar color="indigo darken-2" dark></v-system-bar>
      <v-toolbar flat color="indigo"> 
        <v-toolbar-title class="white--text">EDITAR USUARIO: {{this.nombre}}, {{this.apellido}} </v-toolbar-title>        
      </v-toolbar>
      <v-divider class="mx-4" inset vertical></v-divider> 
      <v-spacer></v-spacer> 

      <!--Formulario-->
      <v-form ref="form" v-model="valid" lazy-validation>
        <v-row cols="12">
          <v-col lg="5" sm="5"> 
              <v-text-field class="ml-15" v-model="nombre" :rules="nombreRules" label="Nombre" required></v-text-field>
          </v-col>
          <v-col lg="5" sm="5">
              <v-text-field class="ml-15" v-model="apellido" :rules="apellidoRules" label="Apellido" required></v-text-field>
          </v-col>
          <v-col lg="5" sm="5">
              <v-text-field class="ml-15" v-model.number="telefono" type="number"
              :rules="telefonoRules" label="Telefono" required></v-text-field>
          </v-col>
          <v-col lg="5" sm="5">
              <v-text-field class="ml-15" v-model="direccion" :rules="direccionRules" label="Direccion" required></v-text-field>
          </v-col>
          <v-col lg="5" sm="5">
              <v-menu ref="menu" v-model="menu" :close-on-content-click="false" :return-value.sync="fecha_Nac" transition="scale-transition" offset-y min-width="290px">
                <template v-slot:activator="{ on, attrs }">
                  <v-text-field class="ml-8" v-model="fecha_Nac" label="Fecha de Nacimiento" prepend-icon="event" readonly v-bind="attrs" v-on="on"></v-text-field>
                </template>
                <v-date-picker v-model="fecha_Nac" no-title scrollable :min="minimo" :max="maximo">
                  <v-spacer></v-spacer>
                    <v-btn text color="primary" @click="menu = false">Cancelar</v-btn>
                    <v-btn text color="primary" @click="$refs.menu.save(fecha_Nac), CalcularEdad(fecha_Nac)">OK</v-btn>
                </v-date-picker>
              </v-menu>
              <h5 class="ml-15">Edad: {{parseInt((new Date() - new Date(fecha_Nac)) / (1000*60*60*24*365))}}</h5>
          </v-col>
          <v-col lg="5" sm="5">
              <v-text-field class="ml-15" v-model="email" :rules="emailRules" label="E-mail" required ></v-text-field>
          </v-col>
          <v-col lg="4" sm="4">
              <v-select class="ml-15" :items="data" v-model="select" label="Selecciona un rol" item-text="nombre" item-key="data" item-value="id" return-id>            
                </v-select>
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
  name: "EditUsuario",
  data: () => {
    return {
      checked: false,
      data:[],
      menu: false,
      modal: false,
      menu2: false,
      minimo:'1920',
      maximo: new Date().toISOString().substr(0, 10),
      otraedad:"",
      valid: true,
      id:"",
      nombre: "",
      nombreRules: [v => !!v || "El nombre es requerido"],
      apellido: "",
      apellidoRules: [v => !!v || "El apellido es requerido"],
      telefono: "",
      telefonoRules: [v => !!v || "El telefono es requerido"],
      direccion: "",
      direccionRules: [v => !!v || "La direccion es requerida"],
      email: "",
      emailRules: [
        v => !!v || "El correo es requerido",
        v => /.+@.+\..+/.test(v) || "Debe ingresar un correo válido"
      ],
      fecha_Nac: "",
      fecha_NacRules: [v => !!v || "La fecha es requerida"],
      select: null,
      items: [1, 2],
      snackbar: false, // mensaje del snackbar   
      textSnack: 'texto snackbar', //texto que se ve en el snackbar 
      };
    },
    
      created() {
        let self = this;
        self.getAllRol();
        self.get(self.$route.params.id);      
      },

      components:{
      appbar

    },

  methods: {
    CalcularEdad(fecha_Nac)
    {
      let edad;
      var fechaDeNacimiento = new Date(fecha_Nac);
      var hoy = new Date();
      edad= parseInt((hoy - fechaDeNacimiento) / (1000*60*60*24*365));
      this.otraedad=edad;
    },

      get(id){
          if(id == undefined) return
          let self = this;
          self.$store.state.services.UsuarioService
          .get(id)
          .then(r=>{
            self.id = r.data.id;
            self.nombre = r.data.nombre;
            self.apellido = r.data.apellido;
            self.telefono = r.data.telefono;
            self.direccion = r.data.direccion;
            self.email = r.data.email;
            self.fecha_Nac = r.data.fecha_Nac;
            self.select = r.data.rolModelId;
            
             })
        },

         getAllRol()
         {
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


      Guardar() {
        let self = this;
        this.$refs.form.validate();
          {
            self.$store.state.services.UsuarioService
                .update({
                  'id': this.id,
                  'nombre': this.nombre,
                  'apellido':this.apellido,
                  'telefono': this.telefono,
                  'direccion': this.direccion,
                  'email': this.email,
                  'fecha_Nac': this.fecha_Nac,
                  'rolModelId': this.select
                })
                .then(() => {
                  this.snackbar = true
                  this.textSnack = '¡Usuario Modificado!'
                  this.LimpiarCampos();
                  this.redirect('/ListadoUsuario');
                })
                .catch(()=> {
                  this.snackbar = true
                  this.textSnack = '¡Error inesperado!'
                })
        }
      },

      LimpiarCampos(){
          this.nombre=''
                this.telefono='' 
                this.direccion=''  
                this.apellido=''
                this.email=''
                this.rolModelId=''
                this.fecha_Nac=''
                this.select=''
      },

      redirect(path){
            this.$router.push(path);
        }
  }
};
</script>
