using senai.hroads.webApi_.Domains;
using System.Collections.Generic;

namespace senai.hroads.webApi_.Interfaces
{
    /// <summary>
    /// Interface responsável pelo ClasseRepository
    /// </summary>
    interface IClasseRepository
    {
        /// <summary>
        /// Retorna uma lista de classes
        /// </summary>
        /// <returns>Uma lista de classes</returns>
        List<Classe> Listar();

        /// <summary>
        /// Busca uma classe pelo seu id
        /// </summary>
        /// <param name="id">Id da classe que será buscada</param>
        /// <returns>Uma classe buscada</returns>
        Classe BuscarPorId(int id);

        /// <summary>
        /// Cadastra uma nova classe
        /// </summary>
        /// <param name="novaClasse">Objeto novaClasse que será cadastrada</param>
        void Cadastrar(Classe novaClasse);

        /// <summary>
        /// Atualiza uma classe existente
        /// </summary>
        /// <param name="id">ID da classe que será atualizada</param>
        /// <param name="classeAtualizada">Objeto classeAtualizada com as novas informações</param>
        void Atualizar(int id, Classe classeAtualizada);

        /// <summary>
        /// Deleta uma classe existente
        /// </summary>
        /// <param name="id">ID da classe que será deletada</param>
        void Deletar(int id);
    }
}
