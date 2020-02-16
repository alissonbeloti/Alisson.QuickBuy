using Alisson.QuickBuy.Dominio.Entidades;
using Alisson.QuickBuy.Dominio.Enumeradores;
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

            modelBuilder.Entity<FormaPagamento>().HasData(
                new FormaPagamento() { Id = (int)TipoFormaPagamentoEnum.Boleto, Nome = "Boleto",  Descricao = "Forma de pagamento Boleto." },
                new FormaPagamento() { Id = (int)TipoFormaPagamentoEnum.CartaoCredito, Nome = "Cartão de Credito", Descricao = "Forma de pagamento Cartão de Crédito." },
                new FormaPagamento() { Id = (int)TipoFormaPagamentoEnum.Deposito, Nome = "Depósito", Descricao = "Forma de pagamento Depósito." }
                );
            base.OnModelCreating(modelBuilder);
        }
    }
}
