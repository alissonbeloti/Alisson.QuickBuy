using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alisson.QuickBuy.Dominio.Contratos;
using Alisson.QuickBuy.Dominio.Entidades;
using Alisson.QuickBuy.Web.EntityUI;
using Microsoft.AspNetCore.Mvc;

namespace Alisson.QuickBuy.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController: ControllerBase
    {
        private readonly IProdutoRepositorio produtoRepositorio;
        public ProdutoController(IProdutoRepositorio produtoRepositorio)
        {
            this.produtoRepositorio = produtoRepositorio;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<ProdutoLista> produtosLista = new List<ProdutoLista>();
                var produtos = produtoRepositorio.ObterTodos();
                foreach (var produto in produtos)
                {
                    produtosLista.Add(new ProdutoLista()
                    {
                        Descricao = produto.Descricao,
                        Id = produto.Id,
                        Nome = produto.Nome,
                        Preco = produto.Preco
                    });
                }
                return Ok(produtosLista);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(ProdutoLista produto)
        {
            try
            {
                var produtoDom = new Produto()
                {
                    Descricao = produto.Descricao,
                    Id = produto.Id,
                    Nome = produto.Nome,
                    Preco = produto.Preco,
                };
                produtoRepositorio.Adicionar(produtoDom);
                produto.Id = produtoDom.Id;
                return Created("produto", produto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
