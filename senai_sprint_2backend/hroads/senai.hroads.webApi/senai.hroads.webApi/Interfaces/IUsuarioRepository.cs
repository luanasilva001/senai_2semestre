using senai.hroads.webApi_.Domains;
using System.Collections.Generic;

namespace senai.hroads.webApi_.Interfaces
{
    interface IUsuarioRepository
    {
        /// <summary>
        /// Retorna uma lista de usuários
        /// </summary>
        /// <returns>Uma lista de usuários</returns>
        List<Usuario> Listar();

        /// <summary>
        /// Busca um usuário pelo seu id
        /// </summary>
        /// <param name="id">Id do usuários que será buscado</param>
        /// <returns>Um usuários buscada</returns>
        Usuario BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo usuário
        /// </summary>
        /// <param name="novoUsuario">Objeto novoUsuario que será cadastrado</param>
        void Cadastrar(Usuario novoUsuario);

        /// <summary>
        /// Atualiza um usuário existente
        /// </summary>
        /// <param name="id">ID da usuário que será atualizada</param>
        /// <param name="usuárioAtualizado">Objeto usuárioAtualizado com as novas informações</param>
        void Atualizar(int id, Usuario usuarioAtualizado);

        /// <summary>
        /// Deleta um usuário existente
        /// </summary>
        /// <param name="id">ID do usuário que será deletado</param>
        void Deletar(int id);

        /// <summary>
        /// Lista todos os tipos de usuários com seus respectivos usuários
        /// </summary>
        /// <returns>Uma lista de tipos de usuários com seus usuários</returns>
        List<Usuario> ListarTipoUsuario();

        /// <summary>
        /// Valida o usuário
        /// </summary>
        /// <param name="email">e-mail do usuário</param>
        /// <param name="senha">senha do usuário</param>
        /// <returns>Um objeto do tipo UsuarioDomain que foi buscado</returns>
        Usuario BuscarPorEmailSenha(string email, string senha);

        /// <summary>
        /// Lista os somente os emails sem suas senhas
        /// </summary>
        /// <returns>Retorna uma lista de emails</returns>
        List<Usuario> ListarEmail();
    }
}