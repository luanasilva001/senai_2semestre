using senai.hroads.webApi_.Contexts;
using senai.hroads.webApi_.Domains;
using senai.hroads.webApi_.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace senai.hroads.webApi_.Repositories
{
    /// <summary>
    /// Classe responsável pelo repositório das classes
    /// </summary>
    public class ClasseRepository : IClasseRepository
    {
        /// <summary>
        /// Objeto contexto por onde serão chamados os metódos do EF Core
        /// </summary>
        HroadsContext ctx = new HroadsContext();

        /// <summary>
        /// Atualiza uma classe existente
        /// </summary>
        /// <param name="id">ID da classe que será atualizada</param>
        /// <param name="classeAtualizada">Objeto novaClasse com as novas informações</param>
        public void Atualizar(int id, Classe classeAtualizada)
        {
            //Busca uma classe através do seu id
            Classe classeBuscada = ctx.Classes.Find(id);

            //Verifica se o nome da classe foi informada
            if (classeAtualizada.NomeClasse != null)
            {
                //Atribui os novos valores aos campos existentes
                classeBuscada.NomeClasse = classeAtualizada.NomeClasse;
            }

            //Atualiza a classe que foi buscado
            ctx.Update(classeBuscada);

            //Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Busca uma classe pelo seu id
        /// </summary>
        /// <param name="id">Id da classe que será buscada</param>
        /// <returns>Uma classe buscada</returns>
        public Classe BuscarPorId(int id)
        {
            //Retorna a primeira classe encontrada para o ID informado
            return ctx.Classes.FirstOrDefault(c => c.IdClasse == id);
        }

        /// <summary>
        /// Cadastra uma nova classe
        /// </summary>
        /// <param name="novaClasse">Objeto novaClasse que será cadastrada</param>
        public void Cadastrar(Classe novaClasse)
        {
            //Adiciona uma nova classe
            ctx.Classes.Add(novaClasse);

            //Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta uma classe existente
        /// </summary>
        /// <param name="id">ID da classe que será deletada</param>
        public void Deletar(int id)
        {
            //Busca uma classe através do seu id
            Classe classeBuscada = ctx.Classes.FirstOrDefault(c => c.IdClasse == id);

            //Remove a classe que foi buscada
            ctx.Classes.Remove(classeBuscada);

            //Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Retorna uma lista de classes
        /// </summary>
        /// <returns>Uma lista de classes</returns>
        public List<Classe> Listar()
        {
            //Retorna uma lista com todas as informações das classes
            return ctx.Classes.ToList();
        }
    }
}
