using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alisson.QuickBuy.Dominio.Contratos;
using Alisson.QuickBuy.Dominio.Entidades;
using Alisson.QuickBuy.Web.EntityUI;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Alisson.QuickBuy.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepositorio usuarioRepositorio;
        private readonly IMapper mapper;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio, IMapper mapper)
        {
            this.usuarioRepositorio = usuarioRepositorio;
            this.mapper = mapper;
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
                    return Ok(mapper.Map<UsuarioDTO>(usuarioRetorno));
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
        public IActionResult Post(UsuarioDTO usuarioDTO)
        {

            try
            {
                var usuarioCadastrado = usuarioRepositorio.Obter(usuarioDTO.Email);
                if (usuarioCadastrado != null)
                {
                    return BadRequest("Usuário existente!");
                }
                usuarioCadastrado = mapper.Map<Usuario>(usuarioDTO);
                this.usuarioRepositorio.Adicionar(usuarioCadastrado);
                usuarioDTO = mapper.Map<UsuarioDTO>(usuarioCadastrado);
                return Ok(usuarioDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
