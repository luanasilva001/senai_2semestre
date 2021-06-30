using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Controllers
{
    //Define que o tipo de resposta da api será no formato json
    [Produces("application/json")]

    //Define que a rota de uma requisição será no formato dominio/api/nomeController
    // ex: http://localhost:5000/api/estudios
    [Route("api/[controller]")]

    //Define que é um controlador de API
    [ApiController]
    public class EstudiosController : ControllerBase
    {
        /// <summary>
        /// Objeto _estudioRepository que irá receber todos os métodos definidos na interface IEstudioRepository
        /// </summary>
        private IEstudioRepository _estudioRepository { get; set; }

        /// <summary>
        /// Insta o objeto _estudioRepository para que haja a referencia aos metodos do repositorio
        /// </summary>
        public EstudiosController()
        {
            //Instancia _estudioRepository para que os metodos do IEstudioRepository tenham referencia
            _estudioRepository = new EstudioRepository();
        }

        /// <summary>
        /// Lista todos os estudios
        /// </summary>
        /// <returns>Uma lista de estudios code</returns>
        /// http://localhost:5000/api/estudios
        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            //Cria uma lista nomeada listaEstudios para receber os dados
            List<EstudioDomain> listaEstudios = _estudioRepository.ListarTodos();

            //Retorna o status code 200(Ok) com a lista de estudios no formato JSON
            return Ok(listaEstudios);
        }

        /// <summary>
        /// Deleta um estudio existente
        /// </summary>
        /// <param name="id">id do estudio que será deletado</param>
        /// <returns>Um status code 204 - No Content</returns>
        /// http://localhost:5000/api/estudios/4
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Faz a chamada para o método .Deletar()
            _estudioRepository.Deletar(id);

            //Retorna um status code 203 - No Content
            return StatusCode(204);
        }

        /// <summary>
        /// Cadastra um novo estúdio
        /// </summary>
        /// <param name="novoEstudio">objeto novoEstudio com a informacoes cadastradas</param>
        /// <returns>Retorna um status code</returns>
        [Authorize]
        [HttpPost]
        public IActionResult Post(EstudioDomain novoEstudio)
        {
            //Faz a chamada para o metodo .Cadastrar()
            _estudioRepository.Cadastrar(novoEstudio);

            //Se nao, retorna um status code
            return Ok(201);
        }

        /// <summary>
        /// Busca um estudio através do seu id
        /// </summary>
        /// <param name="id">id do estudio que será buscado</param>
        /// <returns>um estudio buscado ou NotFound caso nenhum estudio seja encontrado</returns>
        /// http://localhost:5000/api/estudios/1
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // Cria um objeto estudioBuscado que irá receber o estudio buscado no banco de dados
            EstudioDomain estudioBuscado = _estudioRepository.BuscarPorId(id);

            //Verifica se um gênero foi encontrado
            if (estudioBuscado == null)
            {
                //Caso não seja encontrado, retorna um status code 404 - Not Found com a mensagem personalizada
                return NotFound("Estudio não encontrado");
            }

            //Caso seja encontrado, retorna o gênero buscado com um status code 200 - ok
            return Ok(estudioBuscado);
        }

        /// <summary>
        /// Atualiza um estudio existente passando o seu id pelo corpo da requisicao
        /// </summary>
        /// <param name="estudioAtualizado">Objeto estudioAtualizado com as novas informacoes</param>
        /// <returns>Um status code</returns>
        [Authorize]
        [HttpPut("busca")]
        public IActionResult PutId(EstudioDomain estudioAtualizado)
        {
            //Cria um objeto estudioBuscado que irá receber o estudio buscado no banco de dados
            EstudioDomain estudioBuscado = _estudioRepository.BuscarPorId(estudioAtualizado.idEstudio);

            //Vrifica se algum estudio foi encontrado
            if (estudioBuscado != null)
            {
                //Tenta atualizar o registro
                try
                {
                    //Faz a chamada para o metodo .AtualizarIdCorpo()
                    _estudioRepository.AtualizarIdCorpo(estudioAtualizado);

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
                        mensagem = "Estudio nao encontrado!"
                    }
                );
        }



        /// <summary>
        /// Lista todos os jogos
        /// </summary>
        /// <returns>Uma lista de jogos code</returns>
        /// http://localhost:5000/api/estudios/lista
        /*[Authorize]*/
        [HttpGet("lista")]
        public IActionResult GetAll()
        {
            //Cria uma lista nomeada listaJogos para receber os dados
            List<EstudioDomain> listaJogosEEstudios = _estudioRepository.Listar();

            //Retorna o status code 200(Ok) com a lista de jogos no formato JSON
            return Ok(listaJogosEEstudios);
        }

        /// <summary>
        /// Atualiza um estudio existente passando o seu id pelo corpo da requisicao
        /// </summary>
        /// <param name="estudioAtualizado">Objeto estudioAtualizado com as novas informacoes</param>
        /// <returns>Um status code</returns>
        [Authorize]
        [HttpPut]
        public IActionResult PutIdBody(EstudioDomain estudioAtualizado)
        {
            //Cria um objeto estudioBuscado que irá receber o estudio buscado no banco de dados
            EstudioDomain estudioBuscado = _estudioRepository.BuscarPorId(estudioAtualizado.idEstudio);

            //Vrifica se algum estudio foi encontrado
            if (estudioBuscado != null)
            {
                //Tenta atualizar o registro
                try
                {
                    //Faz a chamada para o metodo .AtualizarIdCorpo()
                    _estudioRepository.AtualizarIdCorpo(estudioAtualizado);

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
                        mensagem = "Estudio nao encontrado!"
                    }
                );
        }
    }
}
