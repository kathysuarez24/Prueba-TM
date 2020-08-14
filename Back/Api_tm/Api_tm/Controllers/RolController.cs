using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_tm.Data;
using Api_tm.Model;
using Api_tm.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api_tm.Controllers
{
    [Route("api/[controller]")]
    public class RolController : Controller
    {
        private readonly IRolService _rolService;

        public RolController(IRolService rolService)
        {

            _rolService = rolService;
        }

        //Estado de peticiones
        [HttpGet]
        public IActionResult GetAll(RolModel model)
        {
            return Ok(_rolService.GetAll(model));

        }

        //Peticion Get que trae un regitro específico: api/usuario/id
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            //Guardando en la variable lo que encuentre accediendo al modelo buscando ese id
            return Ok(_rolService.Get(id));
        }

        //Peticion Post para enviar registro: api/usuario
        [HttpPost]
        public IActionResult Post([FromBody] RolModel model)
        {
            return Ok(_rolService.Add(model));

        }

        //Peticion Put para actualizar un registro: api/usuario/id
        [HttpPut]
        public IActionResult Put([FromBody] RolModel model)
        {
            return Ok(_rolService.Update(model));
        }

        //Peticion Delete para borrar un registro: api/usuario/id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //Guardando en la variable lo que encuentre accediendo al modelo buscando ese id
            return Ok(_rolService.Delete(id));
        }

    }

}
