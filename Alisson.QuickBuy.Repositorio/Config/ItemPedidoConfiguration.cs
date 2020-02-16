using Alisson.QuickBuy.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Alisson.QuickBuy.Repositorio.Config
{
    public class ItemPedidoConfiguration : IEntityTypeConfiguration<ItemPedido>
    {
        public void Configure(EntityTypeBuilder<ItemPedido> builder)
        {
            builder.HasKey(ip => ip.Id);
            builder.Property(ip => ip.Quantidade).IsRequired(true);
            builder.Property(ip => ip.PedidoId).IsRequired(true);
            builder.Property(ip => ip.ProdutoId).IsRequired(true);
        }
    }
}
