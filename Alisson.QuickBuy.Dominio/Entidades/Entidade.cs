using System.Collections.Generic;
using System.Linq;

namespace Alisson.QuickBuy.Dominio.Entidades
{
    public abstract class Entidade
    {
        internal List<string> mensagemValidacao;
        public Entidade()
        {
            this.mensagemValidacao = new List<string>();
        }
        //public int Id { get; set; }
        
        public abstract void Validate();
        public bool EhValido { 
            get {
                return !mensagemValidacao.Any();
            } 
        }
        protected void LimparMensagensValidacao()
        {
            mensagemValidacao.Clear();
        }
        public string ObterMensagensValidacao()
        {
            return string.Join(". ", mensagemValidacao);
        }
        protected void AdicionarMensagensValidacao(string msg)
        {
            mensagemValidacao.Add(msg);
        }
    }
}
