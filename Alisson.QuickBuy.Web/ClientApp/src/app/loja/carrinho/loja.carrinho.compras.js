"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var LojaCarrinhoCompras = /** @class */ (function () {
    function LojaCarrinhoCompras() {
        this.produtos = [];
    }
    LojaCarrinhoCompras.prototype.adicionar = function (produto) {
        var produtoLocalStorage = localStorage.getItem("produtosCarrinho");
        if (!produtoLocalStorage) {
            this.produtos.push(produto);
        }
        else {
            this.produtos = JSON.parse(produtoLocalStorage);
            this.produtos.push(produto);
        }
        localStorage.setItem("produtosCarrinho", JSON.stringify(this.produtos));
    };
    LojaCarrinhoCompras.prototype.ObterProdutos = function () {
        var produtoLocalStorage = localStorage.getItem("produtosCarrinho");
        if (produtoLocalStorage) {
            return JSON.parse(produtoLocalStorage);
        }
    };
    LojaCarrinhoCompras.prototype.RemoverProduto = function (produto) {
    };
    return LojaCarrinhoCompras;
}());
exports.LojaCarrinhoCompras = LojaCarrinhoCompras;
//# sourceMappingURL=loja.carrinho.compras.js.map