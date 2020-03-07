using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Alisson.QuickBuy.Dominio.Contratos;
using Alisson.QuickBuy.Dominio.Entidades;
using Alisson.QuickBuy.Web.EntityUI;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Alisson.QuickBuy.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PedidoController: ControllerBase
    {
        private readonly IPedidoRepositorio pedidoRepositorio;
        private readonly IMapper mapper;

        public PedidoController(IPedidoRepositorio pedidoRepositorio, 
            IMapper mapper)
        {
            this.pedidoRepositorio = pedidoRepositorio;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var produtos = pedidoRepositorio.ObterTodos();
                return Ok(produtos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(Pedido pedido)
        {
            try
            {
                //if (!pedido.EhValido)
                //{
                //    return BadRequest(pedido.ObterMensagensValidacao());
                //}
                pedidoRepositorio.Adicionar(pedido);
                return Ok(pedido.Id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(Pedido pedido)
        {
            try
            {
                //var produtoMap = mapper.Map<Produto>(produto);
                //produtoMap.Validate();
                if (!pedido.EhValido)
                {
                    return BadRequest(pedido.ObterMensagensValidacao());
                }
                pedidoRepositorio.Atualizar(pedido);
                //produto = this.mapper.Map<ProdutoLista>(produtoMap);
                return Accepted(pedido.Id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
