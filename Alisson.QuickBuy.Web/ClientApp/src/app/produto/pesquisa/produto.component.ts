import { Component, OnInit } from '@angular/core'
import { Produto } from '../modelo/produto'
import { ProdutoServico } from '../servicos/produto/produto.servico'

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

  constructor(private produtoServico: ProdutoServico) {

  }
  ngOnInit(): void {
    this.produto = new Produto()
    this.cadastrado = false
    this.mensagem = null
  }

  public cadastrar() {
    this.ativarSpinner = true
    this.mensagem = null
    this.produtoServico.cadastrarProduto(this.produto)
      .subscribe(
        produtoJson => {
          console.log(produtoJson)
          this.ativarSpinner = false
          this.cadastrado = true
        },
        e => {
          console.log(e.error)
          this.mensagem = e.error
          this.ativarSpinner = false
        }
      )
  }

  public inputChange(files: FileList) {
    this.arquivoSelecionado = files.item(0)
    this.ativarSpinner = true
    this.produtoServico.enviarArquivo(this.arquivoSelecionado)
      .subscribe(
        ok => {
          alert(ok.nomeArquivo)
          this.produto.nomeArquivo = ok.nomeArquivo
          console.log("nome retorno: " + ok.nomeArquivo)
          this.ativarSpinner = false
          //this.cadastrado = true
        }, e => {
          alert(e.error)
          this.produto.nomeArquivo = ""
          this.ativarSpinner = false
          //this.cadastrado = false
      })
  }
}
