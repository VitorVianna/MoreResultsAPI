var id = 0;
var vm = new Vue({
    el: '#app',
    data: {
        Usuario: ""
    },
    created: function(){
        var url = getUrlVars();
        if(url.id != undefined){
            id = url.id
            var settings = {
                "url": "https://localhost:7076/Usuario/",
                "method": "GET",
                "timeout": 0,
                "headers": {
                    "id": id
                  },
            };
            
            $.ajax(settings).done(function (retorno) {
                var response = retorno[0];
                $("#txtNome").val(response.name);
                $("#txtEmail").val(response.email);
                $("#txtTelefone").val(response.telefone);
                $("#txtCPF").val(response.cpf);
                $("#txtSenha").val(response.senha);
                $("#txtCEP").val(response.cep);
                $("#txtRua").val(response.rua);
                $("#txtNumero").val(response.numero);
                $("#txtBairro").val(response.bairro);
                $("#txtComplemento").val(response.complemento);
                $("#txtCidade").val(response.cidade);
                $("#txtEstado").val(response.estado);
                $("#txtPontoReferencia").val(response.pontoreferencia);
            });
        }
    }
});

$(document).ready(function () {
    $("#txtTelefone").mask("(00) 0000-0000");
    $("#txtCPF").mask("000.000.000-00");
    $("#txtCEP").mask("00.000-000");

    $("#Limpar").click(function () {
        $("#formUsuario input").val("");
    });

    $("#Voltar").click(function () {
        Voltar();
    });

    $("#Pesquisar").click(function () {
        PesquisarCEP();
    });

    $("#Salvar").click(function () {
        if(validarForm())
            SalvarEditar();
    });

    $('#show_password').hover(function(e) {
        e.preventDefault();
        if ( $('#txtSenha').attr('type') == 'password' ) {
          $('#txtSenha').attr('type', 'text');
          $('#show_password').attr('class', 'btn btn-info fa fa-eye');
        } else {
            $('#txtSenha').attr('type', 'password');
            $('#show_password').attr('class', 'btn btn-info fa fa-eye-slash');
        }
      });
});
function Voltar(){
    window.location.replace("index.html");
}
function SalvarEditar(){
    var settings = {
        "url": "https://localhost:7076/Usuario/",
        "method": id == 0 ? "POST" : "PUT",
        "timeout": 0,
        "headers": {
          "Content-Type": "application/json"
        },
        "data": JSON.stringify(
            {
                "id": parseInt(id),
                "name": $("#txtNome").val(),
                "email": $("#txtEmail").val(),
                "telefone": $("#txtTelefone").val(),
                "cpf": $("#txtCPF").val(),
                "cep": $("#txtCEP").val(),
                "senha": $("#txtSenha").val(),
                "rua": $("#txtRua").val(),
                "numero": parseInt($("#txtNumero").val()),
                "bairro": $("#txtBairro").val(),
                "complemento": $("#txtComplemento").val(),
                "cidade": $("#txtCidade").val(),
                "estado": $("#txtEstado").val(),
                "pontoreferencia": $("#txtPontoReferencia").val(),
            }
        ),
    };
    $.ajax(settings).done(function (response) {
        if(response){
            alert("Usuário salvo com sucesso!");
            Voltar();
        }
        else
            alert("Erro ao salvar usuário.")
    });
}



function validarForm() {
    if ($("#txtNome").val() == "" || $("#txtEmail").val() == "" || $("#txtCPF").val() == "" || $("#txtSenha").val() == "") {
        alert("Campos: Nome, Email, CPF e Senha são obrigatórios.")
        return false;
    }
    return true;
}




function PesquisarCEP(){
    var cep = $("#txtCEP").val();
    if(cep == ""){
        return alert("Digite um CEP válido.");
    }
    $("#txtRua").val("...");
    $("#txtBairro").val("...");
    $("#txtCidade").val("...");
    $("#txtEstado").val("...");
    $("#txtComplemento").val("...");

    cep = cep.replace(".","").replace("-","")
    var settings = {
        "url": "https://viacep.com.br/ws/"+cep+"/json/",
        "method": "GET",
        "timeout": 0,
      };
      
      $.ajax(settings).done(function (response) {
        $("#txtRua").val(response.logradouro);
        $("#txtBairro").val(response.bairro);
        $("#txtCidade").val(response.localidade);
        $("#txtEstado").val(response.uf);
        $("#txtComplemento").val(response.complemento);
      });
}