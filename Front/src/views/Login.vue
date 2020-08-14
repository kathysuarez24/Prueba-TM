<template>
  <div class="login">
     <!-- Formulario -->
    <v-form ref="form" v-model="valid" lazy-validation class="form">
      <h3 class="text-center form-label">¡Bienvenido!</h3>
      <v-img class="mx-auto" max-width="200" max-height="200" :src="require('../assets/TM_logo.png')"> </v-img>
      <label class="mt-5 form-label text-center">Correo electrónico</label>
      <input v-model="email" :rules="emailRules" class="form-input" required placeholder="Correo Electrónico">
      <label class="text-center form-label">Contraseña</label>
      <input v-model="contraseña" :rules="contraseñaRules" class="form-input" placeholder="Contraseña">
      <v-btn @click="iniciarSesion()" :disabled="!valid" class="mt-10"> Iniciar Sesión</v-btn>
      <h4 class="text-center form-label verde--text mt-5" color="indigo" @click="redirect('/registro')">Registrarme</h4>
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
  </div>
  
</template>

<script>
export default {
    data () {
        return {
            email:'',
            password:'',
            emailRules: [v => !!v || "Debe ingresar su correo"],
            contraseña: "",
            contraseñaRules: [v => !!v || "Debe ingresar su contraseña"],
            snackbar: false, // mensaje del snackbar   
            textSnack: 'texto snackbar', //texto que se ve en el snackbar
            valid: true,
        }
      },

      methods: {
        login() {
            console.log(this.email);
            console.log(this.password);
        },
          cancelar () {
            this.dialog = false
            this.LimpiarCampos()
          },

          iniciarSesion()
          {
            if(this.$refs.form.validate())
            {
              this.snackbar = true
              this.textSnack = '¡Ingresó!'
              this.redirect('/home');

            }
            else
            {
              this.snackbar = true
              this.textSnack = '¡Debe ingresar sus credenciales!'

            }
            
          },

          redirect(path){
            if(this.$refs.form.validate())
            {
                this.$router.push(path);
            }
            else
            {
              this.snackbar = true
              this.textSnack = '¡Debe ingresar sus credenciales!'

            }
            
          }
      }
}

</script>

<style lang="scss" scoped>
.login {
  padding: 2rem;
}
.form {
  margin: 3rem auto;
  display: flex;
  flex-direction: column;
  justify-content: center;
  width: 20%;
  min-width: 350px;
  max-width: 100%;
  background: rgba(19, 35, 47, 0.9);
  border-radius: 5px;
  padding: 40px;
  box-shadow: 0 4px 10px 4px rgba(0, 0, 0, 0.3);
}
.form-label {
  margin-top: 2rem;
  color: white;
  margin-bottom: 0.5rem;
  &:first-of-type {
    margin-top: 0rem;
  }
}
.form-input {
  padding: 10px 15px;
  background: none;
  background-image: none;
  border: 1px solid white;
  color: white;
  &:focus {
    outline: 0;
    border-color: #0b9185;
  }
}

</style>