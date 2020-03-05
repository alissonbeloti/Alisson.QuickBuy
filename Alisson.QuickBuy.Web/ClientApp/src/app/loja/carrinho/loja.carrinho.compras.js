"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var LojaCarrinhoCompras = /** @class */ (function () {
    function LojaCarrinhoCompras() {
        this.produtos = [];
    }
    LojaCarrinhoCompras.prototype.adicionar = function (produto) {
        var produtoLocalStorage = localStorage.getItem("produtosCarrinho");
        if (!produtoLocalStorage) {
            produto.quantidade = 1;
            this.produtos.push(produto);
        }
        else {
            this.produtos = JSON.parse(produtoLocalStorage);
            produto.quantidade = 1;
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
    LojaCarrinhoCompras.prototype.salvarCarrinho = function (prods) {
        console.log("Lista de produtos: " + JSON.stringify(prods));
        localStorage.setItem("produtosCarrinho", JSON.stringify(prods));
    };
    LojaCarrinhoCompras.prototype.RemoverProduto = function (produto) {
        this.produtos = JSON.parse(localStorage.getItem("produtosCarrinho"));
        this.produtos = this.produtos.filter(function (prd) { return prd.id != produto.id; });
        localStorage.setItem("produtosCarrinho", JSON.stringify(this.produtos));
    };
    return LojaCarrinhoCompras;
}());
exports.LojaCarrinhoCompras = LojaCarrinhoCompras;
//# sourceMappingURL=loja.carrinho.compras.js.map