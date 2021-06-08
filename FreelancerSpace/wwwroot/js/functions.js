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


function validarTelefone(telefone) {
    var regex = new RegExp('^\\([0-9]{2}\\)((3[0-9]{3}-[0-9]{4})|(9[0-9]{3}-[0-9]{5}))$');
    if (regex.test(telefone)) {
        console.log("Telefone Válido");
        return true;
    }
    else {
        console.log("Telefone Inválido");
        return false;
    }
}