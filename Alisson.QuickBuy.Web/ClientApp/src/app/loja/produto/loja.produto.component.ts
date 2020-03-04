import { Component, OnInit } from '@angular/core'
import { Produto } from '../../modelo/produto'
import { ProdutoServico } from '../../servicos/produto/produto.servico'
import { Router } from '@angular/router'
import { LojaCarrinhoCompras } from '../carrinho/loja.carrinho.compras'

@Component({
  selector: "loja-app-produto",
  templateUrl: "./loja.produto.component.html",
  styleUrls: ["./loja.produto.component.css"]
})

export class LojaProdutoComponent implements OnInit {
  public ativarSpinner: boolean
  public produto: Produto
  public carrinho: LojaCarrinhoCompras;

  constructor(private produtoServico: ProdutoServico, private router: Router) {

  }
  ngOnInit(): void {
    this.carrinho = new LojaCarrinhoCompras()
    var produtoSessao = sessionStorage.getItem('produtoDetalhe')
    if (produtoSessao) {
      this.produto = JSON.parse(produtoSessao)
    }
  }

  public comprar() {
    this.carrinho.adicionar(this.produto)
    this.router.navigate(['/loja-efetivar'])
  }
}
