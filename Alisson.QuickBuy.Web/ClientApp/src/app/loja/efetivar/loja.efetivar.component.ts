import { Component, OnInit } from '@angular/core'
import { Produto } from '../../modelo/produto'
import { ProdutoServico } from '../../servicos/produto/produto.servico'
import { Router } from '@angular/router'
import { LojaCarrinhoCompras } from '../carrinho/loja.carrinho.compras'


@Component({
  selector: "app-loja-efetivar",
  templateUrl: "./loja.efetivar.component.html",
  styleUrls: ["./loja.efetivar.component.css"]
})

export class LojaEfetivarComponent implements OnInit {
  public carrinho: LojaCarrinhoCompras
  public produtos: Produto[]
  public mensagem: string
  public total: number

  constructor(private produtoServico: ProdutoServico, private router: Router) {

  }

  ngOnInit(): void {
    this.carrinho = new LojaCarrinhoCompras()
    this.produtos = this.carrinho.ObterProdutos()
    this.calcularTotal()
  }
  //Voltar depois e corrigir tudo para itens carrinho {isso me lembrou o André Fiche}
  atualizarPreco(p: Produto) {
    if (p.quantidade <= 0) {
      p.quantidade = 1
    }
    if (!p.precoUnitario) p.precoUnitario = p.preco
    p.preco = p.precoUnitario * p.quantidade
    this.carrinho.salvarCarrinho(this.produtos)
    this.calcularTotal()
  }
  public remover(p: Produto) {
    this.carrinho.RemoverProduto(p)
    this.produtos = this.carrinho.ObterProdutos()
    this.calcularTotal()
  }
  private calcularTotal() {
    this.total = this.produtos.reduce((acc, produto) => acc + produto.preco, 0) //é um acumulador de valor
  }
}
