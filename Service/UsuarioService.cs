using Microsoft.EntityFrameworkCore;
using MoreResults.API.Dados;
using MoreResults.API.Interface;
using MoreResults.API.Model;

namespace MoreResults.API.Service
{
    public class UsuarioService : IUsuarioService
    {
        public readonly DataContext _context;

        public UsuarioService(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UsuarioDto>> GetUsers(int? id, string? name, string? cpf)
        {
            try
            {
                return await _context.Usuarios.Where(u => (id == null || u.Id == id) &&
                                                        (String.IsNullOrEmpty(name) || u.Name.Contains(name)) &&
                                                        (String.IsNullOrEmpty(cpf) || u.Cpf.Equals(cpf)))
                                                        .ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeleteUser(int idUser)
        {
            try
            {
                var usuario = await _context.Usuarios.FindAsync(idUser);
                if (usuario == null)
                    throw new Exception("Usuário não encontrado!");

                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> InsertUser(InsertUsuarioRequest usuario)
        {
            try
            {
                var usuarioExiste = await _context.Usuarios.Where(u =>
                                                            (String.IsNullOrEmpty(usuario.Cpf) || u.Cpf.Equals(usuario.Cpf))).ToListAsync();
                if (usuarioExiste.Any())
                    throw new Exception("CPF já cadastrado!");

                _context.Usuarios.Add(new UsuarioDto
                {
                    BAIRRO = usuario.BAIRRO,
                    CIDADE = usuario.CIDADE,
                    COMPLEMENTO = usuario.COMPLEMENTO,
                    Cpf = usuario.Cpf,
                    Email = usuario.Email,
                    ESTADO = usuario.ESTADO,
                    Name = usuario.Name,
                    NUMERO = usuario.NUMERO,
                    PONTOREFERENCIA = usuario.PONTOREFERENCIA,
                    RUA = usuario.RUA,
                    Senha = usuario.Senha,
                    Telefone = usuario.Telefone
                });
                await _context.SaveChangesAsync();

                return true;
            }catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<bool> UpdateUser(InsertUsuarioRequest usuario)
        {
            try
            {
                var usuarioExiste = await _context.Usuarios.FindAsync(usuario.Id);
                if (usuarioExiste == null)
                    throw new Exception("Usuário não encontrado!");


                usuarioExiste.BAIRRO = usuario.BAIRRO;
                usuarioExiste.CIDADE = usuario.CIDADE;
                usuarioExiste.COMPLEMENTO = usuario.COMPLEMENTO;
                usuarioExiste.Cpf = usuario.Cpf;
                usuarioExiste.Email = usuario.Email;
                usuarioExiste.ESTADO = usuario.ESTADO;
                usuarioExiste.Name = usuario.Name;
                usuarioExiste.NUMERO = usuario.NUMERO;
                usuarioExiste.PONTOREFERENCIA = usuario.PONTOREFERENCIA;
                usuarioExiste.RUA = usuario.RUA;
                usuarioExiste.Senha = usuario.Senha;
                usuarioExiste.Telefone = usuario.Telefone;
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
