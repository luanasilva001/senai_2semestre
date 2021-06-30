using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using senai.inlock.webApi.Repositories;
using System;
using System.Collections.Generic;

namespace senai.inlock.webApi.Controllers
{
    //Define que o tipo de resposta da api será no formato json
    [Produces("application/json")]

    //Define que a rota de uma requisição será no formato dominio/api/nomeController
    // ex: http://localhost:5000/api/jogos
    [Route("api/[controller]")]

    //Define que é um controlador de API
    [ApiController]
    public class JogosController : ControllerBase
    {
        /// <summary>
        /// Objeto _jogoRepository que irá receber todos os métodos definidos na interface IJogoRepository
        /// </summary>
        private IJogoRepository _jogoRepository { get; set; }

        /// <summary>
        /// Insta o objeto _jogoRepository para que haja a referencia aos metodos do repositorio
        /// </summary>
        public JogosController()
        {
            //Instancia _jogoRepository para que os metodos do IJogoRepository tenham referencia
            _jogoRepository = new JogoRepository();
        }

        /// <summary>
        /// Lista todos os jogos
        /// </summary>
        /// <returns>Uma lista de jogos code</returns>
        /// http://localhost:5000/api/jogos
        [Authorize]
        [HttpGet]
        public IActionResult GetEstudios()
        {
            //Cria uma lista nomeada listaJogos para receber os dados
            List<JogoDomain> listaJogos = _jogoRepository.ListarTodos();

            //Retorna o status code 200(Ok) com a lista de jogos no formato JSON
            return Ok(listaJogos);
        }

        /// <summary>
        /// Deleta um jogo existente
        /// </summary>
        /// <param name="id">id do jogo que será deletado</param>
        /// <returns>Um status code 204 - No Content</returns>
        /// http://localhost:5000/api/jogos/4
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Faz a chamada para o método .Deletar()
            _jogoRepository.Deletar(id);

            //Retorna um status code 203 - No Content
            return StatusCode(204);
        }

        /// <summary>
        /// Cadastra um novo jogo
        /// </summary>
        /// <param name="novoJogo">objeto novoJogo com a informacoes cadastradas</param>
        /// <returns>Retorna um status code</returns>
        [Authorize]
        [HttpPost]
        public IActionResult Post(JogoDomain novoJogo)
        {
            //Faz a chamada para o metodo .Cadastrar()
            _jogoRepository.Cadastrar(novoJogo);

            //Se nao, retorna um status code
            return Ok(201);
        }

        /// <summary>
        /// Busca um jogo através do seu id
        /// </summary>
        /// <param name="id">id do jogo que será buscado</param>
        /// <returns>um jogo buscado ou NotFound caso nenhum jogo seja encontrado</returns>
        /// http://localhost:5000/api/jogos/1
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // Cria um objeto jogoBuscado que irá receber o jogo buscado no banco de dados
            JogoDomain jogoBuscado = _jogoRepository.BuscarPorId(id);

            //Verifica se um gênero foi encontrado
            if (jogoBuscado == null)
            {
                //Caso não seja encontrado, retorna um status code 404 - Not Found com a mensagem personalizada
                return NotFound("Jogo não encontrado");
            }

            //Caso seja encontrado, retorna o gênero buscado com um status code 200 - ok
            return Ok(jogoBuscado);
        }

        /// <summary>
        /// Atualiza um jogo existente passando o seu id pelo corpo da requisicao
        /// </summary>
        /// <param name="jogoAtualizado">Objeto jogoAtualizado com as novas informacoes</param>
        /// <returns>Um status code</returns>
        [Authorize]
        [HttpPut("put")]
        public IActionResult PutId(JogoDomain jogoAtualizado)
        {
            //Cria um objeto jogoBuscado que irá receber o jogo buscado no banco de dados
            JogoDomain jogoBuscado = _jogoRepository.BuscarPorId(jogoAtualizado.idJogo);

            //Vrifica se algum jogo foi encontrado
            if (jogoBuscado != null)
            {
                //Tenta atualizar o registro
                try
                {
                    //Faz a chamada para o metodo .AtualizarIdCorpo()
                    _jogoRepository.AtualizarIdCorpo(jogoAtualizado);

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
                        mensagem = "Jogo nao encontrado!"
                    }
                );
        }

        /// <summary>
        /// Atualiza um jogo existente passando o seu id pelo corpo da requisicao
        /// </summary>
        /// <param name="jogoAtualizado">Objeto jogoAtualizado com as novas informacoes</param>
        /// <returns>Um status code</returns>
        [Authorize]
        [HttpPut]
        public IActionResult PutIdBody(JogoDomain jogoAtualizado)
        {
            //Cria um objeto jogoBuscado que irá receber o jogo buscado no banco de dados
            JogoDomain jogoBuscado = _jogoRepository.BuscarPorId(jogoAtualizado.idJogo);

            //Vrifica se algum jogo foi encontrado
            if (jogoBuscado != null)
            {
                //Tenta atualizar o registro
                try
                {
                    //Faz a chamada para o metodo .AtualizarIdCorpo()
                    _jogoRepository.AtualizarIdCorpo(jogoAtualizado);

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
                        mensagem = "Jogo nao encontrado!"
                    }
                );
        }
    }
}
