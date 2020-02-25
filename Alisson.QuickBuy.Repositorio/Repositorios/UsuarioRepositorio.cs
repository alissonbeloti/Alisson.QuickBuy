using System.Linq;
using Alisson.QuickBuy.Dominio.Contratos;
using Alisson.QuickBuy.Dominio.Entidades;
using Alisson.QuickBuy.Repositorio.Contexto;

namespace Alisson.QuickBuy.Repositorio.Repositorios
{
    public class UsuarioRepositorio: BaseRepositorio<Usuario>, IUsuarioRepositorio
    {

        public UsuarioRepositorio(QuickBuyContexto contexto)
            :base (contexto)
        {
            
        }

        public Usuario Obter(string email, string senha)
        {
            return this.QuickBuyContexto.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }
    }
}
