using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interfaces;
using Senai.Peoples.WebApi.Repositories;
using System;
using System.Collections.Generic;

/// <summary>
/// Controller responsável pelos endpoints referentes aos funcionarios
/// </summary>
namespace Senai.Peoples.WebApi.Controllers
{
    //Define que o tipo de resposta da api será no formato json
    [Produces("application/json")]

    //Define que a rota de uma requisição será no formato dominio/api/nomeController
    // ex: http://localhost:5000/api/funcionarios
    [Route("api/[controller]")]

    //Define que é um controlador de API
    [ApiController]
    public class FuncionariosController : ControllerBase
    {
        /// <summary>
        /// Objeto _funcionarioRepository que irá receber todos os métodos definidos na interface IFuncionarioRepository
        /// </summary>
        private IFuncionarioRepository _funcionarioRepository { get; set; }

        /// <summary>
        /// Insta o objeto _funcionarioRepository para que haja a referencia aos metodos do repositorio
        /// </summary>
        public FuncionariosController()
        {
            //Instancia _funcionarioRepository para que os metodos do IFuncionarioRepository tenham referencia
            _funcionarioRepository = new FuncionarioRepository();
        }

        /// <summary>
        /// Atualiza um funcionario existente passando o seu id pelo url da requisicao
        /// </summary>
        /// <param name="id">id do funcionario que será atualizado</param>
        /// <param name="funcionarioAtualizado">objeto funcionarioAtualizado com as novas informacoes</param>
        /// <returns>Retorna um status code</returns>
        /// http://localhost:5000/api/funcionarios/3
        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult PutIdUrl(int id, FuncionarioDomain funcionarioAtualizado)
        {
            //Cria um objeto funcionarioBuscado que irá receber o funcionario buscado no banco de dados
            FuncionarioDomain funcionarioBuscado = _funcionarioRepository.BuscarPorId(id);

            //Caso nao seja encontrado, retorna NotFound com uma mensagem personalizada
            // e um bool para apresentar que houve erro
            if (funcionarioBuscado == null)
            {
                return NotFound
                    (
                        new
                        {
                            mensagem = "Funcionario não encontrado!",
                            erro = true
                        }
                    );
            }

            //Tenta atualizar o registro
            try
            {
                //Faz a chamada para o metodo .AtualizarIdUrl()
                _funcionarioRepository.AtualizarIdUrl(id, funcionarioAtualizado);

                //Retorna um status code 204 - No Content
                return NoContent();
            }

            //Caso ocorra algum erro
            catch (Exception codErro)
            {
                //Retorna um status code 400 - BadRequest e o codigo do erro
                return BadRequest(codErro);
            }
        }

        /// <summary>
        /// Atualiza um funcionario existente passando o seu id pelo corpo da requisicao
        /// </summary>
        /// <param name="funcionarioAtualizado">Objeto funcionarioAtualizado com as novas informacoes</param>
        /// <returns>Um status code</returns>
        [Authorize]
        [HttpPut]
        public IActionResult PutIdBody(FuncionarioDomain funcionarioAtualizado)
        {
            //Cria um objeto funcionarioBuscado que irá receber o funcionario buscado no banco de dados
            FuncionarioDomain funcionarioBuscado = _funcionarioRepository.BuscarPorId(funcionarioAtualizado.idFuncionario);

            //Vrifica se algum funcionario foi encontrado
            if(funcionarioBuscado != null)
            {
                //Tenta atualizar o registro
                try
                {
                    //Faz a chamada para o metodo .AtualizarIdCorpo()
                    _funcionarioRepository.AtualizarIdCorpo(funcionarioAtualizado);

                    //Retorna um status code 204 - No content
                    return NoContent();
                }

                //Caso ocorra algum erro
                catch (Exception codErro)
                {
                    //Retorna BadRequest com o codigo de erro
                    return BadRequest(codErro);
                }
            }

            //Caso nao seja encontrado, retorna um NotFound com uma mensagem personalizada
            return NotFound
                (
                    new
                    {
                        mensagem = "Funcionario nao encontrado!"
                    }
                );
        }


        /// <summary>
        /// Lista todos os funcionarios
        /// </summary>
        /// <returns>Uma lista de funcionarios code</returns>
        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            //Cria uma lista nomeada listaFuncionarios para receber os dados
            List<FuncionarioDomain> listaFuncionarios = _funcionarioRepository.ListarTodos();

            //Retorna o status code 200(Ok) com a lista de funcionarios no formato JSON
            return Ok(listaFuncionarios);
        }

