import { Component } from '@angular/core'

@Component({
  selector: "produto",
  template: "<html><body>{{obterNome()}}</body></html>",
})

export class ProdutoComponent {
  public nome: string
  public liberadoParaVenda: boolean
  constructor() {
    this.nome = 'Teste'
  }
  public obterNome(): string {
    return this.nome
  }
}
