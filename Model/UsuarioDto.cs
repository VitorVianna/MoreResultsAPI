using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoreResults.API.Model
{
    public class UsuarioDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }
        public string? Cpf { get; set; }
        public string Senha { get; set; }
        public string? RUA { get; set; }
        public int? NUMERO { get; set; }
        public string? BAIRRO { get; set; }
        public string? COMPLEMENTO { get; set; }
        public string? CIDADE { get; set; }
        public string? ESTADO { get; set; }
        public string? PONTOREFERENCIA { get; set; }
    }
}