        /// <summary>
        /// Lista os funcionarios com o nome completo na mesma linha
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "1")]
        [HttpGet("nomescompletos")]
        public IActionResult GetName()
        {
            //Cria uma lista nomeada listaFuncionarios para listar todos os nomes
            List<FuncionarioDomain> listaFuncionarios = _funcionarioRepository.ListarTodosNomes();

            //Retorna o status code 200(Ok) com os nomes completos no formato JSON
            return Ok(listaFuncionarios);
        }

        /// <summary>
        /// Faz uma ordenacao descrescente ou acresente da lista de funcionarios
        /// </summary>
        /// <param name="ordem">objeto Ordem que ira verificar as requisicoes</param>
        /// <returns></returns>
        [Authorize(Roles = "1")]
        [HttpGet("ordenacao/{ordem}")]
        public IActionResult GetNameOrder(string ordem)
        {
            //Verifica se a ordem é "desc" ou "asc"
            if (ordem == "desc" || ordem == "asc")
            {
                //Tenta atualizar o registro
                try
                {
                    //Cria uma lista nomeada listaFuncionarios para receber os dados
                    List<FuncionarioDomain> listaFuncionario = _funcionarioRepository.ListarPorOrdem(ordem);

                    //Retorna um ok com a listaFuncionario
                    return Ok(listaFuncionario);
                }

                //Caso ocorra algum erro
                catch (Exception codErro)
                {
                    //Retorna um status code 400 - BadRequest e o código do erro
                    return BadRequest(codErro);
                }
            }

            //Caso nao exista a ordenacao procura, retorna uma mensagem personalizada
            return BadRequest("Não existe essa ordenação!");
        }

        /// <summary>
        /// Busca um funcionario pelo nome
        /// </summary>
        /// <param name="nome">objeto nome que sera buscado</param>
        /// <returns>Retorna um status code com o nome</returns>
        [Authorize]
        [HttpGet("buscar/{nome}")]
        public IActionResult GetByName(string nome)
        {
            //Cria um objeto funcionarioBuscado que irá receber o funcionario buscado no banco de dados
            FuncionarioDomain funcionarioBuscado = _funcionarioRepository.BuscarPorNome(nome);

            //Verifica se o funcionarioBuscado é null
            if(funcionarioBuscado == null)
            {
                //Caso seja, retorna um NotFound com uma mensagem personalizada
                return NotFound("Funcionario não encontrado");
            }

            //Se nao, retorna um status code
            return Ok(funcionarioBuscado);
        }

        /// <summary>
        /// Cadastra um novo genero
        /// </summary>
        /// <param name="novoFuncionario">objeto novoFuncionario com a informacoes cadastradas</param>
        /// <returns>Retorna um status code</returns>
        [Authorize]
        [HttpPost]
        public IActionResult Post(FuncionarioDomain novoFuncionario)
        {
            //Faz a chamada para o metodo .Cadastrar()
            _funcionarioRepository.Cadastrar(novoFuncionario);

            //Verifica se o campo nome é nulo
            if (String.IsNullOrWhiteSpace(novoFuncionario.nome))
            {
                //Se for, obriga o usuario a cadastrar um nome
                return NotFound("Campo nome obrigatorio");
            }

            //Se nao, retorna um status code
            return Ok(201);
        }

        /// <summary>
        /// Busca um funcionario através do seu id
        /// </summary>
        /// <param name="id">id do funcionario que será buscado</param>
        /// <returns>um funcionario buscado ou NotFound caso nenhum funcionario seja encontrado</returns>
        /// http://localhost:5000/api/funcionarios/1
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // Cria um objeto funcionarioBuscado que irá receber o funcionario buscado no banco de dados
            FuncionarioDomain funcionarioBuscado = _funcionarioRepository.BuscarPorId(id);

            //Verifica se um gênero foi encontrado
            if (funcionarioBuscado == null)
            {
                //Caso não seja encontrado, retorna um status code 404 - Not Found com a mensagem personalizada
                return NotFound("Funcionario não encontrado");
            }

            //Caso seja encontrado, retorna o gênero buscado com um status code 200 - ok
            return Ok(funcionarioBuscado);
        }

        /// <summary>
        /// Deleta um funcionario existente
        /// </summary>
        /// <param name="id">id do funcionario que será deletado</param>
        /// <returns>Um status code 204 - No Content</returns>
        /// http://localhost:5000/api/funcionarios/4
        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Faz a chamada para o método .Deletar()
            _funcionarioRepository.Deletar(id);

            //Retorna um status code 203 - No Content
            return StatusCode(204);
        }
    }
}
