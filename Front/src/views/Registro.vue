<template>
      <div class="register">
      <v-form ref="form" v-model="valid" lazy-validation class="form">
          <h5 class="text-center form-label">¡Bienvenido!</h5>
            <v-img class="mx-auto" max-width="50" max-height="50" :src="require('../assets/TM_logo.png')">
      </v-img>
      <label class="mt-5 form-label text-center">Nombre</label>
      <input v-model="nombre" :rules="NombreRules" class="form-input" required placeholder="Nombre">
      <label class="mt-3 form-label text-center">Correo electrónico</label>
      <input v-model="email" :rules="emailRules" class="form-input" required placeholder="Correo Electrónico">
      <label class="mt-3 text-center form-label">Contraseña</label>
      <input v-model="contraseña" :rules="contraseñaRules" class="form-input" placeholder="Contraseña">
      <v-btn @click="redirect('/home')" class="mt-10">Ingresar</v-btn>
    </v-form>
  </div>
</template>

<script>
export default {
    data: () => ({
    email: "",
   
  }),
  methods: {
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
.register {
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

