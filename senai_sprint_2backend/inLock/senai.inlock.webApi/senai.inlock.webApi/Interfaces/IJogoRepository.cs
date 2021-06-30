using senai.inlock.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Interfaces
{
    interface IJogoRepository
    {
        List<JogoDomain> ListarPorEstudio(int id);

        /// <summary>
        /// Lista todos os jogos
        /// </summary>
        /// <returns>Uma lista de jogo</returns>
        List<JogoDomain> ListarTodos();

        /// <summary>
        /// Cadastra um novo jogo
        /// </summary>
        /// <param name="novoJogo">Objeto novoJogo com as informações que serão cadastradas</param>
        void Cadastrar(JogoDomain novoJogo);

        /// <summary>
        /// Busca um jogo através do seu id
        /// </summary>
        /// <param name="id">id do jogo que será buscado</param>
        /// <returns>um objeto jogo que foi buscado</returns>
        JogoDomain BuscarPorId(int id);

        /// <summary>
        /// Atualiza um jogo existente passando o id pelo corpo da requisição
        /// </summary>
        /// <param name="funcionario">Objeto jogo com as novas informações</param>
        void AtualizarIdCorpo(JogoDomain jogo);

        /// <summary>
        /// Atualiza um jogo existente passando o id pelo url da requisição
        /// </summary>
        /// <param name="id">id do jogo que sera atualizado</param>
        /// <param name="funcionario">objeto jogo com as novas informações</param>
        void AtualizarIdUrl(int id, JogoDomain jogo);

        /// <summary>
        /// Deleta um jogo existente
        /// </summary>
        /// <param name="id">id do jogo que será deletado</param>
        void Deletar(int id);
    }
}
