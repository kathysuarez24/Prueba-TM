using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api_tm.Model
{
    public class RolModel
    {
        //Campos de la tabla en BD
        public int Id { get; set; }
        //Para que un dato sea requerido se coloca como un data notation
        [Required]
        public string Nombre { get; set; }
        public string Descripción { get; set; }
        //Relacion uno a muchos
        public List<UsuarioModel> Usuarios { get; set; }
    }
}
