using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alisson.QuickBuy.Dominio.Contratos;
using Alisson.QuickBuy.Dominio.Entidades;
using Alisson.QuickBuy.Web.EntityUI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Alisson.QuickBuy.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepositorio usuarioRepositorio;
        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            this.usuarioRepositorio = usuarioRepositorio;
        }

        [AllowAnonymous]
        [HttpPost("VerificarUsuario")]
        public IActionResult VerificarUsuario(UsuarioLogin usuario)
        {

            try
            {
                //var usuarioRetorno = usuarioRepositorio.ObterPorEmail(usuario.Email);
                var usuarioRetorno = usuarioRepositorio.Obter(usuario.Email, usuario.Senha);
                if (usuarioRetorno != null)
                {
                    usuario.Id = usuarioRetorno.Id;
                    return Ok(usuario);
                }
                else
                    return BadRequest("Usuário não encontrado!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post()
        {

            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
