import { ItemPedido } from "./itemPedido"

export class Pedido {
  id: number
  dataPedido: Date
  usuarioId: number
  previsaoEntrega: Date 
  cep: string
  estado: string
  cidade: string
  enderecoCompleto: string
  formaPagamentoId: number
  itensPedido: ItemPedido[]
  constructor() {
    this.itensPedido = []
    this.dataPedido = new Date()
    this.previsaoEntrega = new Date()
  }
}
