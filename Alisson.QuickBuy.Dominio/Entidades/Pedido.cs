using System;
using System.Collections.Generic;
using System.Linq;
using Alisson.QuickBuy.Dominio.ObjetoDeValor;

namespace Alisson.QuickBuy.Dominio.Entidades
{
    public class Pedido : Entidade
    {
        public int Id { get; set; }
        public DateTime DataPedido { get; set; }
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
        public DateTime PrevisaoEntrega { get; set; }
        public string Cep { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string EnderecoCompleto { get; set; }
        
        public int FormaPagamentoId { get; set; }
        public virtual FormaPagamento FormaPagamento { get; set; }

        public virtual ICollection<ItemPedido> ItensPedido { get; set; }

        public override void Validate()
        {
            LimparMensagensValidacao();
            if (!ItensPedido.Any())
                AdicionarMensagensValidacao("O pedido não contém itens.");
            if (string.IsNullOrEmpty(Cep))
                AdicionarMensagensValidacao("O cep é obrigatório.");
            if (FormaPagamentoId == 0)
                AdicionarMensagensValidacao("Informe a forma de pagamento.");
        }
    }
}
