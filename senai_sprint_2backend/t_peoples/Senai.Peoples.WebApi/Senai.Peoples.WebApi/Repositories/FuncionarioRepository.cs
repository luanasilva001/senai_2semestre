using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Senai.Peoples.WebApi.Repositories
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        /// <summary>
        /// String de conexao com o banco de dados que recebe os parametros
        /// Data Source = nome do servidor
        /// initial catalog = nome do banco de dados
        /// user id=sa; pwd=senai@132 faz a autenticacao com o usuario do SQL Server, passando o logon e a senha
        /// integrated security=true = faz a autenticacao com o usuario do sistema(windows)
        /// </summary>
        private string stringConexao = "Data Source=DESKTOP-BI41T69\\SQLEXPRESS; initial catalog=T_Peoples; user Id=sa; pwd=senai@132";

        /// <summary>
        /// Atualiza um funcionário passando o seu id pelo corpo da requisição
        /// </summary>
        /// <param name="funcionario">Objeto funcionário com as novas informações</param>
        public void AtualizarIdCorpo(FuncionarioDomain funcionario)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query a ser executada
                string queryUpdateIdBody = "update Funcionarios set nomeFuncionario = @nome where idFuncionario = @ID";

                using (SqlCommand cmd = new SqlCommand(queryUpdateIdBody, con))
                {
                    // Passa o valor para o parâmetro @ID
                    cmd.Parameters.AddWithValue("@ID", funcionario.idFuncionario);

                    // Passa o valor para o parâmetro @nome
                    cmd.Parameters.AddWithValue("@nome", funcionario.nome);

                    // Abre a conexão com o banco de dados
                    con.Open();

                    //Executa o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Atualiza um funcionario passando o id pelo recurso (URL)
        /// </summary>
        /// <param name="id">id do funcionario que será atualizado</param>
        /// <param name="funcionario">objeto funcionario com as novas informações</param>
        public void AtualizarIdUrl(int id, FuncionarioDomain funcionario)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query a ser executada
                string queryUpdateIdUrl = "update Funcionarios set nomeFuncionario = @nome where idFuncionario = @ID";

                using (SqlCommand cmd = new SqlCommand(queryUpdateIdUrl, con))
                {
                    // Passa o valor para o parâmetro @ID
                    cmd.Parameters.AddWithValue("@ID", id);

                    // Passa o valor para o parâmetro @nome
                    cmd.Parameters.AddWithValue("@nome", funcionario.nome);

                    // Abre a conexão com o banco de dados
                    con.Open();

                    //Executa o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }


        /// <summary>
        /// Busca um funcionário através do seu id
        /// </summary>
        /// <param name="id">id do funcionário que  será buscado</param>
        /// <returns>um funcionário buscado ou null caso não seja encontrado</returns>
        public FuncionarioDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query a ser executada
                string querySelectById = "select idFuncionario, nomeFuncionario, sobrenomeFuncionario, dataNascimento from Funcionarios where idFuncionario = @ID";

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
                        FuncionarioDomain funcionarioBuscado = new FuncionarioDomain
                        {
                            // Atribui à propriedade idGenero o valor da coluna "idFuncionario" da tabela do banco de dados
                            idFuncionario = Convert.ToInt32(rdr["idFuncionario"]),

                            // Atribui à propriedade nome o valor da coluna "nomeFuncionario" da tabela do banco de dados
                            nome = rdr["nomeFuncionario"].ToString(),

                            // Atribui à propriedade sobrenome o valor da coluna "sobrenomeFuncionario" da tabela do banco de dados
                            sobrenome = rdr["sobrenomeFuncionario"].ToString(),

                            // Atribui à propriedade dataNascimento o valor da coluna "dataNascimento" da tabela do banco de dados
                            dataNascimento = Convert.ToDateTime(rdr["dataNascimento"])
                        };

                        // Retorna o funcionarioBuscado com os dados obtidos
                        return funcionarioBuscado;
                    }

                    // Se não, retorna null
                    return null;
                }
            }
        }

        /// <summary>
        /// Busca um usuário pelo nome
        /// </summary>
        /// <param name="nome">nome do funcionario que sera buscado</param>
        /// <returns>um funcionario ou null caso nao seja encontrado</returns>
        public FuncionarioDomain BuscarPorNome(string nome)
        {
            //Declara a SqlConnection con passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query a ser executada
                string querySelectByName = "select idFuncionario, nomeFuncionario, sobrenomeFuncionario, dataNascimento from Funcionarios where nomeFuncionario like @nome";

                // Abre a conexão com o banco de dados
                con.Open();

                // Declara o SqlDataReader rdr para receber os valores do banco de dados
                SqlDataReader rdr;

                // Declara o SqlCommand cmd passando a query que será executada e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(querySelectByName, con))
                {
                    // Passa o valor para o parâmetro @nome
                    cmd.Parameters.AddWithValue("@nome", nome);

                    // Executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    // Verifica se o resultado da query retornou algum registro
                    if (rdr.Read())
                    {
                        // Se sim, instancia um novo objeto funcionarioBuscado do tipo funcionarioDomain
                        FuncionarioDomain funcionarioBuscado = new FuncionarioDomain
                        {
                            // Atribui à propriedade idFuncionario o valor da coluna "idFuncionario" da tabela do banco de dados
                            idFuncionario = Convert.ToInt32(rdr["idFuncionario"]),

                            // Atribui à propriedade nome o valor da coluna "nomeFuncionario" da tabela do banco de dados
                            nome = rdr["nomeFuncionario"].ToString(),

                            // Atribui à propriedade sobrenome o valor da coluna "sobrenomeFuncionario" da tabela do banco de dados
                            sobrenome = rdr["sobrenomeFuncionario"].ToString(),

                            // Atribui à propriedade dataNascimento o valor da coluna "dataNascimento" da tabela do banco de dados
                            dataNascimento = Convert.ToDateTime(rdr["dataNascimento"])
                        };

                        // Retorna o funcionarioBuscado com os dados obtidos
                        return funcionarioBuscado;
                    }

                    // Se não, retorna null
                    return null;
                }
            }
        }

        /// <summary>
        /// Cadastra um novo gênero
        /// </summary>
        /// <param name="novoFuncionario">objeto novoFuncionaro com as informacoes que serao cadastradas</param>
        public void Cadastrar(FuncionarioDomain novoFuncionario)
        {
            //Declara a conexão con passando a string de conexao como parametro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query que será executada
                string queryInsert = "insert into Funcionarios values (@nomeFuncionario, @sobrenomeFuncionario, @dataNascimento)";

                // Declara o SqlCommand cmd passando a query que será executada e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    // Passa o valor para o parâmetro @nomeFuncionario
                    cmd.Parameters.AddWithValue("@nomeFuncionario", novoFuncionario.nome);

                    // Passa o valor para o parâmetro @sobrenomeFuncionario
                    cmd.Parameters.AddWithValue("@sobrenomeFuncionario", novoFuncionario.sobrenome);

                    // Passa o valor para o parâmetro @dataNascimento
                    cmd.Parameters.AddWithValue("@dataNascimento", novoFuncionario.dataNascimento);

                    //Abre a conexao com o banco de dados
                    con.Open();

                    //executa a query
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Deleta um funcionario através do seu id
        /// </summary>
        /// <param name="id">id do funcionario que será deletado</param>
        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //Declara a query a ser executada passando o parametro @ID
                string queryDelete = "delete from Funcionarios where idFuncionario = @iD";

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
        /// Lista todos os funcionarios por ordem decrescente e/ou acrescente
        /// </summary>
        /// <param name="ordem">Ordem que sera executada</param>
        /// <returns>Uma lista de ordens</returns>
        public List<FuncionarioDomain> ListarPorOrdem(string ordem)
        {
            //Cria uma lista listafuncionarios onde serão armazenados os dados
            List<FuncionarioDomain> listafuncionarios = new List<FuncionarioDomain>();

            // Declara a SqlConnection con passando a string de conexao como parametro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //Cria a variavel querySelect para fazer as instruções do if/else
                string querySelect;

                //Cria a instrucao if, onde caso o escolhido seja o desc, faz a primeira instrucao
                if (ordem == "desc")
                {
                    // Armazenando o select na variavel querySelect, ou seja, declara a instrução a ser executada
                    querySelect =  "select * from Funcionarios order by nomeFuncionario desc";
                }

                //Se nao, cai no else
                else
                {
                    // E armazenando o select na variavel querySelect, ou seja, declara a instrução a ser executada
                    querySelect = "select * from Funcionarios order by nomeFuncionario asc";
                }

                // Abre a conexão com o banco de dados
                con.Open();

                //Declara o SqlDataReader rdr para percorrer a tabela do banco de dados
                SqlDataReader rdr;

                // Declara o SqlCommand cmd passando a query que será executada e a conexao como parametros
                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    // Executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    // Enquanto houver registros para serem lidos no rdr, o laço se repete
                    while (rdr.Read())
                    {
                        // Instancia um objeto genero do tipo FuncionarioDomain
                        FuncionarioDomain funcionario = new FuncionarioDomain()
                        {
                            //Atribui á propriedade nome o valor da primeira coluna da tabela do banco de dados
                            idFuncionario = Convert.ToInt32(rdr[0]),

                            //Atribui á propriedade nome o valor da segunda coluna da tabela do banco de dados
                            nome = rdr[1].ToString(),

                            //Atribui á propriedade nome o valor da terceira coluna da tabela do banco de dados
                            sobrenome = rdr[2].ToString(),

                            //Atribui á propriedade nome o valor da quarta coluna da tabela do banco de dados
                            dataNascimento = Convert.ToDateTime(rdr[3])
                        };

                        //Adiciona a listaFuncionarios
                        listafuncionarios.Add(funcionario);
                    }
                }
            }

            //Retorna a lista listaFuncionarios
            return listafuncionarios;
        }

        /// <summary>
        /// Lista todos os funcionarios
        /// </summary>
        /// <returns>Uma lista de funcionarios</returns>
        public List<FuncionarioDomain> ListarTodos()
        {
            //Cria uma lista listaFuncionarios onde serão armazenados os dados
            List<FuncionarioDomain> listaFuncionarios = new List<FuncionarioDomain>();

            // Declara a SqlConnection con passando a string de conexao como parametro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Armazenando o select na variavel querySelectAll, ou seja, declara a instrução a ser executada
                string querySelectAll = "select idFuncionario, nomeFuncionario, sobrenomeFuncionario, dataNascimento from Funcionarios";

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
                        FuncionarioDomain funcionario = new FuncionarioDomain()
                        {
                            //Atribui á propriedade nome o valor da primeira coluna da tabela do banco de dados
                            idFuncionario = Convert.ToInt32(rdr[0]),

                            //Atribui á propriedade nome o valor da segunda coluna da tabela do banco de dados
                            nome = rdr[1].ToString(),

                            //Atribui á propriedade nome o valor da terceira coluna da tabela do banco de dados
                            sobrenome = rdr[2].ToString(),

                            //Atribui á propriedade nome o valor da quarta coluna da tabela do banco de dados
                            dataNascimento = Convert.ToDateTime(rdr[3])
                        };

                        //Adiciona a listaFuncionarios 
                        listaFuncionarios.Add(funcionario);
                    }
                }
            }

            //Retorna a lista listaFuncionarios
            return listaFuncionarios;
        }

        /// <summary>
        /// Lista todos os nomes completos dos funcionarios
        /// </summary>
        /// <returns>Uma lista de nomes completos</returns>
        public List<FuncionarioDomain> ListarTodosNomes()
        {
            //Cria uma lista listaNomes onde serão armazenados os dados
            List<FuncionarioDomain> listaNomes = new List<FuncionarioDomain>();

            // Declara a SqlConnection con passando a string de conexao como parametro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a instrução a ser executada
                string querySelectAllNames = "SELECT idFuncionario, CONCAT(nomeFuncionario, ' ' ,sobrenomeFuncionario), dataNascimento from Funcionarios";

                //Abre a conexão com o banco de dados
                con.Open();

                // Declara o SqlDataReader rdr para percorrer a tabela do banco de dados
                SqlDataReader rdr;

                // Declara o SqlCommand cmd passando a query que será executada e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(querySelectAllNames, con))
                {
                    // Executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    // Enquanto houver registros para serem lidos no rdr, o laço se repete
                    while (rdr.Read())
                    {
                        // Instancia um objeto genero do tipo FuncionarioDomain
                        FuncionarioDomain funcionario = new FuncionarioDomain()
                        {
                            //Atribui á propriedade nome o valor da primeira coluna da tabela do banco de dados
                            idFuncionario = Convert.ToInt32(rdr[0]),

                            //Atribui á propriedade nome o valor da segunda coluna da tabela do banco de dados
                            nome = rdr[1].ToString(),

                            //Atribui á propriedade nome o valor da quarta coluna da tabela do banco de dados
                            dataNascimento = Convert.ToDateTime(rdr[2])
                            };

                        //Adiciona a listaNomes
                        listaNomes.Add(funcionario);
                    }
                }
            }
            //Retorna a lista listaNomes
            return listaNomes;
        }
    }
}
