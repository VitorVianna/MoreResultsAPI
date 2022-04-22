var vm = new Vue({
    el: '#app',
    data: {
        Usuarios: ""
    },
    created: function(){
        var settings = {
            "url": "https://localhost:7076/Usuario/",
            "method": "GET",
            "timeout": 0,
          };
          
          $.ajax(settings).done(function (response) {
            vm.Usuarios = response;
          });
    },
    methods: {
      Editar(id) {
        Edicao(id);
      },
      Excluir(id) {
        Exclusao(id);
      }
    }
});

$(document).ready(function () {
  $("#NovoUsuario").click(function () {
    window.location.replace("FormUsuario.html");
  });
});

function Edicao(id){
  window.location.replace("FormUsuario.html?id="+id);
}

function Exclusao(id){
  if (confirm("Tem certeza que seja excluir o usuário: " + id) == true) {
    
    var settings = {
      "url": "https://localhost:7076/Usuario/",
      "method": "DELETE",
      "timeout": 0,
      "headers": {
        "idUser": id
      },
    };
    
    $.ajax(settings).done(function (response) {
      alert("Usuário Excluído com sucesso.");
      location.reload();
    });
  }
}