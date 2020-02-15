using System;
using System.Collections.Generic;
using System.Text;
using Alisson.QuickBuy.Dominio.Enumeradores;

namespace Alisson.QuickBuy.Dominio.ObjetoDeValor
{
    public class FormaPagamento
    {
        public int Id { get; set; }
        public string Descricao { get; set; }

        public bool EhBoleto { get {
                return Id == (int)TipoFormaPagamentoEnum.Boleto;
            }}

        public bool NaoDefinido
        {
            get
            {
                return Id == (int)TipoFormaPagamentoEnum.NaoDefinido;
            }
        }
    }
}
