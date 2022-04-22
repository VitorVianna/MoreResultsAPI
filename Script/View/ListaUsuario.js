var vm = new Vue({
    el: '#app',
    data: {
        user: 'abc',
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
        alert('Editando: ' + id);
      },
      Excluir(id) {
        alert('Excluindo: ' + id);
      }
    }

    
});
