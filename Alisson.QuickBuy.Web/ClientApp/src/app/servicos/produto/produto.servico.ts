import { Injectable, Inject, OnInit } from "@angular/core"
import { HttpClient, HttpHeaders } from "@angular/common/http"
import { Observable } from "rxjs"
import { Produto } from "../../modelo/produto"

@Injectable({
  providedIn: "root"
})
export class ProdutoServico implements OnInit {
  private baseURL: string
  public produtos: Produto[]

  constructor(private http: HttpClient, @Inject("BASE_URL") baseUrl: string) {
    this.baseURL = baseUrl
  }
  ngOnInit(): void {
    this.produtos = [];
  }

  get headers(): HttpHeaders {
    return new HttpHeaders().set('content-type', 'application/json')
  }

  public produtoValidado(_produto: Produto): boolean {
    return _produto != null && _produto.nome != "" && _produto.preco > 0
  }

  public cadastrarProduto(produto: Produto): Observable<Produto> {
    //post
    return this.http.post<Produto>(`${this.baseURL}produto`, JSON.stringify(produto), { headers: this.headers });
  }

  public salvar(produto: Produto): Observable<Produto> {
    //put
    return this.http.put<Produto>(`${this.baseURL}produto`, JSON.stringify(produto), { headers: this.headers });
  }

  public deletar(id: string): Observable<Produto[]> {
    //delete
    return this.http.delete<Produto[]>(`${this.baseURL}produto/${id}`, { headers: this.headers });
  }

  public obterTodosProdutos(): Observable<Produto[]> {
    //delete
    return this.http.get<Produto[]>(`${this.baseURL}produto`);
  }

  public obterProduto(produtoId: number): Observable<Produto> {
    //delete
    return this.http.get<Produto>(`${this.baseURL}produto/${produtoId}`);
  }

  public enviarArquivo(arquivoSelecionado: File): Observable<any> {
    const formData: FormData = new FormData()
    formData.append("arquivoEnviado", arquivoSelecionado, arquivoSelecionado.name)
    return this.http.post<string>(`${this.baseURL}produto/enviarArquivo`, formData)
  }
}
