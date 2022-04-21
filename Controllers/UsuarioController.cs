using Microsoft.AspNetCore.Mvc;
using MoreResults.API.Interface;
using MoreResults.API.Model;
using System.Net;

namespace MoreResults.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        public readonly IUsuarioService _usuarioService;
        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet(Name = "GetUsers")]
        public async Task<IEnumerable<UsuarioDto>> Get([FromHeader] int? id, string? name, string? cpf)
        {
            return await _usuarioService.GetUsers(id, name, cpf);
        }

        [HttpDelete(Name = "DeleteUser")]
        public async Task<IActionResult> Delete([FromHeader] int idUser)
        {
            return Ok(await _usuarioService.DeleteUser(idUser));
        }

        [HttpPost(Name = "InsertUser")]
        public async Task<IActionResult> Insert([FromBody] InsertUsuarioRequest request)
        {
            if (!Validations.Validation.IsUserValid(request))
                return BadRequest("Dados obrigatórios não preenchidos!");

            if (!String.IsNullOrEmpty(request.Cpf) && !Validations.Validation.IsCPFValid(request.Cpf))
                return BadRequest("CPF Inválido!");

            return Ok(await _usuarioService.InsertUser(request));
        }

        [HttpPut(Name = "UpdateUser")]
        public async Task<IActionResult> Update([FromBody] InsertUsuarioRequest request)
        {
            if (!Validations.Validation.IsUserValid(request))
                return BadRequest("Dados obrigatórios não preenchidos!");

            if (!String.IsNullOrEmpty(request.Cpf) && !Validations.Validation.IsCPFValid(request.Cpf))
                return BadRequest("CPF Inválido!");

            return Ok(await _usuarioService.UpdateUser(request));
        }
    }
}
