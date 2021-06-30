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
    /// Classe responsável pelo repositório dos filmes
    /// </summary>
    public class FilmeRepository : IFilmeRepository
    {
        /// <summary>
        /// String de conexao com o banco de dados que recebe os parametros
        /// Data Source = nome do servidor
        /// initial catalog = nome do banco de dados
        /// user id=sa; pwd=senai@132 faz a autenticacao com o usuario do SQL Server, passando o logon e a senha
        /// integrated security=true = faz a autenticacao com o usuario do sistema(windows)
        /// </summary>
        private string stringConexao = "Data Source=DESKTOP-BI41T69\\SQLEXPRESS; initial catalog=Filmes; user Id=sa; pwd=senai@132";

        public void AtualizarIdCorpo(FilmeDomain filme)
        {
            // Declara a SqlConnection con passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //Declara a query a ser executada
                string queryUpdateIdUrl = "update Filmes set tituloFilme = @titulo where idFilme = @ID";

                // Declara o SqlCommand cmd passando a query que será executada e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(queryUpdateIdUrl, con))
                {
                    // Passa o valor para o parâmetro @ID
                    cmd.Parameters.AddWithValue("@ID", filme.idFilme);

                    // Passa o valor para o parâmetro @Nome
                    cmd.Parameters.AddWithValue("@titulo", filme.titulo);

                    //Abre a conexão com o banco de dados
                    con.Open();

                    //Execura o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AtualizarIdUrl(int id, FilmeDomain filme)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //Declara a query a ser executada
                string queryUpdateIdUrl = "update Filmes set tituloFilme = @titulo where idFilme = @ID";

                // Declara o SqlCommand cmd passando a query que será executada e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(queryUpdateIdUrl, con))
                {
                    // Passa o valor para o parâmetro @ID
                    cmd.Parameters.AddWithValue("@ID", id);

                    // Passa o valor para o parâmetro @titulo
                    cmd.Parameters.AddWithValue("@titulo", filme.titulo);

                    //Abre a conexão com o banco de dados
                    con.Open();

                    //Execura o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public FilmeDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query a ser executada
                string querySelectById = "SELECT idFilme, tituloFilme, idGenero FROM Filmes WHERE idFilme = @ID";

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
                        FilmeDomain filmeBuscado = new FilmeDomain
                        {
                            // Atribui à propriedade idFilme o valor da coluna "idFilme" da tabela do banco de dados
                            idFilme = Convert.ToInt32(rdr["idFilme"]),

                            // Atribui à propriedade titulo o valor da coluna "tituloFilme" da tabela do banco de dados
                            titulo = rdr["tituloFilme"].ToString(),

                            // Atribui à propriedade idGenero o valor da coluna "idGenero" da tabela do banco de dados
                            idGenero = Convert.ToInt32(rdr["idGenero"]),
                        };

                        // Retorna o generoBuscado com os dados obtidos
                        return filmeBuscado;
                    }

                    // Se não, retorna null
                    return null;
                }
            }
        }

        /// <summary>
        /// Cadastra um novo filme
        /// </summary>
        /// <param name="novoFilme">Objeto novoFilme com as informações que serão cadastradas</param>
        public void Cadastrar(FilmeDomain novoFilme)
        {
            // Declara a SqlConnection con passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                
                                      // INSERT INTO Filmes(tituloFilme) VALUES('Ficção Científica');
                                      // INSERT INTO Filmes(tituloFilme) VALUES('Joana D'Arc');
                                      // INSERT INTO Filmes(tituloFilme) VALUES('')DROP TABLE Filmes--');
                                      // string queryInsert = "INSERT INTO Filmes(tituloFilme) VALUES('" + novoFilme.titulo + "')";
                                      // Não usar dessa forma pois pode causar o efeito Joana D'Arc
                                      // Além de permitir SQL Injection
                                      // Por exemplo
                                      // "nome" : "')DROP TABLE Filmes--"
                                      // Ao tentar cadastrar o comando acima, irá deletar a tabela Filmes do banco de dados
                                      // https://www.devmedia.com.br/sql-injection/6102

                // Declara a query que será executada
                string queryInsert = "insert into Filmes values(@IdGenero, @titulo)";

                // Declara o SqlCommand cmd passando a query que será executada e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    // Passa o valor para o parâmetro @IdGenero
                    cmd.Parameters.AddWithValue("@IdGenero", novoFilme.idGenero);

                    // Passa o valor para o parâmetro @titulo
                    cmd.Parameters.AddWithValue("@titulo", novoFilme.titulo);
                    //Abre a conexao com o banco de dados
                    con.Open();

                    //executa a query
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // <summary>
        /// Deleta um filme através do seu id
        /// </summary>
        /// <param name="id">id do filme que será deletado</param>
        public void Deletar(int id)
        {
            // Declara a SqlConnection con passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query a ser executada passando o valor como parâmetro
                string queryDelete = "DELETE FROM Filmes WHERE idFilme = @ID";

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
        /// Lista todos os filmes
        /// </summary>
        /// <returns>Uma lista de filmes</returns>
        public List<FilmeDomain> ListarTodos()
        {
            //Cria uma listaFilmes onde serao armazenados os dados
            List<FilmeDomain> listaFilmes = new List<FilmeDomain>();

            // Declara a SqlConnection con passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a instrução a ser executada
                string querySelectAll = "select idFilme ,tituloFilme, Generos.idGenero, nomeGenero from Filmes inner join Generos on Filmes.idGenero = Generos.idGenero";

                // Abre a conexão com o banco de dados
                con.Open();

                // Declara o SqlDataReader rdr para percorrer a tabela do banco de dados
                SqlDataReader rdr;

                // Declara o SqlCommand cmd passando a query que será executada e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand (querySelectAll, con))
                {
                    // Executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    // Enquanto houver registros para serem lidos no rdr, o laço se repete
                    while (rdr.Read())
                    {
                        // Instacia um objeto filme do tipo FilmeDomain
                        FilmeDomain filme = new()
                        {
                            // Atribui à propriedade idFilme o valor da primeira coluna da tabela do banco de dados
                            idFilme = Convert.ToInt32(rdr[0]),

                            // Atribui à propriedade do tituloFilme o valor da segunda coluna da tabela do banco de dados
                            titulo = rdr[1].ToString(),

                            // Atribui à propriedade idGenero o valor da terceira coluna da tabela do banco de dados
                            idGenero = Convert.ToInt32(rdr[2]),

                            // Instacia um objeto genero do tipo GeneroDomain para puxar os dados do idGenero
                            genero = new GeneroDomain()
                            {
                                // Atribui à propriedade idGenero o valor da terceira coluna da tabela do banco de dados só que agora na instância GeneroDomain
                                idGenero = Convert.ToInt32(rdr[2]),

                                //Atribui á propriedade nome (de nomeGenero) o valor da quarta coluna da tabela do banco de dados
                                nome = rdr[3].ToString()
                            }
                        };

                        // Adiciona o objeto filme à lista listaFilmes
                        listaFilmes.Add(filme);
                    }
                }
            }

            // Retorna a lista de filmes
            return listaFilmes;
        }
    }
}
