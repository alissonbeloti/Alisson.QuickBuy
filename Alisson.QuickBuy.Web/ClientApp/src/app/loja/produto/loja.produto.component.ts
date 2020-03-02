import { Component, OnInit } from '@angular/core'
import { Produto } from '../../modelo/produto'
import { ProdutoServico } from '../../servicos/produto/produto.servico'
import { Router } from '@angular/router'

@Component({
  selector: "loja-app-produto",
  templateUrl: "./loja.produto.component.html",
  styleUrls: ["./loja.produto.component.css"]
})

export class LojaProdutoComponent implements OnInit {
  public ativarSpinner: boolean
  public produto: Produto
  public arquivoSelecionado: File
  public mensagem: string
  public cadastrado: boolean

  constructor(private produtoServico: ProdutoServico, private router: Router) {

  }
  ngOnInit(): void {
    var produtoSessao = sessionStorage.getItem('produtoEditar')
    if (produtoSessao) {
      this.produto = JSON.parse(produtoSessao)
    }
    else {
      this.produto = new Produto()
    }
    this.cadastrado = false
    this.mensagem = null
  }

}
