import { Component, OnInit } from '@angular/core'
import { Usuario } from '../../modelo/usuario';
import { Router, ActivatedRoute } from '@angular/router';
@Component({
  selector: "app-login",
  templateUrl: "./login.component.html",
  styleUrls: ["./login.component.css"]
})
export class LoginComponent implements OnInit {
    public usuario
  public returnUrl = ''
  constructor(private router: Router, private activatedRouter: ActivatedRoute) {
    
  }
    ngOnInit(): void {
      this.usuario = new Usuario()
      this.returnUrl = this.activatedRouter.snapshot.queryParams['returnUrl']
    }

  entrar() {
    if (this.usuario.email == "alisson@teste.com" && this.usuario.senha == "abc123") {
      sessionStorage.setItem("usuario-autenticado", "1")
      this.router.navigate([this.returnUrl])
    }
  }
  onKeypress() {

  }
}
