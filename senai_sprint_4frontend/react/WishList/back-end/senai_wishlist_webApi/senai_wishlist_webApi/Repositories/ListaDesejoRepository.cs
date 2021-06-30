using Microsoft.EntityFrameworkCore;
using senai_wishlist_webApi.Contexts;
using senai_wishlist_webApi.Domains;
using senai_wishlist_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_wishlist_webApi.Repositories
{
    public class ListaDesejoRepository : IListaDesejo
    {
        WishListContext ctx = new WishListContext();

        public ListaDesejo BuscarPorId(int id)
        {
            return ctx.ListaDesejos.FirstOrDefault(l => l.IdDesejo == id);
        }

        public void Cadastrar(ListaDesejo novaListaDesejo)
        {
            ctx.ListaDesejos.Add(novaListaDesejo);

            ctx.SaveChanges();
        }

        public List<ListaDesejo> Listar()
        {
            return ctx.ListaDesejos.ToList();
        }

        /*    public List<ListaDesejo> ListarDesejos(int id)
            {
                var listaBuscada = ctx.ListaDesejos.Include(l => l.IdUsuarioNavigation)
                                                   .Where(l => l.IdUsuario == id)
                                                   .Select(l => new ListaDesejo()
                                                   {
                                                       IdDesejo = l.IdDesejo,

                                                       Descriçãodesejo = l.Descriçãodesejo,

                                                       IdUsuarioNavigation = new Usuario()
                                                       {
                                                           IdUsuario = l.IdUsuarioNavigation.IdUsuario,

                                                           Email = l.IdUsuarioNavigation.Email
                                                       }

                                                   });

                return listaBuscada.ToList();
            }*/
    }
}
