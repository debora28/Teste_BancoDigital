using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using UserService.Migrations;
using UserService.Model;
using System.Net;

namespace UserService.Repositories
{
    public class UsuariosRepository : IUsuariosRepository
    {
        public readonly BancoContext DbContext;
        public UsuariosRepository(BancoContext dbContext)
        {
            DbContext = dbContext;
        }

        async Task<IEnumerable<Usuario>> IUsuariosRepository.GetUsuarios()
        {
            return await DbContext.Usuarios.ToListAsync();
        }

        public async Task<Usuario> GetUsuario(int id)
        {
            var usuario = await DbContext.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                throw new Exception();
            }
            else
            {
                return usuario;
            }
        }

        public async Task<Usuario> CreateUsuario(Usuario usuario)
        {
            DbContext.Add(usuario);
            await DbContext.SaveChangesAsync();
            return usuario;
        }

        public async Task<Usuario> UpdateUsuario(Usuario usuario)
        {
            if (usuario == null)
            {
                throw new Exception();
            }
            else
            {
                DbContext.Entry(usuario).State = EntityState.Modified;
                await DbContext.SaveChangesAsync();
                return usuario;
            }
        }

        public async Task DeleteUsuario(int id)
        {
            var usuarioId = await DbContext.Usuarios.FindAsync(id);
            if (usuarioId == null)
            {
                throw new Exception();
            }
            else
            {
                DbContext.Usuarios.Remove(usuarioId);
                await DbContext.SaveChangesAsync();
            }
        }
    }
}
