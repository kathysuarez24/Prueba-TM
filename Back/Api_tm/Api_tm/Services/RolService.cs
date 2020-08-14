using Api_tm.Data;
using Api_tm.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_tm.Services
{
    public interface IRolService
    {
        IEnumerable<RolModel> GetAll(RolModel model);
        bool Add(RolModel model);
        bool Update(RolModel model);
        bool Delete(int id);
        RolModel Get(int id);
    }

    public class RolService : IRolService
    {
        //Registrar e inyectar Dependencia del DbContext
        private readonly UsuarioDbContext _rolDbContext;
        public RolService(UsuarioDbContext rolDbContext)
        {
            _rolDbContext = rolDbContext;
        }

        //Agregar
        public bool Add(RolModel model)
        {
            try
            {
                //Agregamos al modelo
                _rolDbContext.Add(model);
                //Se guarda
                _rolDbContext.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }
            return true;
        }

        //Actualizar
        public bool Update(RolModel model)
        {
            try
            {
                //Traigo el objeto a modificar
                var objeto = _rolDbContext.Rol.Single(x => x.Id == model.Id);
                objeto.Nombre = model.Nombre;
                objeto.Descripción = model.Descripción;

                //Modifico y guardo
                _rolDbContext.Update(objeto);
                _rolDbContext.SaveChanges();
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
                _rolDbContext.Entry(new RolModel { Id = id }).State = EntityState.Deleted;
                _rolDbContext.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }
            return true;
        }

        //Listado de Roles
        public IEnumerable<RolModel> GetAll(RolModel model)
        {
            var result = new List<RolModel>();
            try
            {
                result = _rolDbContext.Rol.ToList();

            }
            catch (System.Exception)
            {

            }
            return result;
        }

        //Obtener un rol
        public RolModel Get(int id)
        {
            var result = new RolModel();
            try
            {
                result = _rolDbContext.Rol.Single(x => x.Id == id);
            }
            catch (System.Exception)
            {

            }
            return result;
        }



    }
}