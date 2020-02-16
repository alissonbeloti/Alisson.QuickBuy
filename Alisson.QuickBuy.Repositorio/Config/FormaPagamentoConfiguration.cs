using Alisson.QuickBuy.Dominio.ObjetoDeValor;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Alisson.QuickBuy.Repositorio.Config
{
    public class FormaPagamentoConfiguration : IEntityTypeConfiguration<FormaPagamento>

    {
        public void Configure(EntityTypeBuilder<FormaPagamento> builder)
        {
            builder.HasKey(ip => ip.Id);
            builder.Property(ip => ip.Nome).HasMaxLength(50).IsRequired(true);
            builder.Property(ip => ip.Descricao).HasMaxLength(150).IsRequired(true);
            builder.Ignore(ip => ip.EhBoleto);
            builder.Ignore(ip => ip.NaoDefinido);

            builder.HasMany(f => f.Pedidos).WithOne(p => p.FormaPagamento).HasForeignKey(p => p.FormaPagamentoId);
        }
    }
}
