using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        /// <summary>
        /// String de conexao com o banco de dados que recebe os parametros
        /// Data Source = nome do servidor
        /// initial catalog = nome do banco de dados
        /// user id=sa; pwd=senai@132 faz a autenticacao com o usuario do SQL Server, passando o logon e a senha
        /// integrated security=true = faz a autenticacao com o usuario do sistema(windows)
        /// </summary>
        private string stringConexao = "Data Source=DESKTOP-BI41T69\\SQLEXPRESS; initial catalog=T_Peoples; user Id=sa; pwd=senai@132";

        public List<TipoUsuarioDomain> ListarTiposUsuarios()
        {
            //Cria uma lista listaFuncionarios onde serão armazenados os dados
            List<TipoUsuarioDomain> tipoUsuarios = new List<TipoUsuarioDomain>();

            // Declara a SqlConnection con passando a string de conexao como parametro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Armazenando o select na variavel querySelectAll, ou seja, declara a instrução a ser executada
                string querySelectAll = "select idTipoUsuario, tituloTipoUsuario from tipoUsuario";

                // Abre a conexão com o banco de dados
                con.Open();

                //Declara o SqlDataReader rdr para percorrer a tabela do banco de dados
                SqlDataReader rdr;

                // Declara o SqlCommand cmd passando a query que será executada e a conexao como parametros
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    // Executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    // Enquanto houver registros para serem lidos no rdr, o laço se repete
                    while (rdr.Read())
                    {
                        // Instancia um objeto genero do tipo FuncionarioDomain
                        TipoUsuarioDomain tipoUsuario = new TipoUsuarioDomain()
                        {
                            //Atribui á propriedade nome o valor da primeira coluna da tabela do banco de dados
                            idTipoUsuario = Convert.ToInt32(rdr[0]),

                            //Atribui á propriedade nome o valor da segunda coluna da tabela do banco de dados
                            tituloTipoUsuario = rdr[1].ToString()
                        };

                        //Adiciona a tipoUsuarios 
                        tipoUsuarios.Add(tipoUsuario);
                    }
                }
            }

            //Retorna a lista tipoUsuarios
            return tipoUsuarios;
        }
    }
}
