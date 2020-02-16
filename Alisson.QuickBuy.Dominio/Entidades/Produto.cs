using System;
using System.Collections.Generic;
using System.Text;

namespace Alisson.QuickBuy.Dominio.Entidades
{
    public class Produto: Entidade
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public virtual List<ItemPedido> ItensPedidos { get; set; }
        public override void Validate()
        {
            if (string.IsNullOrEmpty(Nome))
                AdicionarMensagensValidacao("Nome é obrigatória.");

            if (Preco == 0)
                AdicionarMensagensValidacao("O preço deve ser mairo do que 0(zero).");
        }
    }
}
