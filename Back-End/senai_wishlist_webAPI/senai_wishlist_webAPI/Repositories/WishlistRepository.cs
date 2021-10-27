using senai_wishlist_webAPI.Contexts;
using senai_wishlist_webAPI.Domains;
using senai_wishlist_webAPI.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_wishlist_webAPI.Repositories
{
    public class WishlistRepository : IWishlistRepository
    {
        readonly WishListContext context = new();
        public Wishlist BuscarPorID(int idWishlist)
        {
            return context.Wishlists
                .Select(w => new Wishlist
                {
                    IdWishlist = w.IdWishlist,
                    Desejo = w.Desejo,
                    IdUsuarioNavigation = new Usuario()
                    {
                        Username = w.IdUsuarioNavigation.Username,
                        Email = w.IdUsuarioNavigation.Email,
                    },
                })
                .FirstOrDefault(p => p.IdWishlist == idWishlist);
        }

        public void Cadastrar(Wishlist novoDesejo)
        {
            context.Wishlists.Add(novoDesejo);

            context.SaveChanges();
        }

        public List<Wishlist> ListarTodos()
        {
            return context.Wishlists
               .Select(w => new Wishlist
               {
                   IdWishlist = w.IdWishlist,
                   Desejo = w.Desejo,
                   IdUsuarioNavigation = new Usuario()
                   {
                       Username = w.IdUsuarioNavigation.Username,
                       Email = w.IdUsuarioNavigation.Email,
                   },
               })
               .ToList();
        }
    }
}
