using senai_filmes_webApi.Domains;
using senai_filmes_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webApi.Repositories
{
    /// <summary>
    /// Classe responsável pelo repositório dos gêneros
    /// </summary>
    public class GeneroRepository : IGeneroRepository
    {
        /// <summary>
        /// String de conexao com o banco de dados que recebe os parametros
        /// Data Source = nome do servidor
        /// initial catalog = nome do banco de dados
        /// user id=sa; pwd=senai@132 faz a autenticacao com o usuario do SQL Server, passando o logon e a senha
        /// integrated security=true = faz a autenticacao com o usuario do sistema(windows)
        /// </summary>
        private string stringConexao = "Data Source=DESKTOP-BI41T69\\SQLEXPRESS; initial catalog=Filmes; user Id=sa; pwd=senai@132";
        
        /// <summary>
        /// Atualiza um gênero passando o seu id pelo corpo da requisicao
        /// </summary>
        /// <param name="genero">Objeto genero com as novas informações</param>
        public void AtualizarIdCorpo(GeneroDomain genero)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //Declara a query a ser executada
                string queryUpdateIdUrl = "update Generos set nomeGenero = @Nome where idGenero = @ID";

                // Declara o SqlCommand cmd passando a query que será executada e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(queryUpdateIdUrl, con))
                {
                    // Passa o valor para o parâmetro @ID
                    cmd.Parameters.AddWithValue("@ID", genero.idGenero);

                    // Passa o valor para o parâmetro @Nome
                    cmd.Parameters.AddWithValue("@Nome", genero.nome);

                    //Abre a conexão com o banco de dados
                    con.Open();

                    //Execura o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Atualiza um gênero passando o id pelo recurso (URL)
        /// </summary>
        /// <param name="id">id do gênero que será atualizado</param>
        /// <param name="genero">objeto gênero com as novas informações</param>
        public void AtualizarIdUrl(int id, GeneroDomain genero)
        {
            //Declara a SqlConnection con passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //Declara a query a ser executada
                string queryUpdateIdUrl = "update Generos set nomeGenero = @Nome where idGenero = @ID";

                // Declara o SqlCommand cmd passando a query que será executada e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(queryUpdateIdUrl, con))
                {
                    // Passa o valor para o parâmetro @ID
                    cmd.Parameters.AddWithValue("@ID", id);

                    // Passa o valor para o parâmetro @Nome
                    cmd.Parameters.AddWithValue("@Nome", genero.nome);

                    //Abre a conexão com o banco de dados
                    con.Open();

                    //Execura o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Busca um gênero através do seu id
        /// </summary>
        /// <param name="id">id do gênero que  será buscado</param>
        /// <returns>um gênero buscado ou null caso não seja encontrado</returns>
        public GeneroDomain BuscarPorId(int id)
        {
            //Declara a SqlConnection con passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query a ser executada
                string querySelectById = "select idGenero, nomeGenero from Generos where idGenero = @ID";

                // Abre a conexão com o banco de dados
                con.Open();

                // Declara o SqlDataReader rdr para receber os valores do banco de dados
                SqlDataReader rdr;

                // Declara o SqlCommand cmd passando a query que será executada e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    // Passa o valor para o parâmetro @ID
                    cmd.Parameters.AddWithValue("@ID", id);

                    // Executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    // Verifica se o resultado da query retornou algum registro
                    if (rdr.Read())
                    {
                        // Se sim, instancia um novo objeto generoBuscado do tipo GeneroDomain
                        GeneroDomain generoBuscado = new GeneroDomain
                        {
                            // Atribui à propriedade idGenero o valor da coluna "idGenero" da tabela do banco de dados
                            idGenero = Convert.ToInt32(rdr["idGenero"]),

                            // Atribui à propriedade nome o valor da coluna "Nome" da tabela do banco de dados
                            nome = rdr["nomeGenero"].ToString()
                        };

                        // Retorna o generoBuscado com os dados obtidos
                        return generoBuscado;
                    }

                    // Se não, retorna null
                    return null;
                }
            }
        }

        // Cadastra um novo gênero
        //parametro = objeto novoGenero com as informacoes que serao cadastradas
        public void Cadastrar(GeneroDomain novoGenero)
        {
            //Declara a conexão con passando a string de conexao como parametro
            using(SqlConnection con = new SqlConnection(stringConexao))
	        {
                // INSERT INTO Generos(Nome) VALUES('Ficção Científica');
                // INSERT INTO Generos(Nome) VALUES('Joana D'Arc');
                // INSERT INTO Generos(Nome) VALUES('')DROP TABLE Filmes--');
                // string queryInsert = "INSERT INTO Generos(Nome) VALUES('" + novoGenero.nome + "')";
                // Não usar dessa forma pois pode causar o efeito Joana D'Arc
                // Além de permitir SQL Injection
                // Por exemplo
                // "nome" : "')DROP TABLE Filmes--"
                // Ao tentar cadastrar o comando acima, irá deletar a tabela Filmes do banco de dados
                // https://www.devmedia.com.br/sql-injection/6102


                // Declara a query que será executada
                string queryInsert = "insert into Generos(nomeGenero) values(@Nome)";

                // Declara o SqlCommand cmd passando a query que será executada e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
	            {
                    // Passa o valor para o parâmetro @Nome
                    cmd.Parameters.AddWithValue("@Nome", novoGenero.nome);
                    //Abre a conexao com o banco de dados
                    con.Open();

                    //executa a query
                    cmd.ExecuteNonQuery();
	            }
	        }
        }

        /// <summary>
        /// Deleta um gênero através do seu id
        /// </summary>
        /// <param name="id">id do gênero que será deletado</param>
        public void Deletar(int id)
        {
            //Declara a SqlConnection con passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //Declara a query a ser executada passando o parametro @ID
                string queryDelete = "delete from Generos where idGenero = @iD";

                // Declara o SqlCommand cmd passando a query que será executada e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    // Define o valor do id recebido no método como o valor do parâmetro @ID
                    cmd.Parameters.AddWithValue("@ID", id);

                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa a query
                    cmd.ExecuteNonQuery();
                }
            }
        }
        /// <summary>
        /// Lista todos os gêneros
        /// </summary>
        /// <returns>Uma lista de generos</returns>
        public List<GeneroDomain> ListarTodos()
        {
            //Cria uma lista listaGeneros onde serão armazenados os dados
            List<GeneroDomain> listaGeneros = new List<GeneroDomain>();

            // Declara a SqlConnection con passando a string de conexao como parametro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Armazenando o select na variavel querySelectAll, ou seja, declara a instrução a ser executada
                string querySelectAll = "select idGenero, nomeGenero from Generos";

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
                        // Instancia um objeto genero do tipo GeneroDomain
                        GeneroDomain genero = new GeneroDomain()
                        {
                            //Atribui á propriedade nome o valor da segunda coluna da tabela do banco de dados
                            idGenero = Convert.ToInt32(rdr[0]),

                            // Atribui á propriedade nome o valor da segunda coluna da tabela do banco de dados
                            nome = rdr[1].ToString()
                        };

                        //Adiciona a listaGeneros a lista genero
                        listaGeneros.Add(genero);
                    }
                }
            }

            //Retorna a lista listaGeneros
            return listaGeneros;
        }
    }
}
