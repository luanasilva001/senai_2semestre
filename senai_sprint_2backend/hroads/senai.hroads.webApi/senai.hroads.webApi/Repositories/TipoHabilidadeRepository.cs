using senai.hroads.webApi_.Contexts;
using senai.hroads.webApi_.Domains;
using senai.hroads.webApi_.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi_.Repositories
{
    /// <summary>
    /// Classe responsável pelo repositório dos tipos de habilidade
    /// </summary>
    public class TipoHabilidadeRepository : ITipoHabilidadeRepository
    {
        /// <summary>
        /// Objeto contexto por onde serão chamados os metódos do EF Core
        /// </summary>
        HroadsContext ctx = new HroadsContext();

        public void Atualizar(int id, TipoHabilidade tipoHabilidadeAtualizada)
        {
            //Busca um tipo de habilidade através do seu id
            TipoHabilidade tipoHabilidadeBuscada = ctx.TipoHabilidades.Find(id);

            //Verifica se o nome do tipo de habilidade foi informado
            if (tipoHabilidadeBuscada.NomeTipoHabilidade != null)
            {
                //Atribui os novos valores aos campos existentes
                tipoHabilidadeBuscada.NomeTipoHabilidade = tipoHabilidadeAtualizada.NomeTipoHabilidade;
            }

            //Atualiza o tipo de habilidade que foi buscado
            ctx.Update(tipoHabilidadeBuscada);

            //Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Busca um tipo de habilidade pelo seu id
        /// </summary>
        /// <param name="id">Id do tipo de habilidade que será buscada</param>
        /// <returns>Um tipo de habilidade que será buscado</returns>
        public TipoHabilidade BuscarPorId(int id)
        {
            //Retorna a primeira classe encontrada para o ID informado
            return ctx.TipoHabilidades.FirstOrDefault(t => t.IdTipoHabilidade == id);
        }

        /// <summary>
        /// Cadastra um novo tipo de habilidade
        /// </summary>
        /// <param name="novoTipoHabilidade">Objeto novaTipoHabilidade que será cadastrada</param>
        public void Cadastrar(TipoHabilidade novoTipoHabilidade)
        {
            //Adiciona um novo tipo de habilidade
            ctx.TipoHabilidades.Add(novoTipoHabilidade);

            //Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta um tipo de habilidade existente
        /// </summary>
        /// <param name="id">ID do tipo de habilidade que será deletada</param>
        public void Deletar(int id)
        {
            //Busca um tipo de habilidade através do seu id
            TipoHabilidade tipoHabilidadeBuscada = ctx.TipoHabilidades.FirstOrDefault(t => t.IdTipoHabilidade == id);

            //Remove o tipo de habilidade que foi buscada
            ctx.TipoHabilidades.Remove(tipoHabilidadeBuscada);

            //Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Retorna uma lista de tipos de habilidade
        /// </summary>
        /// <returns>Uma lista de tipos de habilidade</returns>
        public List<TipoHabilidade> Listar()
        {
            //Retorna uma lista com todas as informações dos tipos de habilidade
            return ctx.TipoHabilidades.ToList();
        }
    }
}
