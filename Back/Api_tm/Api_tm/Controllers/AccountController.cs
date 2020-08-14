using Api_tm.Model;
using AutoMapper.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Api_tm.Controllers
{
    [Route("api/[controller]")]
    public class AccountController: Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            this._configuration = configuration;
        }

        [Route("Create")]
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UsuarioModel model)
        {
            if (ModelState.IsValid)
            {
                //Pasa el email y contraseña
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Contrasena);
                
                //Si es correcto, crea el tokens
                if (result.Succeeded)
                {
                    return BuildToken(model);
                }
                else
                {
                    return BadRequest("Usuario o Contraseña Invalida");
                }
            }
            else
            {
                return BadRequest(ModelState);
            }

        }

        //Loguear un usuario
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] UsuarioModel usuarioModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(usuarioModel.Email, usuarioModel.Contrasena, isPersistent: false, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    return BuildToken(usuarioModel);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "No se pudo iniciar sesion.");
                    return BadRequest(ModelState);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        //Construye el token a patir de la información del usuario
        private IActionResult BuildToken(UsuarioModel usuarioModel)
        {
            //Crear claims, nombre y valor
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, usuarioModel.Email),
                //Identificador unico del token
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            //Llave de seguridad, convierte string en arreglo de bytes
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("llave_secreta"));
            //Crear Credenciales y expiracion
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiration = DateTime.UtcNow.AddHours(1);

            JwtSecurityToken token = new JwtSecurityToken(
               issuer: "dominio.com",
               audience: "dominio.com",
               claims: claims,
               expires: expiration,
               signingCredentials: creds);

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = expiration
            });

        }

    }
}
