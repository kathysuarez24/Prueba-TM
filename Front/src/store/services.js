import UsuarioService from '../services/UsuarioService'
import RolService from '../services/RolService'
import Axios from 'axios'

let apiUrl= 'https://localhost:44354/api/'

//Axios Configuration
Axios.defaults.headers.common.Accept= 'application/json'

export default{
    UsuarioService: new UsuarioService(Axios,apiUrl),
    RolService: new RolService(Axios,apiUrl),

    registro(email, contrasena) {
        const user = { email, contrasena };
        return Axios.post(apiUrl + "create", user);
        },

    login(email, contrasena) {
            const user = { email, contrasena };
            return Axios.post(apiUrl + "login", user);
          }
}