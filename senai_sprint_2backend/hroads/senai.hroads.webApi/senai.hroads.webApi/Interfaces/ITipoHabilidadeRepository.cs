using senai.hroads.webApi_.Domains;
using System.Collections.Generic;

namespace senai.hroads.webApi_.Interfaces
{
    interface ITipoHabilidadeRepository
    {
        /// <summary>
        /// Retorna uma lista de tipos de habilidades
        /// </summary>
        /// <returns>Uma lista de tipos de habilidades</returns>
        List<TipoHabilidade> Listar();

        /// <summary>
        /// Busca um tipo de habilidade pelo seu id
        /// </summary>
        /// <param name="id">Id do tipo de habilidade que será buscada</param>
        /// <returns>Um tipo de habilidade buscada</returns>
        TipoHabilidade BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo tipo de  habilidade
        /// </summary>
        /// <param name="novaTipoHabilidade">Objeto novaTipoHabilidade que será cadastrada</param>
        void Cadastrar(TipoHabilidade novoTipoHabilidade);

        /// <summary>
        /// Atualiza um tipo de habilidade existente
        /// </summary>
        /// <param name="id">ID do tipo de habilidade que será atualizada</param>
        /// <param name="classeAtualizada">Objeto tipoHabilidadeAtualizada com as novas informações</param>
        void Atualizar(int id, TipoHabilidade tipoHabilidadeAtualizada);

        /// <summary>
        /// Deleta um tipo de habilidade existente
        /// </summary>
        /// <param name="id">ID do tipo de habilidade que será deletada</param>
        void Deletar(int id);
    }
}
