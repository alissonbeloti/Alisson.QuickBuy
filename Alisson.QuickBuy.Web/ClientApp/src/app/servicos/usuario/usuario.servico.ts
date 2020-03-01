import { Injectable, Inject } from "@angular/core"
import { HttpClient, HttpHeaders } from "@angular/common/http"
import { Observable } from "rxjs"
import { Usuario } from "../../modelo/usuario"

@Injectable({
  providedIn: 'root',
  
})
export class UsuarioServico {
  private baseURL: string
  private _usuario: Usuario

  set usuario(usu: Usuario) {
    sessionStorage.setItem("usuario-autenticado", JSON.stringify(usu))
    this._usuario = usu
  }
  get usuario(): Usuario {
    let usuario_json = sessionStorage.getItem("usuario-autenticado")
    this._usuario = JSON.parse(usuario_json)
    return this._usuario
  }

  get headers(): HttpHeaders {
    return new HttpHeaders().set('content-type', 'application/json')
  }

  constructor(private http: HttpClient, @Inject("BASE_URL") baseUrl: string) {
    this.baseURL = baseUrl
  }

  public usuarioAutenticado(): boolean {
    return this._usuario != null && this._usuario.email != "" && this._usuario.senha != ""
  }

  public limparSessao() {
    sessionStorage.setItem("usuario-autenticado", "")
    this._usuario = null
  }


  public verificarUsuario(usuario: Usuario): Observable<Usuario> {
    
    //var body = {
    //  email: usuario.email,
    //  senha: usuario.senha
    //}
    
    return this.http.post<Usuario>(this.baseURL + "usuario/VerificarUsuario", JSON.stringify(usuario),  { headers: this.headers });
  }
  public cadastrarUsuario(usuario: Usuario): Observable<Usuario> {
    
    //var body = {
    //  email: usuario.email,
    //  senha: usuario.senha,
    //  nome: usuario.nome,
    //  sobreNome: usuario.sobreNome
    //}
    //alert(usuario.email + " - " + this.baseURL + "usuario/VerificarUsuario");
    return this.http.post<Usuario>(`${this.baseURL}usuario`, JSON.stringify(usuario), { headers: this.headers });
  }
}
