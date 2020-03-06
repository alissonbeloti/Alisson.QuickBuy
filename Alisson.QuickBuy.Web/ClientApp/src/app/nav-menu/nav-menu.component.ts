import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UsuarioServico } from '../servicos/usuario/usuario.servico';
import { LojaCarrinhoCompras } from '../loja/carrinho/loja.carrinho.compras';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit {
  public ehAdministrador: boolean = false
  public carrinhoCompras: LojaCarrinhoCompras

  get usuario() {
    return this.usuarioServico.usuario
  }

  constructor(private router: Router, private usuarioServico: UsuarioServico) {

  }
  ngOnInit(): void {
    this.carrinhoCompras = new LojaCarrinhoCompras()
  }
  isExpanded = false;

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  public usuarioLogado(): boolean {
    //var usuarioLogado = sessionStorage.getItem("usuario-autenticado")
    //if (usuarioLogado == "1") {
    //  return true;
    //}
    //return false;
    var usuario = this.usuarioServico.usuario
    if (usuario != null) {
      this.ehAdministrador = usuario.ehAdministrador
    }

    return this.usuarioServico.usuarioAutenticado()
  }
  sair() {
    //sessionStorage.setItem("usuario-autenticado", "")
    this.usuarioServico.limparSessao()
    this.router.navigate(['/'])
    this.ehAdministrador = false
  }
  temItensCarrinho(): boolean {
    return this.carrinhoCompras.temItensCarrinho()
  }
}
