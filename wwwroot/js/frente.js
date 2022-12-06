// console.log("Olá Mundo tá sussa!!!!!");
// console.log($);
/** Declaração de variaveis */
var enderecoProduto = "http://localhost:5232/Produtos/Produto/";
var produto;
var compra = [];
var _totalVenda_ = 0.0;

/**Inicio*/
atualizarTotal();

/**Função */
function atualizarTotal() {
    $("#totalVenda").html(_totalVenda_);
}

function preencherFormulario(dadosProduto) {
    $("#idCampoNome").val(dadosProduto.nome);
    $("#idCampoCategoria").val(dadosProduto.categoria.nome);
    $("#idCampoFornecedor").val(dadosProduto.fornecedor.nome);
    $("#idCampoPreco").val(dadosProduto.precoDeVenda);
}

function zerarFormulario() {
    $("#idCampoNome").val("");
    $("#idCampoCategoria").val("");
    $("#idCampoFornecedor").val("");
    $("#idCampoPreco").val("");
    $("#idCampoQuantidade").val("");
}

function adicionarNatabela(prod, quant) {

    var produtoTemporario = {}; //Clonando o objeto.
    Object.assign(produtoTemporario, produto);//Vai fazer a cópia para não mudar o produto que está dentro do método.
    var venda = {produto: produtoTemporario, quantidade: quant, subtotal: produtoTemporario.precoDeVenda * quant};
    _totalVenda_ += venda.subtotal;
    atualizarTotal();
    compra.push(venda);
    $("#idCompras").append(`<tr>
        <td>${prod.id}</td>
        <td>${prod.nome}</td>
        <td>${quant}</td>
        <td>${prod.precoDeVenda} R$</td>
        <td>${prod.medicao}</td>
        <td>${prod.precoDeVenda * quant}</td>
        <td><button class='btn btn-danger'>Remover</button></td>
    <\tr>`);
}

$("#idProdutoForm").on("submit", function(event) {
    event.preventDefault();
    var produtoParaTabela = produto;
    var quantidade = $("#idCampoQuantidade").val();
    console.log(produtoParaTabela);
    console.log(quantidade);
    adicionarNatabela(produtoParaTabela, quantidade);
    zerarFormulario();
});

/**AJAX*/
$("#pesquisar").click(function() {
    var codProduto = $("#codProduto").val();
    var enderecoTemporario = enderecoProduto+codProduto;
    $.post(enderecoTemporario, function(dados, status) {
        produto = dados;

        var medicao = "";
        switch(produto.medicao) {
            case 0:
                medicao = "Litro";
                break;
            case 1:
                medicao = "Kilo";
                break;
            case 2:
                medicao = "Unidade";
                break;
            default:
                medicao = "Unidade";
                break;
        }
        produto.medicao = medicao;

        preencherFormulario(produto);
        console.log(produto);
    }).fail(function() {
        alert("Produto inválido!!!");
    });
});