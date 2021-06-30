using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using senai.hroads.webApi_.Contexts;
using senai.hroads.webApi_.Domains;
using senai.hroads.webApi_.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Classe responsável pelo repositório das personagens
/// </summary>
namespace senai.hroads.webApi_.Repositories
{
     public class PersonagemRepository : IPersonagemRepository
    {
        /// <summary>
        /// Objeto contexto por onde serão chamados os metódos do EF Core
        /// </summary>
        HroadsContext ctx = new HroadsContext();

        /// <summary>
        /// Atualiza uma personagem existente
        /// </summary>
        /// <param name="id">ID da personagem que será atualizada</param>
        /// <param name="personagemAtualizada">Objeto personagemAtualizada com as novas informações</param>
        public void Atualizar(int id, Personagem personagemAtualizado)
        {
            //Busca um personagem através do seu id
            Personagem personagemBuscado = ctx.Personagems.Find(id);
            
            //Verifica se o nome do personagem foi informada
            if (personagemAtualizado.NomePersonagem != null)
            {
                //Atribui os novos valores aos campos existentes
                personagemBuscado.NomePersonagem = personagemAtualizado.NomePersonagem;
            }
            //Verifica se a capacidade maxima de vida do personagem foi informada
            if (personagemAtualizado.CapacidadeMaximaVida >= 0)
            {
                //Atribui os novos valores aos campos existentes
                personagemBuscado.CapacidadeMaximaVida = personagemAtualizado.CapacidadeMaximaVida;
            }
            //Verifica se a capacidade maxima mana do personagem foi informada
            if (personagemAtualizado.CapacidadeMaximaMana >= 0)
            {
                //Atribui os novos valores aos campos existentes
                personagemBuscado.CapacidadeMaximaMana = personagemAtualizado.CapacidadeMaximaMana;
            }
            //Verifica se a data de atualização do personagem foi informada
            if (personagemAtualizado.DataAtualização != null)
            {
                //Atribui os novos valores aos campos existentes
                personagemBuscado.DataAtualização = personagemAtualizado.DataAtualização;
            }
            //Verifica se a data de criação do personagem foi informada
            if (personagemAtualizado.DataDeCriacao != null)
            {
                //Atribui os novos valores aos campos existentes
                personagemBuscado.DataDeCriacao = personagemAtualizado.DataDeCriacao;
            }

            //Atualiza o personagem que foi buscado
            ctx.Update(personagemBuscado);

            //Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Busca um personagem pelo seu id
        /// </summary>
        /// <param name="id">Id do personagem que será buscada</param>
        /// <returns>Uma personagem buscada</returns>
        public Personagem BuscarPorId(int id)
        {
            //Retorna o primeiro personagem encontrada para o ID informado
            return ctx.Personagems.FirstOrDefault(p => p.IdPersonagem == id);
        }

        /// <summary>
        /// Cadastra uma nova personagem
        /// </summary>
        /// <param name="novaPersonagem">Objeto novoPersonagem que será cadastrada</param>
        public void Cadastrar(Personagem novaPersonagem)
        {
            //Adiciona um novo personagem
            ctx.Personagems.Add(novaPersonagem);

            //Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta um personagem existente
        /// </summary>
        /// <param name="id">ID do personagem que será deletada</param>
        public void Deletar(int id)
        {
            //Busca um personagem através do seu id
            Personagem personagemBuscado = ctx.Personagems.FirstOrDefault(p => p.IdPersonagem == id);

            //Remove o personagem que foi buscado
            ctx.Personagems.Remove(personagemBuscado);

            //Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Retorna uma lista de nome de personagens ordenada
        /// </summary>
        /// <returns>Uma lista de nomes de personagens ordenadas</returns>
        public List<Personagem> ListaOrdenada()
        {
            return ctx.Personagems.Include(p => p.IdClasseNavigation).OrderBy(p => p.IdClasseNavigation.NomeClasse).ToList();
        }

        /// <summary>
        /// Retorna uma lista de personagens
        /// </summary>
        /// <returns>Uma lista de personagens</returns>
        public List<Personagem> Listar()
        {
            //Retorna uma lista com todas as informações das habilidades
            return ctx.Personagems.ToList();
        }

        /// <summary>
        /// Lista todos os tipos de personagens com suas respectivas classes
        /// </summary>
        /// <returns>Uma lista de personagens com suas classes</returns>
        ///EXTRA
        public List<Personagem> ListarClasse()
        {
            //Retorna uma lista de personagens com suas respectivas classes
            return ctx.Personagems.Include(p => p.IdClasseNavigation).ToList();
        }

        /// <summary>
        /// Lista todos os personagens de acordo com o jogador que cadastrou
        /// </summary>
        /// <returns>Uma lista de personagens de acordo com o jogador que cadastrou</returns>
        ///EXTRA
        public List<Personagem> ListarJogadores(int id)
        {
            /// Retorna uma lista de personagens de acordo com o jogador que cadastrou
            var personagemBuscado = ctx.Personagems.Include(p => p.IdUsuarioNavigation)
                                                   .Where(p => p.IdUsuario == id)
                                                   .Select(p => new Personagem()
            {
                IdPersonagem = p.IdPersonagem,

                NomePersonagem = p.NomePersonagem,

                CapacidadeMaximaVida = p.CapacidadeMaximaVida,

                CapacidadeMaximaMana = p.CapacidadeMaximaMana,

                DataAtualização = p.DataAtualização,

                DataDeCriacao = p.DataDeCriacao,

                IdClasseNavigation = new Classe()
                {
                    IdClasse = p.IdClasseNavigation.IdClasse,

                    NomeClasse = p.IdClasseNavigation.NomeClasse
                },

                IdUsuarioNavigation = new Usuario()
                {
                    IdUsuario = p.IdUsuarioNavigation.IdUsuario,

                    Email = p.IdUsuarioNavigation.Email
                }

            });

            return personagemBuscado.ToList();
        }
    }
}
