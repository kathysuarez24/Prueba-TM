using Api_tm.Data;
using Api_tm.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_tm.Services
{
    public interface IUsuarioService
    {
        IEnumerable<UsuarioModel> GetAll(UsuarioModel model);
        bool Add(UsuarioModel model);
        bool Update(UsuarioModel model);
        bool Delete(int id);
        UsuarioModel Get(int id);
    }

    public class UsuarioService : IUsuarioService
    {
        //Registrar e inyectar Dependencia del DbContext
        private readonly UsuarioDbContext _usuarioDbContext;
        public UsuarioService(UsuarioDbContext usuarioDbContext)
        {
            _usuarioDbContext = usuarioDbContext;
        }

        //Agregar
        public bool Add(UsuarioModel model)
        {
            try
            {
                //Agregamos al modelo
                _usuarioDbContext.Add(model);
                //Se guarda
                _usuarioDbContext.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }
            return true;
        }

        //Actualizar
        public bool Update(UsuarioModel model)
        {
            try
            {
                //Traigo el objeto a modificar
                var objeto = _usuarioDbContext.Usuario.Single(x => x.Id == model.Id);
                objeto.Nombre = model.Nombre;
                objeto.Apellido = model.Apellido;
                objeto.Telefono = model.Telefono;
                objeto.Direccion = model.Direccion;
                objeto.Email = model.Email;
                objeto.Fecha_Nac = model.Fecha_Nac;
                objeto.RolModelId = model.RolModelId;

                //Modifico y guardo
                _usuarioDbContext.Update(objeto);
                _usuarioDbContext.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }
            return true;
        }

        //Eliminar
        public bool Delete(int id)
        {
            try
            {
                _usuarioDbContext.Entry(new UsuarioModel { Id = id }).State = EntityState.Deleted;
                _usuarioDbContext.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }
            return true;
        }

        //Listado de Usuarios
        public IEnumerable<UsuarioModel> GetAll(UsuarioModel model)
        {
            var result = new List<UsuarioModel>();
            try
            {
                result = _usuarioDbContext.Usuario.ToList();

            }
            catch (System.Exception)
            {

            }
            return result;
        }

        //Obtener un usuario
        public UsuarioModel Get(int id)
        {
            var result = new UsuarioModel();
            try
            {
                result = _usuarioDbContext.Usuario.Single(x => x.Id == id);
            }
            catch (System.Exception)
            {

            }
            return result;
        }



    }
}