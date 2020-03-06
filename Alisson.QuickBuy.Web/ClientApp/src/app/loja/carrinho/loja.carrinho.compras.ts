import { Produto } from "../../modelo/produto";

export class LojaCarrinhoCompras {
  public produtos: Produto[] = [];

  public adicionar(produto: Produto) {
    var produtoLocalStorage = localStorage.getItem("produtosCarrinho")
    if (!produtoLocalStorage) {
      produto.quantidade = 1
      this.produtos.push(produto)
      
    }
    else {
      this.produtos = JSON.parse(produtoLocalStorage);
      produto.quantidade = 1
      this.produtos.push(produto)
    }
    localStorage.setItem("produtosCarrinho", JSON.stringify(this.produtos))
  }
  public ObterProdutos(): Produto[] {
    var produtoLocalStorage = localStorage.getItem("produtosCarrinho")
    if (produtoLocalStorage) {
      return JSON.parse(produtoLocalStorage)
    }
    else {
      return this.produtos
    }
  }
  public salvarCarrinho(prods: Produto[]) {
    console.log(`Lista de produtos: ${JSON.stringify(prods)}` )
    localStorage.setItem("produtosCarrinho", JSON.stringify(prods))
  }
  public RemoverProduto(produto: Produto) {
    this.produtos = JSON.parse(localStorage.getItem("produtosCarrinho"))
    this.produtos = this.produtos.filter(prd => prd.id != produto.id)
    localStorage.setItem("produtosCarrinho", JSON.stringify(this.produtos))
  }
  public temItensCarrinho(): boolean {
    return this.ObterProdutos().length > 0
  }
}
