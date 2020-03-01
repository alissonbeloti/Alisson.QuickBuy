using Alisson.QuickBuy.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Alisson.QuickBuy.Repositorio.Config
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Ignore(u => u.EhValido);
            builder.Property(u => u.Preco).HasColumnType("decimal(19,4)").IsRequired();
            builder.Property(u => u.Nome).HasMaxLength(100).IsRequired();
            builder.Property(u => u.Descricao).HasMaxLength(400).IsRequired();
            //builder.Property(u => u.NomeArquivo).IsRequired(false);

            builder.HasMany(p => p.ItensPedidos).WithOne(i => i.Produto).HasForeignKey(i => i.ProdutoId);
        }
    }
}
