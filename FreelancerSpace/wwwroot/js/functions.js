function searchServProd(servprod, callback) {
    let result;
    $.ajax({
        type: "GET",
        url: "/ProdutosServicos/Listar?name=" + servprod,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (jsonResult) {
            //console.log(jsonResult);
            callback(jsonResult);
        },
        failure: function (response) {
            alert("Erro ao carregar os dados: " + response);
            callback(null);
        }
    });
}

function soma(a, b){
    return a + b;
}