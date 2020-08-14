using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api_tm.Model
{
    public class UsuarioModel
    {
        //Campos de la tabla en BD
        public int Id { get; set; }
        //Para que un dato sea requerido se coloca como un data notation
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public string Contrasena { get; set; }
        public string Fecha_Nac { get; set; }
        //Clave Foranea
        public int RolModelId { get; set; }

    }
}
