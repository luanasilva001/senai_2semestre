using senai.hroads.webApi_.Domains;
using System.Collections.Generic;

namespace senai.hroads.webApi_.Interfaces
{
    interface IHabilidadeRepository
    {
        /// <summary>
        /// Retorna uma lista de habilidades
        /// </summary>
        /// <returns>Uma lista de habilidades</returns>
        List<Habilidade> Listar();

        /// <summary>
        /// Busca uma habilidade pelo seu id
        /// </summary>
        /// <param name="id">Id da habilidade que será buscada</param>
        /// <returns>Uma habilidade buscada</returns>
        Habilidade BuscarPorId(int id);

        /// <summary>
        /// Cadastra uma nova habilidade
        /// </summary>
        /// <param name="novaHabilidade">Objeto novaHabilidade que será cadastrada</param>
        void Cadastrar(Habilidade novaHabilidade);

        /// <summary>
        /// Atualiza uma habilidade existente
        /// </summary>
        /// <param name="id">ID da habilidade que será atualizada</param>
        /// <param name="habilidadeAtualizada">Objeto habilidadeAtualizada com as novas informações</param>
        void Atualizar(int id, Habilidade habilidadeAtualizada);

        /// <summary>
        /// Deleta uma habilidade existente
        /// </summary>
        /// <param name="id">ID da habilidade que será deletada</param>
        void Deletar(int id);

        /// <summary>
        /// Lista todos os tipos de habilidade com suas respectivas habilidades
        /// </summary>
        /// <returns>Uma lista de tipos habilidade com suas habilidades</returns>
        List<Habilidade> ListarTipoHabilidade();
    }
}
