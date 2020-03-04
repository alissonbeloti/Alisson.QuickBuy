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
  
  constructor(private produtoServico: ProdutoServico, private router: Router) {
    
  }

  ngOnInit(): void {
    this.carrinho = new LojaCarrinhoCompras()
    this.produtos = this.carrinho.ObterProdutos()
  }

}
