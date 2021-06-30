using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using senai.hroads.webApi_.Contexts;
using senai.hroads.webApi_.Domains;
using senai.hroads.webApi_.Interfaces;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Classe responsável pelo repositório das habilidades
/// </summary>
namespace senai.hroads.webApi_.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        /// <summary>
        /// Objeto contexto por onde serão chamados os metódos do EF Core
        /// </summary>
        HroadsContext ctx = new HroadsContext();

        /// <summary>
        /// Atualiza um usuário existente
        /// </summary>
        /// <param name="id">ID da usuário que será atualizada</param>
        /// <param name="usuárioAtualizado">Objeto usuárioAtualizado com as novas informações</param>
        public void Atualizar(int id, Usuario usuarioAtualizado)
        {
            Usuario usuarioBuscado = ctx.Usuarios.Find(id);

            //Verifica se o email do usuário foi informada
            if (usuarioAtualizado.Email != null)
            {
                //Atribui os novos valores aos campos existentes
                usuarioBuscado.Email = usuarioAtualizado.Email;
            }
            //Verifica se a senha do usuário foi informada
            if (usuarioAtualizado.Senha != null)
            {
                //Atribui os novos valores aos campos existentes
                usuarioBuscado.Senha = usuarioAtualizado.Senha;
            }

           //Atualiza o usuário que foi buscada
            ctx.Update(usuarioBuscado);

            //Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Valida o usuário
        /// </summary>
        /// <param name="email">e-mail do usuário</param>
        /// <param name="senha">senha do usuário</param>
        /// <returns>Um objeto do tipo UsuarioDomain que foi buscado</returns>
        public Usuario BuscarPorEmailSenha(string email, string senha)
        {
            //Retorna uma um usuário encontrado pelo email e senha
            return ctx.Usuarios.Include(u => u.IdTipoUsuarioNavigation).FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }

        /// <summary>
        /// Busca um usuário pelo seu id
        /// </summary>
        /// <param name="id">Id do usuários que será buscado</param>
        /// <returns>Um usuários buscada</returns>
        public Usuario BuscarPorId(int id)
        {
            //Retorna o primeiro usuário encontrado para o ID informado
            return ctx.Usuarios.FirstOrDefault(u => u.IdUsuario == id);
        }

        /// <summary>
        /// Cadastra um novo usuário
        /// </summary>
        /// <param name="novoUsuario">Objeto novoUsuario que será cadastrado</param>
        public void Cadastrar(Usuario novoUsuario)
        {
            //Adiciona um novo usuário
            ctx.Usuarios.Add(novoUsuario);

            //Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta um usuário existente
        /// </summary>
        /// <param name="id">ID do usuário que será deletado</param>
        public void Deletar(int id)
        {
            //Busca um usuário através do seu id
            Usuario usuarioBuscado = ctx.Usuarios.FirstOrDefault(u => u.IdUsuario == id);

            //Remove o usuário que foi buscado
            ctx.Usuarios.Remove(usuarioBuscado);

            //Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Retorna uma lista de usuários
        /// </summary>
        /// <returns>Uma lista de usuários</returns>
        public List<Usuario> Listar()
        {
            //Retorna uma lista com todas as informações dos usuários
            return ctx.Usuarios.ToList();
        }

        /// <summary>
        /// Lista os somente os emails sem suas senhas
        /// </summary>
        /// <returns>Retorna uma lista de emails</returns>
        public List<Usuario> ListarEmail()
        {
            //Busca um novo usuário e instancia para retornar apenas o que está sendo atribuido
            var usuarioBuscado = ctx.Usuarios.Include(u => u.IdTipoUsuarioNavigation).Select(u => new Usuario()
            {
                //Atribui o IdUsuario
                IdUsuario = u.IdUsuario,

                //Atribui o tipo de usuário
                IdTipoUsuarioNavigation = u.IdTipoUsuarioNavigation,

                //Atribui o email
                Email = u.Email
            });

            //Retorna uma lista apenas daquilo que foi atribuido
            return usuarioBuscado.ToList();
        }

        /// <summary>
        /// Lista todos os tipos de usuários com seus respectivos usuários
        /// </summary>
        /// <returns>Uma lista de tipos de usuários com seus usuários</returns>
        public List<Usuario> ListarTipoUsuario()
        {
            //Retorna uma lista de usuários com seus respectivos tipos
            return ctx.Usuarios.Include(u => u.IdTipoUsuarioNavigation).ToList();
        }
    }
}