import { Component, OnInit } from '@angular/core'
import { Produto } from '../modelo/produto'
import { ProdutoServico } from '../servicos/produto/produto.servico'
import { Router } from '@angular/router'

@Component({
  selector: "cadastro-produto",
  templateUrl: "./produto.component.html",
  styleUrls: ["./produto.component.css"]
})

export class ProdutoComponent implements OnInit {
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

  public cadastrar() {
    this.ativarSpinner = true
    this.mensagem = null
    if (this.produto.id > 0) {
      this.produtoServico.salvar(this.produto)
        .subscribe(
          produtoJson => {
            this.ativarSpinner = false
            this.cadastrado = true
            this.router.navigate(['/pesquisar-produto'])
          },
          e => {
            console.log(e.error)
            this.mensagem = e.error
            this.ativarSpinner = false
          }
        )
    }
    else {
      this.produtoServico.cadastrarProduto(this.produto)
        .subscribe(
          produtoJson => {
            console.log(produtoJson)
            this.ativarSpinner = false
            this.cadastrado = true
            this.router.navigate(['/pesquisar-produto'])
          },
          e => {
            console.log(e.error)
            this.mensagem = e.error
            this.ativarSpinner = false
          }
        )
    }
  }

  public inputChange(files: FileList) {
    this.arquivoSelecionado = files.item(0)
    this.ativarSpinner = true
    this.produtoServico.enviarArquivo(this.arquivoSelecionado)
      .subscribe(
        ok => {
          this.produto.nomeArquivo = ok.nomeArquivo
          console.log("nome retorno: " + ok.nomeArquivo)
          this.ativarSpinner = false
          //this.cadastrado = true
        }, e => {
          this.produto.nomeArquivo = ""
          this.ativarSpinner = false
          //this.cadastrado = false
      })
  }
}
