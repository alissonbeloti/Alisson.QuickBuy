import { Component, OnInit } from '@angular/core'
import { Usuario } from '../../modelo/usuario';
import { Router, ActivatedRoute } from '@angular/router';
import { UsuarioServico } from '../../servicos/usuario/usuario.servico'
@Component({
  selector: "app-login",
  templateUrl: "./login.component.html",
  styleUrls: ["./login.component.css"]
})
export class LoginComponent implements OnInit {
  public usuario
  public returnUrl = ''
  public mensagem
  private ativarSpinner: boolean

  constructor(private router: Router, private activatedRouter: ActivatedRoute, private servico: UsuarioServico) {

  }
  ngOnInit(): void {
    this.usuario = new Usuario()
    this.returnUrl = this.activatedRouter.snapshot.queryParams['returnUrl']
  }

  entrar() {
    this.ativarSpinner = true

    this.servico.verificarUsuario(this.usuario)
      .subscribe(
        usuarioJson => {
          //var usuarioRetorno: Usuario = data
          //sessionStorage.setItem("usuario-autenticado", "1")
          //sessionStorage.setItem("email-usuario", usuarioRetorno.email)
          this.servico.usuario = usuarioJson;
          if (this.returnUrl)
            this.router.navigate([this.returnUrl])
          else
            this.router.navigate(['/'])
          this.ativarSpinner = false
        },
        err => {
          console.log(err)
          this.mensagem = err.error
          this.ativarSpinner = false
        }
      )
    //if (this.usuario.email == "alisson@teste.com" && this.usuario.senha == "abc123") {
    //  sessionStorage.setItem("usuario-autenticado", "1")
    //  this.router.navigate([this.returnUrl])
    //}
  }
  cadastrarUsuario() {
    this.router.navigate([`cadastrar-usuario`])
  }
  onKeypress() {

  }
}
