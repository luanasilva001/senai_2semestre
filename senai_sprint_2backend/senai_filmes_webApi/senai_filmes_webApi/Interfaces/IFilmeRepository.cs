using senai_filmes_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webApi.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório FilmeRepository
    /// </summary>
    interface IFilmeRepository
    {
        /// <summary>
        /// Lista todos os filmes
        /// </summary>
        /// <returns>Uma lista de filmes</returns>
        List<FilmeDomain> ListarTodos();

        /// <summary>
        /// Busca um filme através do id
        /// </summary>
        /// <param name="id">id do filme que será buscado</param>
        /// <returns>Um objeto filme que foi buscado</returns>
        FilmeDomain BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo filme
        /// </summary>
        /// <param name="novoFilme">Objeto novoFilme com as informações que serão cadastradas</param>
        void Cadastrar(FilmeDomain novoFilme);

        /// <summary>
        /// Atualiza um filme existente passando o id pelo corpo da requisição
        /// </summary>
        /// <param name="filme">Objeto filme com as novas informações</param>
        void AtualizarIdCorpo(FilmeDomain filme);

        /// <summary>
        ///  Atualiza um filme existente passando o id pelo url da requisição
        /// </summary>
        /// <param name="id">id do filme que sera atualizado</param>
        /// <param name="filme">objeto filme com as novas informações</param>
        void AtualizarIdUrl(int id, FilmeDomain filme);

        /// <summary>
        /// Deleta um filme existente
        /// </summary>
        /// <param name="id">id do filme que será deletado</param>
        void Deletar(int id);
    }
}
