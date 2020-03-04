import { Produto } from "../../modelo/produto";

export class LojaCarrinhoCompras {
  public produtos: Produto[] = [];

  public adicionar(produto: Produto) {
    var produtoLocalStorage = localStorage.getItem("produtosCarrinho")
    if (!produtoLocalStorage) {
      this.produtos.push(produto)
      
    }
    else {
      this.produtos = JSON.parse(produtoLocalStorage);
      this.produtos.push(produto)
      
    }
    localStorage.setItem("produtosCarrinho", JSON.stringify(this.produtos))
  }
  public ObterProdutos(): Produto[] {
    var produtoLocalStorage = localStorage.getItem("produtosCarrinho")
    if (produtoLocalStorage) {
      return JSON.parse(produtoLocalStorage)
    }
    
  }
  public RemoverProduto(produto: Produto) {

  }
}
