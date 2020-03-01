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
    public class ProdutoController: ControllerBase
    {
        private readonly IProdutoRepositorio produtoRepositorio;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IWebHostEnvironment webHostEnvironment;

        public ProdutoController(IProdutoRepositorio produtoRepositorio, 
            IMapper mapper,
            IHttpContextAccessor httpContextAccessor,
            IWebHostEnvironment webHostEnvironment)
        {
            this.produtoRepositorio = produtoRepositorio;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
            this.webHostEnvironment = webHostEnvironment;
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
                //var produtoDom = new Produto()
                //{
                //    Descricao = produto.Descricao,
                //    Id = produto.Id,
                //    Nome = produto.Nome,
                //    Preco = produto.Preco,
                //};

                var produtoMap = mapper.Map<Produto>(produto);
                produtoMap.Validate();
                if (!produtoMap.EhValido)
                {
                    return BadRequest(produtoMap.ObterMensagensValidacao());
                }
                produtoRepositorio.Adicionar(produtoMap);
                produto = this.mapper.Map<ProdutoLista>(produtoMap);
                return Created("produto", produto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("EnviarArquivo")]
        public IActionResult EnviarArquivo()
        {
            try
            {
                var formFile = httpContextAccessor.HttpContext.Request.Form.Files["arquivoEnviado"];
                var nomeArquivo = formFile.FileName;
                var extensao = nomeArquivo.Split('.').Last();
                var arrayNomeCompacto = Path.GetFileName(nomeArquivo).Take(10).ToArray();
                var novoNomeArquivo = new string(arrayNomeCompacto).Replace(" ", "-") + DateTime.Now.ToString("yyyyMMdd-hhmmss") + "." + extensao;
                var pastaArquivos = $"{webHostEnvironment.WebRootPath}\\arquivos\\";
                var nomeCompleto = $"{pastaArquivos}{novoNomeArquivo}";
                using(var streamArquivo = new FileStream(nomeCompleto, FileMode.Create))
                {
                    formFile.CopyTo(streamArquivo);

                }
                return Ok(new { nomeArquivo = novoNomeArquivo });//Created("produto", produto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                var produto = produtoRepositorio.ObterPorId(id);
                produtoRepositorio.Remover(produto);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
