import { Component, OnInit } from '@angular/core'
import { UsuarioServico } from '../../servicos/usuario/usuario.servico'
import { Usuario } from '../../modelo/usuario'

@Component({
  selector: "cadastro-usuario",
  templateUrl: './cadastro.usuario.component.html',
  styleUrls: ['./cadastro.usuario.component.css']
})

export class CadastroUsuarioComponent implements OnInit {
  public mensagem: string
  public ativar_spinner: boolean
  public usuario: Usuario
  public usuarioCadastrado: boolean
  constructor(private usuarioServico: UsuarioServico) {

  }
    ngOnInit(): void {
      this.usuario = new Usuario()
  }
  public cadastrarUsuario() {
    this.ativar_spinner = true
    this.usuarioServico.cadastrarUsuario(this.usuario)
      .subscribe(
        usuarioJson => {
          this.usuarioCadastrado = true
          this.mensagem = ""
          this.ativar_spinner = false
        },
        err => {
          this.usuarioCadastrado = false
          this.mensagem = err.error;
          this.ativar_spinner = false
        }
      )
  }
}
