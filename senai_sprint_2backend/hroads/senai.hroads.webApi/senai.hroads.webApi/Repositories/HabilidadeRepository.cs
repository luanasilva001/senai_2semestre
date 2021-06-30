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
    public class HabilidadeRepository : IHabilidadeRepository
    {
        /// <summary>
        /// Objeto contexto por onde serão chamados os metódos do EF Core
        /// </summary>
        HroadsContext ctx = new HroadsContext();

        /// <summary>
        /// Atualiza uma habilidade existente
        /// </summary>
        /// <param name="id">ID da habilidade que será atualizada</param>
        /// <param name="habilidadeAtualizada">Objeto habilidadeAtualizada com as novas informações</param>
        public void Atualizar(int id, Habilidade habilidadeAtualizada)
        {
            //Busca uma habilidade através do seu id
           Habilidade habilidadeBuscada = ctx.Habilidades.Find(id);

           //Verifica se o nome da habilidade foi informada
           if(habilidadeAtualizada.NomeHabilidade != null)
           {
               //Atribui os novos valores aos campos existentes
               habilidadeBuscada.NomeHabilidade = habilidadeAtualizada.NomeHabilidade;
           }

           //Atualiza a habilidade que foi buscada
           ctx.Update(habilidadeBuscada);

           //Salva as informações para serem gravadas no banco de dados
           ctx.SaveChanges();
        }

        /// <summary>
        /// Busca uma habilidade pelo seu id
        /// </summary>
        /// <param name="id">Id da habilidade que será buscada</param>
        /// <returns>Uma habilidade buscada</returns>
        public Habilidade BuscarPorId(int id)
        {
            //Retorna a primeira habilidade encontrada para o ID informado
            return ctx.Habilidades.FirstOrDefault(h => h.IdHabilidade == id);
        }

        /// <summary>
        /// Cadastra uma nova habilidade
        /// </summary>
        /// <param name="novaHabilidade">Objeto novaHabilidade que será cadastrada</param>
        public void Cadastrar(Habilidade novaHabilidade)
        {
            //Adiciona uma nova habilidade
            ctx.Habilidades.Add(novaHabilidade);

            //Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta uma habilidade existente
        /// </summary>
        /// <param name="id">ID da habilidade que será deletada</param>
        //nao ta funcionando
        public void Deletar(int id)
        {
            //Busca uma habilidade através do seu id
            Habilidade habilidadeBuscada = ctx.Habilidades.FirstOrDefault(h => h.IdHabilidade == id);

            //Remove a habilidade que foi buscada
            ctx.Habilidades.Remove(habilidadeBuscada);

            //Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Retorna uma lista de habilidades
        /// </summary>
        /// <returns>Uma lista de habilidades</returns>
        public List<Habilidade> Listar()
        {
            //Retorna uma lista com todas as informações das habilidades
            return ctx.Habilidades.ToList();
        }

        /// <summary>
        /// Lista todos os tipos de habilidade com suas respectivas habilidades
        /// </summary>
        /// <returns>Uma lista de tipos habilidade com suas habilidades</returns>
        public List<Habilidade> ListarTipoHabilidade()
        {
            //Retorna uma lista de habilidades com seus respectivos tipos
            return ctx.Habilidades.Include(t => t.IdTipoHabilidadeNavigation).ToList();
        }
    }
}
