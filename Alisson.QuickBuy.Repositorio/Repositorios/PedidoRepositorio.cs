using System;
using System.Collections.Generic;
using System.Text;
using Alisson.QuickBuy.Dominio.Contratos;
using Alisson.QuickBuy.Dominio.Entidades;
using Alisson.QuickBuy.Repositorio.Contexto;

namespace Alisson.QuickBuy.Repositorio.Repositorios
{
    public class PedidoRepositorio: BaseRepositorio<Pedido>, IPedidoRepositorio
    {

        public PedidoRepositorio(QuickBuyContexto contexto) : base (contexto)
        {
            
        }
    }
}
