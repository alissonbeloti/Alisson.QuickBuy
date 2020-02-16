using Alisson.QuickBuy.Dominio.Entidades;
using Alisson.QuickBuy.Dominio.ObjetoDeValor;
using Alisson.QuickBuy.Repositorio.Config;
using Microsoft.EntityFrameworkCore;

namespace Alisson.QuickBuy.Repositorio.Contexto
{
    public class QuickBuyContexto: DbContext
    {
        public QuickBuyContexto(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<ItemPedido> ItensPedidos { get; set; }
        public DbSet<FormaPagamento> FormaPagamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FormaPagamentoConfiguration());
            modelBuilder.ApplyConfiguration(new ProdutoConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new PedidoConfiguration());
            modelBuilder.ApplyConfiguration(new ItemPedidoConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
