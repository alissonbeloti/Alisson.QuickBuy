using System;

using Alisson.QuickBuy.Dominio.Entidades;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Alisson.QuickBuy.Repositorio.Config
{
    public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Ignore(p => p.EhValido);
            builder.Property(p => p.Cep).HasMaxLength(10).IsRequired().HasColumnType("varchar");
            builder.Property(p => p.Cidade).HasMaxLength(100).IsRequired().HasColumnType("varchar");
            builder.Property(p => p.DataPedido).IsRequired();
            builder.Property(p => p.EnderecoCompleto).HasMaxLength(200).IsRequired();
            builder.Property(p => p.Estado).HasMaxLength(2).IsRequired();
            builder.Property(p => p.FormaPagamentoId).IsRequired();
            builder.Property(p => p.PrevisaoEntrega).IsRequired();
            builder.Property(p => p.UsuarioId).IsRequired();

            builder.HasMany(u => u.ItensPedido).WithOne(p => p.Pedido).HasForeignKey(u => u.PedidoId);
        }
    }
}
