import { Component, OnInit } from '@angular/core'
import { Produto } from '../../modelo/produto'
import { ProdutoServico } from '../../servicos/produto/produto.servico'
import { Router } from '@angular/router'
import { LojaCarrinhoCompras } from '../carrinho/loja.carrinho.compras'
import { Pedido } from '../../modelo/pedido'
import { UsuarioServico } from '../../servicos/usuario/usuario.servico'
import { ItemPedido } from '../../modelo/itemPedido'
import { PedidoServico } from '../../servicos/pedido/pedido.servico'


@Component({
  selector: "app-compra-efetivada",
  templateUrl: "./compra.efetivada.component.html",
  styleUrls: ["./loja.efetivar.component.css"]
})

export class CompraEfetivadaComponent implements OnInit {
  public pedidoId: string


  constructor(private usuarioServico: UsuarioServico, private pedidoServico: PedidoServico,private router: Router) {

  }

  ngOnInit(): void {
    this.pedidoId = sessionStorage.getItem("pedidoId")
  }
  //Voltar depois e corrigir tudo para itens carrinho {isso me lembrou o André Fiche}
 
}
