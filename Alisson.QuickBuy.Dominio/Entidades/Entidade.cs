using System.Collections.Generic;
using System.Linq;

namespace Alisson.QuickBuy.Dominio.Entidades
{
    public abstract class Entidade
    {
        
        //public int Id { get; set; }
        private List<string> mensagemValidacao { get {
                return mensagemValidacao ?? new List<string>();
            } }
        public abstract void Validate();
        public bool EhValido { get {
                return mensagemValidacao != null? !mensagemValidacao.Any(): true;
            } 
        }
        protected void LimparMensagensValidacao()
        {
            mensagemValidacao.Clear();
        }

        protected void AdicionarMensagensValidacao(string msg)
        {
            mensagemValidacao.Add(msg);
        }
    }
}
