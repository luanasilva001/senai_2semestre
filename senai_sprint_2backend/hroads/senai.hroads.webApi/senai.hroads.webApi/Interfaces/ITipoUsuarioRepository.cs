using senai.hroads.webApi_.Domains;
using System.Collections.Generic;

namespace senai.hroads.webApi_.Interfaces
{
    interface ITipoUsuarioRepository
    {
        /// <summary>
        /// Retorna uma lista de tipos de usuários
        /// </summary>
        /// <returns>Uma lista de tipos de usuários</returns>
        List<TipoUsuario> Listar();

        /// <summary>
        /// Busca um tipo de usuário pelo seu id
        /// </summary>
        /// <param name="id">Id do tipo de usuário que será buscado</param>
        /// <returns>Um tipo de usuário buscada</returns>
        TipoUsuario BuscarPorId(int id);

        /// <summary>
        /// Cadastra um tipo de usuário 
        /// </summary>
        /// <param name="novoTipoUsuario">Objeto novoTipoUsuario que será cadastrado</param>
        void Cadastrar(TipoUsuario novoTipoUsuario);

        /// <summary>
        /// Atualiza um tipo de usuário existente
        /// </summary>
        /// <param name="id">ID dao tipo usuário que será atualizada</param>
        /// <param name="tipoUsuarioAtualizado">Objeto tipoUsuarioAtualizado com as novas informações</param>
        void Atualizar(int id, TipoUsuario tipoUsuarioAtualizado);

        /// <summary>
        /// Deleta um tipo de usuário existente
        /// </summary>
        /// <param name="id">ID do tipo usuário que será deletado</param>
        void Deletar(int id);
    }
}