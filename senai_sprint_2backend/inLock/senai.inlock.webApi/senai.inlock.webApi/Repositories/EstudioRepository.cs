using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Interfaces
{
    public class EstudioRepository : IEstudioRepository
    {
        IJogoRepository _jogoRepository = new JogoRepository();
        // <summary>
        /// String de conexao com o banco de dados que recebe os parametros
        /// Data Source = nome do servidor
        /// initial catalog = nome do banco de dados
        /// user id=sa; pwd=senai@132 faz a autenticacao com o usuario do SQL Server, passando o logon e a senha
        /// integrated security=true = faz a autenticacao com o usuario do sistema(windows)
        /// </summary>
        private string stringConexao = "Data Source=DESKTOP-BI41T69\\SQLEXPRESS; initial catalog=inlock_games_tarde; user Id=sa; pwd=senai@132";

        /// <summary>
        /// Atualiza um estudio passando o seu id pelo corpo da requisição
        /// </summary>
        /// <param name="estudio">Objeto estudio com as novas informações</param>
        public void AtualizarIdCorpo(EstudioDomain estudio)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query a ser executada
                string queryUpdateIdBody = "update estudios set nomeEstudio = @nomeEstudio where idEstudio = @ID";

                using (SqlCommand cmd = new SqlCommand(queryUpdateIdBody, con))
                {
                    // Passa o valor para o parâmetro @ID
                    cmd.Parameters.AddWithValue("@ID", estudio.idEstudio);

                    // Passa o valor para o parâmetro @nome
                    cmd.Parameters.AddWithValue("@nomeEstudio", estudio.nomeEstudio);

                    // Abre a conexão com o banco de dados
                    con.Open();

                    //Executa o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Atualiza um estudio passando o id pelo recurso (URL)
        /// </summary>
        /// <param name="id">id do estudio que será atualizado</param>
        /// <param name="estudio">objeto estudio com as novas informações</param>
        public void AtualizarIdUrl(int id, EstudioDomain estudio)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query a ser executada
                string queryUpdateIdUrl = "update estudios set nomeEstudio = @nomeEstudio where idEstudio = @ID";

                using (SqlCommand cmd = new SqlCommand(queryUpdateIdUrl, con))
                {
                    // Passa o valor para o parâmetro @ID
                    cmd.Parameters.AddWithValue("@ID", id);

                    // Passa o valor para o parâmetro @nome
                    cmd.Parameters.AddWithValue("@nomeEstudio", estudio.nomeEstudio);

                    // Abre a conexão com o banco de dados
                    con.Open();

                    //Executa o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Busca um estudio através do seu id
        /// </summary>
        /// <param name="id">id do estudio que  será buscado</param>
        /// <returns>um estudio buscado ou null caso não seja encontrado</returns>
        public EstudioDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query a ser executada
                string querySelectById = "select idEstudio, nomeEstudio from estudios where idEstudio = @ID";

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
                        // Se sim, instancia um novo objeto estudioBuscado do tipo EstudioDomain
                        EstudioDomain estudioBuscado = new EstudioDomain
                        {
                            // Atribui à propriedade idEstudio o valor da coluna "idEstudio" da tabela do banco de dados
                            idEstudio = Convert.ToInt32(rdr["idEstudio"]),

                            // Atribui à propriedade nomeEstudio o valor da coluna "nomeEstudio" da tabela do banco de dados
                            nomeEstudio = rdr["nomeEstudio"].ToString()
                        };

                        // Retorna o estudioBuscado com os dados obtidos
                        return estudioBuscado;
                    }

                    // Se não, retorna null
                    return null;
                }
            }
        }

        /// <summary>
        /// Cadastra um novo estúdio
        /// </summary>
        /// <param name="novoEstudio">objeto novoEstudio com as informacoes que serao cadastradas</param>
        public void Cadastrar(EstudioDomain novoEstudio)
        {
            //Declara a conexão con passando a string de conexao como parametro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query que será executada
                string queryInsert = "insert into estudios values (@nomeEstudio)";

                // Declara o SqlCommand cmd passando a query que será executada e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    // Passa o valor para o parâmetro @nomeEstudio
                    cmd.Parameters.AddWithValue("@nomeEstudio", novoEstudio.nomeEstudio);

                    //Abre a conexao com o banco de dados
                    con.Open();

                    //executa a query
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Deleta um estudio através do seu id
        /// </summary>
        /// <param name="id">id do estudio que será deletado</param>
        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //Declara a query a ser executada passando o parametro @ID
                string queryDelete = "delete from estudios where idEstudio = @iD";

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

        public List<EstudioDomain> Listar()
        {
            //Cria uma lista listaJogos onde serão armazenados os dados
            List<EstudioDomain> listarPorEstudio = new List<EstudioDomain>();

            // Declara a SqlConnection con passando a string de conexao como parametro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Armazenando o select na variavel querySelectAll, ou seja, declara a instrução a ser executada
                string querySelectAll = "select idJogo, estudios.idEstudio, nomeJogo, descricao, dataLancamento, valor, nomeEstudio from estudios inner join jogos on jogos.idEstudio = estudios.idEstudio";

                // Abre a conexão com o banco de dados
                con.Open();

                //Declara o SqlDataReader rdr para percorrer a tabela do banco de dados
                SqlDataReader rdr;

                // Declara o SqlCommand cmd passando a query que será executada e a conexao como parametros
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    // Executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        // Instancia um objeto genero do tipo JogoDomain
                           EstudioDomain Estudio = new EstudioDomain
                           {
                               nomeEstudio = rdr["nomeEstudio"].ToString(),

                                jogo = _jogoRepository.ListarPorEstudio(Convert.ToInt32(rdr["idEstudio"]))
                        };
                        // Adiciona o objeto filme à lista listaJogosComEstudios
                        listarPorEstudio.Add(Estudio);
                    }
                }
            }
                    return listarPorEstudio;
        }
        /// <summary>
        /// Lista todos os estúdios
        /// </summary>
        /// <returns>Uma lista de estúdios</returns>
        public List<EstudioDomain> ListarTodos()
        {
            //Cria uma lista listaEstudios onde serão armazenados os dados
            List<EstudioDomain> listaEstudios = new List<EstudioDomain>();

            // Declara a SqlConnection con passando a string de conexao como parametro
            using (SqlConnection con = new(stringConexao))
            {
                // Armazenando o select na variavel querySelectAll, ou seja, declara a instrução a ser executada
                string querySelectAll = "select idEstudio, nomeEstudio  from estudios";

                // Abre a conexão com o banco de dados
                con.Open();

                //Declara o SqlDataReader rdr para percorrer a tabela do banco de dados
                SqlDataReader rdr;

                // Declara o SqlCommand cmd passando a query que será executada e a conexao como parametros
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    // Executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        // Instancia um objeto genero do tipo EstudioDomain
                        EstudioDomain estudio = new EstudioDomain()
                        {

                            idEstudio = Convert.ToInt32(rdr[0]),

                            nomeEstudio = rdr[1].ToString()
                        };

                        listaEstudios.Add(estudio);
                    }
                }
            }

    return listaEstudios;
        }
    }
}
