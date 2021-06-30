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
    //ex: http://localhost:5000/api/habilidades
    [Route("api/[controller]")]

    //Define que é um controlador de API
    [ApiController]
    public class HabilidadesController : ControllerBase
    {
        /// <summary>
        /// Objeto _habilidadeRepository que irá receber todos os métodos definidos na interface IHabilidadeRepository
        /// </summary>
        private IHabilidadeRepository _habilidadeRepository { get; set; }

        public HabilidadesController()
        {
            _habilidadeRepository = new HabilidadeRepository();
        }

        /// <summary>
        /// Lista todas as habilidades
        /// </summary>
        /// <returns>Uma lista de habilidades e um status code 200 - OK </returns>
        [HttpGet]
        public IActionResult Get()
        {
            //Retorna a resposta da requisição fazendo a chamada para o método
            return Ok(_habilidadeRepository.Listar());
        }

        /// <summary>
        /// Lista todas as habilidades com seus respectivos tipos
        /// </summary>
        /// <returns>Uma lista de habilidades com seus respectivos tipos e um status code 200 - OK </returns>
        [HttpGet("tipo-habilidade")]
        public IActionResult GetTipoHabilidade()
        {
            //Retorna a resposta da requisição fazendo a chamada para o método
            return Ok(_habilidadeRepository.ListarTipoHabilidade());
        }

        /// <summary>
        /// Busca uma habilidade através do seu ID
        /// </summary>
        /// <param name="id">ID da habilidade que será buscada</param>
        /// <returns>Uma habilidade que será buscada</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            //Retorna a resposta da requisição fazenda a chamada para o método
            return Ok(_habilidadeRepository.BuscarPorId(id));
        }

        /// <summary>
        /// Atualiza uma habilidade existente
        /// </summary>
        /// <param name="id">ID da habilidade que será atualizada</param>
        /// <param name="habilidadeAtualizada">Objeto habilidadeAtualizada com as novas informações</param>
        /// <returns>Retorna um status code 204 - No Content</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Habilidade habilidadeAtualizada)
        {
            //Faz a chamada para o método
            _habilidadeRepository.Atualizar(id, habilidadeAtualizada);

            //Retorna um status code
            return StatusCode(204);
        }

        /// <summary>
        /// Cadastra uma nova habilidade
        /// </summary>
        /// <param name="novaHabilidade">Objeto chamado novaHabilidade</param>
        /// <returns>Um status code - 201</returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(Habilidade novaHabilidade)
        {
            //Faz a chamada para o método
            _habilidadeRepository.Cadastrar(novaHabilidade);

            //Retorna um status code
            return StatusCode(201);
        }

        /// <summary>
        /// Deleta uma habilidade existente
        /// </summary>
        /// <param name="id">Id da habilidade que será deletada</param>
        /// <returns>Retorna um status code 204 - No Content</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //Faz a chamada para o método
            _habilidadeRepository.Deletar(id);

            //Retorna um status code
            return StatusCode(204);
        }
    }
}
