using Api_tm.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_tm.Data
{
    //Hereda de DbCotext clase interna de .NET
    public class UsuarioDbContext: DbContext
    {
        //Constructor
        public UsuarioDbContext(DbContextOptions<UsuarioDbContext> options):base(options)
        {

        }

        //Crear DBSet que llama al modelo, mapeo del modelo con nombre de identificador en Entity framework en el controlador
        public DbSet<UsuarioModel> Usuario { get; set; }
    }
}
