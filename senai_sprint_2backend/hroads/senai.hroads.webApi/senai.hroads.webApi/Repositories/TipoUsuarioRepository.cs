using Microsoft.EntityFrameworkCore;
using senai.hroads.webApi_.Contexts;
using senai.hroads.webApi_.Domains;
using senai.hroads.webApi_.Interfaces;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Classe responsável pelo repositório dos tipos de usuários
/// </summary>
namespace senai.hroads.webApi_.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        /// <summary>
        /// Objeto contexto por onde serão chamados os metódos do EF Core
        /// </summary>
        HroadsContext ctx = new HroadsContext();

        /// <summary>
        /// Atualiza um tipo de usuário existente
        /// </summary>
        /// <param name="id">ID dao tipo usuário que será atualizada</param>
        /// <param name="tipoUsuarioAtualizado">Objeto tipoUsuarioAtualizado com as novas informações</param>
        public void Atualizar(int id, TipoUsuario tipoUsuarioAtualizado)
        {
            //Busca um tipo de usuário através do seu id
            TipoUsuario tipoUsuarioBuscado = ctx.TipoUsuarios.Find(id);

            //Verifica se o titulo do tipo usuario foi informado
            if (tipoUsuarioBuscado.TituloTipoUsuario != null)
            {
                //Atribui os novos valores aos campos existentes
                tipoUsuarioBuscado.TituloTipoUsuario = tipoUsuarioAtualizado.TituloTipoUsuario;
            }

            //Atualiza o tipo de usuário que foi buscado
            ctx.Update(tipoUsuarioAtualizado);
            
            //Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Busca um tipo de usuário pelo seu id
        /// </summary>
        /// <param name="id">Id do tipo de usuário que será buscado</param>
        /// <returns>Um tipo de usuário buscada</returns>
        public TipoUsuario BuscarPorId(int id)
        {
            //Retorna o primeiro tipo de usuário encontrado para o ID informado
            return ctx.TipoUsuarios.FirstOrDefault(t => t.IdTipoUsuario == id);
        }

        /// <summary>
        /// Cadastra um tipo de usuário 
        /// </summary>
        /// <param name="novoTipoUsuario">Objeto novoTipoUsuario que será cadastrado</param>
        public void Cadastrar(TipoUsuario novoTipoUsuario)
        {
            //Adiciona um novo tipo de usuário
            ctx.TipoUsuarios.Add(novoTipoUsuario);

            //Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta um tipo de usuário existente
        /// </summary>
        /// <param name="id">ID do tipo usuário que será deletado</param>
        public void Deletar(int id)
        {
            //Busca um tipo de usuário através do seu id
            TipoUsuario tipoUsuarioBuscada = ctx.TipoUsuarios.FirstOrDefault (t => t.IdTipoUsuario == id);

            //Remove o tipo de usuário que foi buscado
            ctx.TipoUsuarios.Remove(tipoUsuarioBuscada);

            //Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }
        
        /// <summary>
        /// Retorna uma lista de tipos de usuários
        /// </summary>
        /// <returns>Uma lista de tipos de usuários</returns>

        public List<TipoUsuario> Listar()
        {
            //Retorna uma lista com todas as informações dos tipos de usuários
            return ctx.TipoUsuarios.ToList();
        }
    }
}