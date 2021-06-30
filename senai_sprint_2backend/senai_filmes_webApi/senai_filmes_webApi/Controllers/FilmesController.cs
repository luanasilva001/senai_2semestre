using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_filmes_webApi.Domains;
using senai_filmes_webApi.Interfaces;
using senai_filmes_webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


/// <summary>
/// Controller responsável pelos endpoints (URLs) referentes aos filmes
/// </summary>
namespace senai_filmes_webApi.Controllers
{
    // Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato dominio/api/nomeController
    // ex: http://localhost:5000/api/Filmes
    [Route("api/[controller]")]

    // Define que é um controlador de API
    [ApiController]
    public class FilmesController : ControllerBase
    {
        /// <summary>
        /// Objeto _filmeRepository que irá receber todos os métodos definidos na interface IFilmeRepository
        /// </summary>
        private IFilmeRepository _filmeRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _filmeRepository para que haja a referência aos métodos no repositório
        /// </summary>
        public FilmesController()
        {
            _filmeRepository = new FilmeRepository();
        }

        /// <summary>
        /// Lista todos os filmes
        /// </summary>
        /// <returns>Uma lista de filmes e um status code</returns>
        /// http://localhost:5000/api/filmes
        [HttpGet]
        public IActionResult Get()
        {
            // Cria uma lista nomeada listaFilmes para receber os dados
            List<FilmeDomain> listaFilmes = _filmeRepository.ListarTodos();

            // Retorna o status code 200 (Ok) com a lista de filmes no formato JSON
            return Ok(listaFilmes);
        }

        /// <summary>
        /// Cadastra um novo filme
        /// </summary>
        /// <param name="novoFilme">Objeto novoFilme recebido na requisição</param>
        /// <returns>Um status code 201 - Created</returns>
        ///http://localhost:5000/api/filmes
        [HttpPost]
        public IActionResult Post(FilmeDomain novoFilme)
        {
            // Faz a chamada para o método .Cadastrar()
            _filmeRepository.Cadastrar(novoFilme);

            // Retorna um status code 201 - Created
            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza um genero existente passando o seu id pelo corpo da requisição
        /// </summary>
        /// <param name="generoAtualizado">Objeto generoAtualizado com as novas informações</param>
        /// <returns>Um status code</returns>
        [HttpPut]
        public IActionResult PutIdBody(FilmeDomain filmeAtualizado)
        {
            //Cria um objeto generoBuscado que irá receber o gênero buscado no banco de dados
            FilmeDomain filmeBuscado = _filmeRepository.BuscarPorId(filmeAtualizado.idFilme);

            //Verifica se algum gênero foi encontrado
            if (true)
            {

                //Tenta atualizar o registro
                try
                {
                    //Faz a chamada para o método .AtualizarIdCorpo()
                    _filmeRepository.AtualizarIdCorpo(filmeAtualizado);

                    //Retorna um status code 204 - No Content
                    return NoContent();
                }

                //Caso ocorra algum erro
                catch (Exception codErro)
                {
                    //Retorna BadRequest com o código de erro
                    return BadRequest(codErro);
                }
            }

            //Caso nao seja encontrado, retorna NotFound com uma mensagem personalizada
            return NotFound
                (
                    new
                    {
                        mensagem = "Filme não encontrado!"
                    }
                );
        }

        /// <summary>
        /// Atualiza um gênero existente passando o seu id pela url da requisição
        /// </summary>
        /// <param name="id">id do gênero que será atualizado</param>
        /// <param name="generoAtualizado">Objeto generoAtualizado com as novas informações</param>
        /// <returns>Um status code</returns>
        /// http://localhost:5000/api/filme/1
        [HttpPut("{id}")]
        public IActionResult PutIdUrl(int id, FilmeDomain filmeAtualizado)
        {
            //Cria um objeto generoBuscado que irá receber o gênero buscado no banco de dados
            FilmeDomain filmeBuscado = _filmeRepository.BuscarPorId(id);

            //Caso não seja encontrado, retorna um NotFound com uma mensagwem personalizada
            // e um bool para apresentar que teve erro
            if (filmeBuscado == null)
            {
                return NotFound
                    (
                        new
                        {
                            mensagem = "Filme não encontrado!",
                            erro = true
                        }
                    );
            }

            //Tenta atualizar o registro
            try
            {
                //Faz a chamada para o método .AtualizarIdUrl()
                _filmeRepository.AtualizarIdUrl(id, filmeAtualizado);

                //Retorna um status code 204 - No Content
                return NoContent();
            }

            //Caso ocorra algum erro
            catch (Exception codErro)
            {
                //Retorna um status code 400 - BadRequest e o código do erro
                return BadRequest(codErro);

            }
        }

        /// <summary>
        /// Deleta um filme existente
        /// </summary>
        /// <param name="id">id do filme que será deletado</param>
        /// <returns>Um status code 204 - No Content</returns>
        /// http://localhost:5000/api/filmes/4
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Faz a chamada para o método .Deletar()
            _filmeRepository.Deletar(id);

            // Retorna um status code 204 - No Content
            return StatusCode(204);
        }

        /// <summary>
        /// Busca um gênero através do seu id
        /// </summary>
        /// <param name="id">id do gênero que será buscado</param>
        /// <returns>um gênero buscado ou NotFound caso nenhum gênero seja encontrado</returns>
        /// http://localhost:5000/api/generos/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // Cria um objeto generoBuscado que irá receber o gênero buscado no banco de dados
            FilmeDomain filmeBuscado = _filmeRepository.BuscarPorId(id);

            //Verifica se um gênero foi encontrado
            if (filmeBuscado == null)
            {
                //Caso não seja encontrado, retorna um status code 404 - Not Found com a mensagem personalizada
                return NotFound("Filme não encontrado");
            }

            //Caso seja encontrado, retorna o gênero buscado com um status code 200 - ok
            return Ok(filmeBuscado);
        }

    }
}
