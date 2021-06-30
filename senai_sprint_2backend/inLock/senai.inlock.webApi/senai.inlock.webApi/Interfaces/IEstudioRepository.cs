using senai.inlock.webApi.Domains;
using System.Collections.Generic;

namespace senai.inlock.webApi.Interfaces
{
    interface IEstudioRepository
    {

        /// <summary>
        /// Lista todos os estúdios
        /// </summary>
        /// <returns>Uma lista de jogo</returns>
        List<EstudioDomain> Listar();

        /// <summary>
        /// Lista todos os estudios
        /// </summary>
        /// <returns>Uma lista de estudios</returns>
        List<EstudioDomain> ListarTodos();

        /// <summary>
        /// Cadastra um novo estúdio
        /// </summary>
        /// <param name="novoEstudio">Objeto novoEstudio com as informações que serão cadastradas</param>
        void Cadastrar(EstudioDomain novoEstudio);

        /// <summary>
        /// Busca um estúdio através do seu id
        /// </summary>
        /// <param name="id">id do estúdio que será buscado</param>
        /// <returns>um objeto estúdio que foi buscado</returns>
        EstudioDomain BuscarPorId(int id);

        /// <summary>
        /// Atualiza um estúdio existente passando o id pelo corpo da requisição
        /// </summary>
        /// <param name="estudio">Objeto estúdio com as novas informações</param>
        void AtualizarIdCorpo(EstudioDomain estudio);

        /// <summary>
        /// Atualiza um estúdio existente passando o id pelo url da requisição
        /// </summary>
        /// <param name="id">id do estúdio que sera atualizado</param>
        /// <param name="estudio">objeto estúdio com as novas informações</param>
        void AtualizarIdUrl(int id, EstudioDomain estudio);

        /// <summary>
        /// Deleta um estúdio existente
        /// </summary>
        /// <param name="id">id do estúdio que será deletado</param>
        void Deletar(int id);
    }
}
