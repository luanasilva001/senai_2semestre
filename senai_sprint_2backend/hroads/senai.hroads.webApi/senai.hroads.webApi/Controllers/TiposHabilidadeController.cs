using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using senai.hroads.webApi_.Domains;
using senai.hroads.webApi_.Interfaces;
using senai.hroads.webApi_.Repositories;

namespace senai.hroads.webApi_.Controllers
{
    //Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    //Define que a rota da requisição será no formato dominió/api/nomeController
    //ex: http://localhost:5000/api/tiposhabilidade
    [Route("api/[controller]")]

    //Define que é um controlador de API
    [ApiController]

    public class TiposHabilidadeController : ControllerBase
    {
        /// <summary>
        /// Objeto _tipoHabilidadeRepository que irá receber todos os métodos definidos na interface ITipoHabilidadeRepository
        /// </summary>
        private ITipoHabilidadeRepository _tipoHabilidadeRepository { get; set; }

        public TiposHabilidadeController()
        {
            _tipoHabilidadeRepository = new TipoHabilidadeRepository();
        }

        /// <summary>
        /// Lista todos os tipos de habilidade
        /// </summary>
        /// <returns>Uma lista de tipos de habilidade e um status code 200 - OK </returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_tipoHabilidadeRepository.Listar());
        }

        /// <summary>
        /// Busca um tipo de habilidade através do seu ID
        /// </summary>
        /// <param name="id">ID do tipo de habilidade que será buscada</param>
        /// <returns>Um novo tipo de habilidade que será buscado</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            //Retorna a resposta da requisição fazenda a chamada para o método
            return Ok(_tipoHabilidadeRepository.BuscarPorId(id));
        }

        /// <summary>
        /// Cadastra um novo tipo de habilidade
        /// </summary>
        /// <param name="novoTipoHabilidade">Objeto chamado novoTipoHabilidade</param>
        /// <returns>Um status code - 201</returns>
        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public IActionResult Post(TipoHabilidade novoTipoHabilidade)
        {
            //Faz a chamada para o método

            _tipoHabilidadeRepository.Cadastrar(novoTipoHabilidade);

            //Retorna um status code
            return StatusCode(201); 
        }

        /// <summary>
        /// Atualiza um tipo de habilidade existente
        /// </summary>
        /// <param name="id">ID de um tipo de habilidade que será atualizado</param>
        /// <param name="novaClasse">Objeto tipoHabilidadeAtualizado com as novas informações</param>
        /// <returns>Retorna um status code 204 - No Content</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, TipoHabilidade tipoHabilidadeAtualizado)
        {
            //Faz a chamada para o método
            _tipoHabilidadeRepository.Atualizar(id, tipoHabilidadeAtualizado);

            //Retorna um status code
            return StatusCode(204);
        }

        /// <summary>
        /// Deleta um tipo de habilidade existente
        /// </summary>
        /// <param name="id">Id do tipo de habilidade que será deletado</param>
        /// <returns>Retorna um status code 204 - No Content</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete (int id)
        {
            //Faz a chamada para o método
            _tipoHabilidadeRepository.Deletar(id);

            //Retorna um status code
            return StatusCode(204);
        }
    }
}
