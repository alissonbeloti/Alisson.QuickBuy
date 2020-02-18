using System;
using System.Collections.Generic;
using System.Text;
using Alisson.QuickBuy.Dominio.Contratos;
using Alisson.QuickBuy.Dominio.Entidades;
using Alisson.QuickBuy.Repositorio.Contexto;

namespace Alisson.QuickBuy.Repositorio.Repositorios
{
    public class ProdutoRepositorio: BaseRepositorio<Produto>, IProdutoRepositorio
    {
        public ProdutoRepositorio(QuickBuyContexto quickBuyContexto):
            base(quickBuyContexto)
        {

        }
    }
}
