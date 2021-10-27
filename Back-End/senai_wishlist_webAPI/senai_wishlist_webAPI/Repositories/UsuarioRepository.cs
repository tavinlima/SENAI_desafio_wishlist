using senai_wishlist_webAPI.Contexts;
using senai_wishlist_webAPI.Domains;
using senai_wishlist_webAPI.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_wishlist_webAPI.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        readonly WishListContext context = new();
        public void AtualizarURL(int idUsuario, Usuario usuarioAtualizado)
        {
            Usuario usuarioBuscado = context.Usuarios.Find(idUsuario);

            if (usuarioAtualizado.Email != null || usuarioAtualizado.Senha != null)
            {
                usuarioBuscado.Email = usuarioAtualizado.Email;
                usuarioBuscado.Senha = usuarioAtualizado.Senha;

                context.Usuarios.Update(usuarioBuscado);

                context.SaveChanges();
            }
        }

        public Usuario BuscarPorID(int idUsuario)
        {
            return context.Usuarios
                .Select(u => new Usuario
                {
                    Email = u.Email,
                })
                .FirstOrDefault(u => u.IdUsuario == idUsuario);

        }

        public void Cadastrar(Usuario novoUsuario)
        {
            context.Usuarios.Add(novoUsuario);

            context.SaveChanges();

        }

        public List<Usuario> ListarTodos()
        {
            return context.Usuarios
                .Select(u => new Usuario
                {
                    Email = u.Email,
                })
                .ToList();
        }

        public void Remover(int idUsuario)
        {
            context.Usuarios.Remove(BuscarPorID(idUsuario));

            context.SaveChanges();
        }
    }
}
