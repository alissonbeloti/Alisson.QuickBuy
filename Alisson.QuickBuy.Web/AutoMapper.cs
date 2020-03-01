using Alisson.QuickBuy.Dominio.Entidades;
using Alisson.QuickBuy.Web.EntityUI;
using AutoMapper;

namespace Alisson.QuickBuy.Web
{
    public class AutoMapper: Profile
    {
        public AutoMapper()
        {
            CreateMap<Usuario, UsuarioLogin>().ReverseMap();
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
            CreateMap<Produto, ProdutoLista>().ReverseMap();
        }
    }
}
