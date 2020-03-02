import { Component, OnInit } from '@angular/core'
import { Produto } from '../../modelo/produto'
import { ProdutoServico } from '../../servicos/produto/produto.servico'
import { Router } from '@angular/router'


@Component({
  selector: "pesquisa-produto",
  templateUrl: "./pesquisa.produto.component.html",
  styleUrls: ["./pesquisa.produto.component.css"]
})

export class PesquisaProdutoComponent implements OnInit {
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

  public adicionarProduto() {
    console.log('AdicionarProduto')
    this.router.navigate(['/cadastro-produto'])
  }
  public deletarProduto(id: string) {
    var retorno = confirm("Deseja realmente excluir esse produto?")
    this.ativarSpinner = true
    if (retorno) {
      this.produtoServico.deletar(id)
        .subscribe(produtos => {
          this.produtos = produtos
          this.ativarSpinner = false
        },
          e => {
            this.mensagem = e.error
            this.ativarSpinner = false
          })
    }
  }
  public editarProduto(produto: Produto) {
    sessionStorage.setItem('produtoEditar', JSON.stringify(produto))
    this.router.navigate(['/cadastro-produto'])
  }

}
