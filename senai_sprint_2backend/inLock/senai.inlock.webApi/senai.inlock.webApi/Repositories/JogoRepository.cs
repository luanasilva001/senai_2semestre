using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace senai.inlock.webApi.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        /// <summary>
        /// String de conexao com o banco de dados que recebe os parametros
        /// Data Source = nome do servidor
        /// initial catalog = nome do banco de dados
        /// user id=sa; pwd=senai@132 faz a autenticacao com o usuario do SQL Server, passando o logon e a senha
        /// integrated security=true = faz a autenticacao com o usuario do sistema(windows)
        /// </summary>
        private string stringConexao = "Data Source=DESKTOP-BI41T69\\SQLEXPRESS; initial catalog=inlock_games_tarde; user Id=sa; pwd=senai@132";

        /// <summary>
        /// Atualiza um jogo passando o seu id pelo corpo da requisição
        /// </summary>
        /// <param name="jogo">Objeto jogo com as novas informações</param>
        public void AtualizarIdCorpo(JogoDomain jogo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query a ser executada
                string queryUpdateIdBody = "update jogos set nomeJogo = @nomeJogo where idJogo = @ID";

                using (SqlCommand cmd = new SqlCommand(queryUpdateIdBody, con))
                {
                    // Passa o valor para o parâmetro @ID
                    cmd.Parameters.AddWithValue("@ID", jogo.idJogo);

                    // Passa o valor para o parâmetro @nome
                    cmd.Parameters.AddWithValue("@nomeJogo", jogo.nomeJogo);

                    // Abre a conexão com o banco de dados
                    con.Open();

                    //Executa o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Atualiza um jogo passando o id pelo recurso (URL)
        /// </summary>
        /// <param name="id">id do jogo que será atualizado</param>
        /// <param name="jogo">objeto jogo com as novas informações</param>
        public void AtualizarIdUrl(int id, JogoDomain jogo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query a ser executada
                string queryUpdateIdUrl = "update jogos set nomeJogo = @nomeJogo where idJogo = @ID";

                using (SqlCommand cmd = new SqlCommand(queryUpdateIdUrl, con))
                {
                    // Passa o valor para o parâmetro @ID
                    cmd.Parameters.AddWithValue("@ID", id);

                    // Passa o valor para o parâmetro @nome
                    cmd.Parameters.AddWithValue("@nomeJogo", jogo.nomeJogo);

                    // Abre a conexão com o banco de dados
                    con.Open();

                    //Executa o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Busca um jogo através do seu id
        /// </summary>
        /// <param name="id">id do jogo que  será buscado</param>
        /// <returns>um jogo buscado ou null caso não seja encontrado</returns>
        public JogoDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query a ser executada
                string querySelectById = "select idJogo, idEstudio, nomeJogo, descricao, dataLancamento, valor from jogos where idJogo = @ID";

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
                        // Se sim, instancia um novo objeto funcionarioBuscado do tipo FuncionarioDomain
                        JogoDomain jogoBuscado = new JogoDomain
                        {
                            // Atribui à propriedade idJogo o valor da coluna "idJogo" da tabela do banco de dados
                            idJogo = Convert.ToInt32(rdr["idJogo"]),

                            // Atribui à propriedade idJogo o valor da coluna "idEstudio" da tabela do banco de dados
                            idEstudio = Convert.ToInt32(rdr["idEstudio"]),

                            // Atribui à propriedade nome o valor da coluna "nomeJogo" da tabela do banco de dados
                            nomeJogo = rdr["nomeJogo"].ToString(),

                            // Atribui à propriedade sobrenome o valor da coluna "descricao" da tabela do banco de dados
                            descricao = rdr["descricao"].ToString(),

                            // Atribui à propriedade dataNascimento o valor da coluna "dataNascimento" da tabela do banco de dados
                            dataLancamento = Convert.ToDateTime(rdr["dataLancamento"]),

                            // Atribui à propriedade dataNascimento o valor da coluna "valor" da tabela do banco de dados
                            valor = Convert.ToDecimal(rdr["valor"])
                        };

                        // Retorna o funcionarioBuscado com os dados obtidos
                        return jogoBuscado;
                    }

                    // Se não, retorna null
                    return null;
                }
            }
        }

        /// <summary>
        /// Cadastra um novo jogo
        /// </summary>
        /// <param name="novoJogo">objeto novoJogo com as informacoes que serao cadastradas</param>
        public void Cadastrar(JogoDomain novoJogo)
        {
            //Declara a conexão con passando a string de conexao como parametro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query que será executada
                string queryInserir = "INSERT INTO jogos (nomeJogo, dataLancamento, descricao, idEstudio, valor) VALUES (@nomeJogo, @dataLancamento, @descricao, @idEstudio, @valor)";

                using (SqlCommand com = new SqlCommand(queryInserir, con))
                {
                    com.Parameters.AddWithValue("@nomeJogo", novoJogo.nomeJogo);
                    com.Parameters.AddWithValue("@dataLancamento", novoJogo.dataLancamento);
                    com.Parameters.AddWithValue("@descricao", novoJogo.descricao);
                    com.Parameters.AddWithValue("@idEstudio", novoJogo.idEstudio);
                    com.Parameters.AddWithValue("@valor", novoJogo.valor);

                    con.Open();

                    com.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Deleta um jogo através do seu id
        /// </summary>
        /// <param name="id">id do jogo que será deletado</param>
        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //Declara a query a ser executada passando o parametro @ID
                string queryDelete = "delete from jogos where idJogo = @iD";

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

        public List<JogoDomain> ListarPorEstudio(int id)
        {
           List<JogoDomain> listaEstudios = new List<JogoDomain>();

           using(SqlConnection con = new SqlConnection (stringConexao))
           {
               string querySelectEstudios = "select * from jogos where idEstudio = @ID";

               con.Open();

              // Declara o SqlDataReader rdr para receber os valores do banco de dados
                SqlDataReader rdr;

                // Declara o SqlCommand cmd passando a query que será executada e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(querySelectEstudios, con))
                {
                    // Passa o valor para o parâmetro @ID
                    cmd.Parameters.AddWithValue("@ID", id);

                    // Executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    // Verifica se o resultado da query retornou algum registro
                    if (rdr.Read())
                    {
                        // Se sim, instancia um novo objeto funcionarioBuscado do tipo FuncionarioDomain
                        JogoDomain jogoBuscado = new JogoDomain
                        {
                             // Atribui à propriedade idEstudio o valor da coluna "idEstudio" da tabela do banco de dados
                            idEstudio = Convert.ToInt32(rdr["idEstudio"]),
                        };
                    return listaEstudios;
                    }
                return null;
            }
        }
    }


        /// <summary>
        /// Lista todos os jogos
        /// </summary>
        /// <returns>Uma lista de jogos</returns>
        public List<JogoDomain> ListarTodos()
        {
            //Cria uma lista listaJogos onde serão armazenados os dados
            List<JogoDomain> listaJogos = new List<JogoDomain>();

            // Declara a SqlConnection con passando a string de conexao como parametro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Armazenando o select na variavel querySelectAll, ou seja, declara a instrução a ser executada
                string querySelectAll = "select idJogo, idEstudio, nomeJogo, descricao, dataLancamento, valor from jogos";

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
                        JogoDomain jogo = new JogoDomain()
                        {
                            idJogo = Convert.ToInt32(rdr[0]),

                            idEstudio = Convert.ToInt32(rdr[1]),

                            nomeJogo = rdr[2].ToString(),

                            descricao = rdr[3].ToString(),

                            dataLancamento = Convert.ToDateTime(rdr[4]),

                            valor = Convert.ToDecimal(rdr[5])
                        };

                        listaJogos.Add(jogo);
                    }
                }
            }
            return listaJogos;
        }
    }
}
