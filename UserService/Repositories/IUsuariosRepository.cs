using UserService.Model;

namespace UserService.Repositories
{
    public interface IUsuariosRepository
    {
        Task<IEnumerable<Usuario>> GetUsuarios();
        Task<Usuario> GetUsuario(int id);
        Task<Usuario> CreateUsuario(Usuario usuario);
        Task<Usuario> UpdateUsuario(Usuario usuario);
        Task DeleteUsuario(int id);
    }
}
