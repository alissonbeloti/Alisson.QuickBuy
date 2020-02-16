using System.Collections.Generic;

namespace Alisson.QuickBuy.Dominio.Entidades
{
    public class Usuario: Entidade
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }

        public virtual ICollection<Pedido> Pedidos { get; set; }

        public override void Validate()
        {
            if (string.IsNullOrEmpty(Email))
                AdicionarMensagensValidacao("Informe o e-mail.");

            if (string.IsNullOrEmpty(Senha))
                AdicionarMensagensValidacao("Informe a senha.");
        }
    }
}
