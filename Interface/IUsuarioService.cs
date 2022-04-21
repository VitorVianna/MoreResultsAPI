using MoreResults.API.Model;

namespace MoreResults.API.Interface
{
    public interface IUsuarioService
    {
        Task<IEnumerable<UsuarioDto>> GetUsers(int? id, string? name, string? cpf);
        Task<bool> DeleteUser(int idUser);
        Task<bool> InsertUser(InsertUsuarioRequest usuario);
        Task<bool> UpdateUser(InsertUsuarioRequest usuario);
    }
}
