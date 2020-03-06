using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alisson.QuickBuy.Web.EntityUI
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public bool EhAdministrador { get; set; }
    }
}
