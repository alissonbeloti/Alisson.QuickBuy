import { Injectable, Inject, OnInit } from "@angular/core"
import { HttpClient, HttpHeaders } from "@angular/common/http"
import { Observable } from "rxjs"
import { Pedido } from "../../modelo/pedido"

@Injectable({
  providedIn: "root"
})
export class PedidoServico implements OnInit {
  private baseURL: string
  public pedidos: Pedido[]

  constructor(private http: HttpClient, @Inject("BASE_URL") baseUrl: string) {
    this.baseURL = baseUrl
  }
  ngOnInit(): void {
    this.pedidos = [];
  }

  get headers(): HttpHeaders {
    return new HttpHeaders().set('content-type', 'application/json')
  }

   public efetivarPedido(pedido: Pedido): Observable<number> {
    //post
    return this.http.post<number>(`${this.baseURL}pedido`, JSON.stringify(pedido), { headers: this.headers });
  }

  public salvar(pedido: Pedido): Observable<Pedido> {
    //put
    return this.http.put<Pedido>(`${this.baseURL}produto`, JSON.stringify(pedido), { headers: this.headers });
  }

  public obterPedido(pedidoId: number): Observable<Pedido> {
    //delete
    return this.http.get<Pedido>(`${this.baseURL}pedido/${pedidoId}`);
  }
}
