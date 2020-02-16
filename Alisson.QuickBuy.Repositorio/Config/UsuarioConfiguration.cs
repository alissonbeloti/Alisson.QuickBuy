using Alisson.QuickBuy.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Alisson.QuickBuy.Repositorio.Config
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Ignore(u => u.EhValido);
            builder.Property(u => u.Email).HasMaxLength(150).IsRequired().HasColumnType("varchar");
            builder.HasIndex(u => u.Email).IsUnique(true);
            builder.Property(u => u.Nome).HasMaxLength(100).IsRequired().HasColumnType("varchar");
            builder.Property(u => u.Senha).HasMaxLength(50).IsRequired().HasColumnType("varchar");
            builder.Property(u => u.Sobrenome).HasMaxLength(50).IsRequired(false).HasColumnType("varchar");

            builder.HasMany(u => u.Pedidos).WithOne(p => p.Usuario).HasForeignKey(u => u.UsuarioId);
        }
    }
}
