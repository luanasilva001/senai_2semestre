using Microsoft.EntityFrameworkCore;
using senai.roman.webApi.Contexts;
using senai.roman.webApi.Domains;
using senai.roman.webApi.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace senai.roman.webApi.Repositories
{
    public class TemaRepository : ITemasRepository
    {
        RomanContext ctx = new RomanContext();

        public void Cadastrar(Tema novoTema)
        {
            ctx.Temas.Add(novoTema);

            ctx.SaveChanges();
        }

        public List<Tema> Listar()
        {
            var temaBuscado = ctx.Temas.Include(t => t.IdUsuarioNavigation)
                                       .Select(t => new Tema()

                                      {
                                          IdTema = t.IdTema,

                                          TituloTema = t.TituloTema,

                                          IdUsuarioNavigation = new Usuario()
                                          {
                                              IdUsuario = t.IdUsuarioNavigation.IdUsuario,

                                              NomeUsuario = t.IdUsuarioNavigation.NomeUsuario
                                          }
                                      });

            return temaBuscado.ToList();
        }

        public List<Tema> ListarTemas(int id)
        {
            var temaBuscado = ctx.Temas.Include(t => t.IdUsuarioNavigation)
                                       .Where(t => t.IdUsuario == id)
                                       .Select(t => new Tema()

                                       {
                                           IdTema = t.IdTema,

                                           TituloTema = t.TituloTema,

                                           IdUsuarioNavigation = new Usuario()
                                           {
                                               IdUsuario = t.IdUsuarioNavigation.IdUsuario,

                                               NomeUsuario = t.IdUsuarioNavigation.NomeUsuario
                                           }
                                       });

            return temaBuscado.ToList();
        }
    }
}
