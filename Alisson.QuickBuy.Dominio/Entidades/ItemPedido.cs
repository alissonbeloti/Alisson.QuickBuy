namespace Alisson.QuickBuy.Dominio.Entidades
{
    public class ItemPedido : Entidade
    {
        public int Id { get; set; }
        public virtual Pedido Pedido { get; set; }
        public int PedidoId { get; set; }
        public int ProdutoId { get; set; }
        public virtual Produto Produto { get; set; }
        public int Quantidade { get; set; }
        public override void Validate()
        {
            LimparMensagensValidacao();
            if (ProdutoId == 0)
                AdicionarMensagensValidacao("O produto não foi indicado.");
            if (Quantidade <= 0)
                AdicionarMensagensValidacao("Quantidade do item não pode ser 0(zero).");

        }
    }
}
