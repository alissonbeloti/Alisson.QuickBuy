import { Component, OnInit } from '@angular/core'
import { Produto } from '../../modelo/produto'
import { ProdutoServico } from '../../servicos/produto/produto.servico'
import { Router } from '@angular/router'


@Component({
  selector: "app-loja",
  templateUrl: "./loja.pesquisa.component.html",
  styleUrls: ["./loja.pesquisa.component.css"]
})

export class LojaPesquisaComponent implements OnInit {
  public ativarSpinner: boolean
  public produtos: Produto[]
  public mensagem: string
  
  ngOnInit(): void {
    this.produtos = []
    this.mensagem = null
  }

  constructor(private produtoServico: ProdutoServico, private router: Router) {
    this.ativarSpinner = true
    this.produtoServico.obterTodosProdutos()
      .subscribe(produtos => {
        this.produtos = produtos
        this.ativarSpinner = false
      },
        e => {
          console.log(e.error)
          this.mensagem = e.error
          this.ativarSpinner = false
        })
  }
  public abrirProduto(p: Produto) {
    sessionStorage.setItem('produtoDetalhe', JSON.stringify(p))
    this.router.navigate(['/loja-produto'])
  }
}
