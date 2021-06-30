using Senai.Peoples.WebApi.Domains;
using System.Collections.Generic;

namespace Senai.Peoples.WebApi.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório FuncionarioRepository
    /// </summary>
    interface IFuncionarioRepository
    {
        /// <summary>
        /// Lista todos os funcionários
        /// </summary>
        /// <returns>Uma lista de funcionários</returns>
        List<FuncionarioDomain> ListarTodos();

        /// <summary>
        /// Lista todos os funcionarios em ordem decrescente e/ou crescente
        /// </summary>
        /// <returns>Uma lista de funcionários</returns>
        List<FuncionarioDomain> ListarPorOrdem(string ordem);

        /// <summary>
        /// Lista todos os funcionários com o nome e sobrenome na mesma linha
        /// </summary>
        /// <returns>Uma lista de funcionários com os nomes completos</returns>
        List<FuncionarioDomain> ListarTodosNomes();

        /// <summary>
        /// Busca um funcionário através do seu id
        /// </summary>
        /// <param name="id">id do funcionário que será buscado</param>
        /// <returns>um objeto funcionário que foi buscado</returns>
        FuncionarioDomain BuscarPorId(int id);

        /// <summary>
        /// Busca um funcionário através do seu nome
        /// </summary>
        /// <param name="nome">nome do funcionário que será buscado</param>
        /// <returns>Retorna um objeto nomeFuncionario que foi buscado</returns>
        FuncionarioDomain BuscarPorNome(string nome);

        /// <summary>
        /// Cadastra um novo funcionário
        /// </summary>
        /// <param name="novoFuncionario">Objeto novoFuncionario com as informações que serão cadastradas</param>
        void Cadastrar(FuncionarioDomain novoFuncionario);

        /// <summary>
        /// Atualiza um funcionário existente passando o id pelo corpo da requisição
        /// </summary>
        /// <param name="funcionario">Objeto funcionário com as novas informações</param>
        void AtualizarIdCorpo(FuncionarioDomain funcionario);

        /// <summary>
        /// Atualiza um funcionário existente passando o id pelo url da requisição
        /// </summary>
        /// <param name="id">id do funcionário que sera atualizado</param>
        /// <param name="funcionario">objeto funcionário com as novas informações</param>
        void AtualizarIdUrl(int id, FuncionarioDomain funcionario);

        /// <summary>
        /// Deleta um funcionário existente
        /// </summary>
        /// <param name="id">id do funcionário que será deletado</param>
        void Deletar(int id);
    }
}
