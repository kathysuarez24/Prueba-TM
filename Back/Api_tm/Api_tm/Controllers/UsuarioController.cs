using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_tm.Data;
using Api_tm.Model;
using Api_tm.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Api_tm.Controllers
{
    [Route("api/[controller]")]

    public class UsuarioController : Controller
    {
        private IUsuarioService _usuarioService;
     
        public UsuarioController(IUsuarioService usuarioService)
        {

            _usuarioService= usuarioService;            
        }

        //Estado de peticiones
        [HttpGet]
        public IActionResult GetAll(UsuarioModel model)
        {
            return Ok(_usuarioService.GetAll(model));

        }

        //Peticion Get que trae un regitro específico: api/usuario/id
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            //Guardando en la variable lo que encuentre accediendo al modelo buscando ese id
            return Ok(_usuarioService.Get(id));
        }

        //Peticion Post para enviar registro: api/usuario
        [HttpPost]
        public IActionResult Post([FromBody] UsuarioModel model)
        {
            return Ok(_usuarioService.Add(model));

        }

        //Peticion Put para actualizar un registro: api/usuario/id
        [HttpPut]
        public IActionResult Put([FromBody] UsuarioModel model)
        {
            return Ok(_usuarioService.Update(model));
        }

        //Peticion Delete para borrar un registro: api/usuario/id
        [HttpDelete("{id}")]
        public IActionResult Delete (int id)
        {
            //Guardando en la variable lo que encuentre accediendo al modelo buscando ese id
            return Ok(_usuarioService.Delete(id));
        }

    }

    

}
