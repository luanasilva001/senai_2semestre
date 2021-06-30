using senai.hroads.webApi_.Domains;
using System.Collections.Generic;

namespace senai.hroads.webApi_.Interfaces
{
    interface IPersonagemRepository
    {
        /// <summary>
        /// Retorna uma lista de personagens
        /// </summary>
        /// <returns>Uma lista de personagens</returns>
        List<Personagem> Listar();

        /// <summary>
        /// Busca um personagem pelo seu id
        /// </summary>
        /// <param name="id">Id do personagem que será buscada</param>
        /// <returns>Um personagem buscada</returns>
        Personagem BuscarPorId(int id);

        /// <summary>
        /// Cadastra uma nova personagem
        /// </summary>
        /// <param name="novaPersonagem">Objeto novoPersonagem que será cadastrada</param>
        void Cadastrar(Personagem novaPersonagem);

        /// <summary>
        /// Atualiza uma personagem existente
        /// </summary>
        /// <param name="id">ID da personagem que será atualizada</param>
        /// <param name="personagemAtualizada">Objeto personagemAtualizada com as novas informações</param>
        void Atualizar(int id, Personagem personagemAtualizado);

        /// <summary>
        /// Deleta um personagem existente
        /// </summary>
        /// <param name="id">ID do personagem que será deletada</param>
        void Deletar(int id);

        /// <summary>
        /// Lista todos os tipos de personagens com suas respectivas personagens
        /// </summary>
        /// <returns>Uma lista de tipos personagens com suas classes</returns>
        List<Personagem> ListarClasse();

        /// <summary>
        /// Lista todos os personagens de acordo com sua classe em ordem alfabetica
        /// </summary>
        /// <returns>Uma lista de personagens ordenados pelas classes de A - Z</returns>
        List<Personagem> ListaOrdenada();

        /// <summary>
        /// Lista todos os personagens de acordo com o jogador que cadastrou
        /// </summary>
        /// <returns>Uma lista de personagens de acordo com o jogador que cadastrou</returns>
        List<Personagem> ListarJogadores(int id);
    }
}