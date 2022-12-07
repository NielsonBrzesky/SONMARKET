// @ts-nocheck
// console.log("Olá Mundo tá sussa!!!!!");
// console.log($);
/** Declaração de variaveis */
var enderecoProduto = "http://localhost:5232/Produtos/Produto/";
var produto;
var compra = [];
var _totalVenda_ = 0.0;

/**Inicio*/
$("#idPosVenda").hide();
atualizarTotal();

/**Função */
function atualizarTotal() {
    $("#totalVenda").html(_totalVenda_.toString());
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

/**Finalizar a Venda*/

$("#idFinalizarVenda").click(function() {
	if(_totalVenda_ <= 0) {
		alert("Compra inválida, nehum produto foi adicionado!")
		return;
	}

	var _valorPago = $("#idValorPago").val();
	console.log(typeof _valorPago);
	if(!isNaN(_valorPago)) {//isnan -> Not a Number/ não é um número.
		_valorPago = parseFloat(_valorPago);
		_totalVenda_ = parseFloat(_totalVenda_);
		if(_valorPago >= _totalVenda_) {
			
			$("#idPosVenda").show();
			$("#idPreVenda").hide();
			$("#idValorPago").prop("disabled", true);

			var _troco = _valorPago - _totalVenda_;
			$("#idTroco").val(_troco);

			/** Metodo que trata a questão do array aninhado um dentro dop outro, 
			 * tratando para cada base tenha suas proprias informações.
			 * Processando o Array de compra.
			 */
			compra.forEach(elemento => {
				elemento.produto = elemento.produto.id;
			});
			//Enviando os dados ao Back-End

		} else {
			alert("Valor pago é muito baixo!")
		}

	} else {
		alert("Valor pago, inválido!");
		return;
	}
});

function restaurarModal() {
	$("#idPosVenda").hide();
	$("#idPreVenda").show();
	$("#idValorPago").prop("disabled", false);
	$("#idTroco").val("");
	$("#idValorPago").val("");
}

$("#idFecharModal").click(function() {
	restaurarModal();
})