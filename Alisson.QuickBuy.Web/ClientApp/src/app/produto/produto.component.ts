import { Component, OnInit } from '@angular/core'
import { Produto } from '../modelo/produto'
import { ProdutoServico } from '../servicos/produto/produto.servico'

@Component({
  selector: "cadastro-produto",
  templateUrl: "./produto.component.html",
  styleUrls: ["./produto.component.css"]
})

export class ProdutoComponent implements OnInit {

  public produto: Produto

  constructor(private produtoServico: ProdutoServico) {

  }
  ngOnInit(): void {
    this.produto = new Produto()
  }

  public cadastrar() {
    //this.produtoServico
    this.produtoServico.cadastrarProduto(this.produto)
      .subscribe(
        produtoJson => {
          console.log(produtoJson)
        },
        e => {
          console.log(e.error)
        }
      )
  }
}
