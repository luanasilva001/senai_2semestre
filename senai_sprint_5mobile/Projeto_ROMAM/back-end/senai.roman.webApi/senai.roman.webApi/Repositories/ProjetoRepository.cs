using Microsoft.EntityFrameworkCore;
using senai.roman.webApi.Contexts;
using senai.roman.webApi.Domains;
using senai.roman.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.roman.webApi.Repositories
{
    public class ProjetoRepository : IProjetoRepository
    {
        RomanContext ctx = new RomanContext();

        public void Cadastrar(Projeto novoProjeto)
        {
            ctx.Projetos.Add(novoProjeto);

            ctx.SaveChanges();
        }

        public List<Projeto> ListarProjetos(int id)
        {
            var projetoBuscado = ctx.Projetos.Include(p => p.IdUsuarioNavigation)
                                             .Include(p => p.IdTemaNavigation)
                                             .Where(p => p.IdUsuario == id)
                                             .Select(p => new Projeto()
                                             {
                                                 IdProjeto = p.IdProjeto,
                                                 Projeto1 = p.Projeto1,

                                                 IdTemaNavigation = new Tema()
                                                 {
                                                     IdTema = p.IdTemaNavigation.IdTema,
                                                     TituloTema = p.IdTemaNavigation.TituloTema
                                                 },

                                                 IdUsuarioNavigation = new Usuario()
                                                 {
                                                     IdUsuario = p.IdUsuarioNavigation.IdUsuario,

                                                     NomeUsuario = p.IdUsuarioNavigation.NomeUsuario
                                                 }
                                             });
            return projetoBuscado.ToList();
        }

        public List<Projeto> Listar()
        {
            var projetoBuscado = ctx.Projetos.Include(p => p.IdUsuarioNavigation)
                                             .Include(p => p.IdTemaNavigation)
                                             .Include(p => p.IdUsuarioNavigation)
                                             .Select(p => new Projeto()
                                             {
                                                 IdProjeto = p.IdProjeto,
                                                 Projeto1 = p.Projeto1,

                                                 IdTemaNavigation = new Tema()
                                                 {
                                                     IdTema = p.IdTemaNavigation.IdTema,
                                                     TituloTema = p.IdTemaNavigation.TituloTema
                                                 },

                                                 IdUsuarioNavigation = new Usuario()
                                                 {
                                                     IdUsuario = p.IdUsuarioNavigation.IdUsuario,

                                                     NomeUsuario = p.IdUsuarioNavigation.NomeUsuario
                                                 }
                                             });
            return projetoBuscado.ToList();
        }
    }
}
