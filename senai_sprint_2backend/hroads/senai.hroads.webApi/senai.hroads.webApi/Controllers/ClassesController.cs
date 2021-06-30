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
    //ex: http://localhost:5000/api/classes
    [Route("api/[controller]")]

    //Define que é um controlador de API
    [ApiController]

    public class ClassesController : ControllerBase
    {
        /// <summary>
        /// Objeto _classeRepository que irá receber todos os métodos definidos na interface IClasseRepository
        /// </summary>
        private IClasseRepository _classeRepository { get; set; }

        public ClassesController()
        {
            _classeRepository = new ClasseRepository();
        }

        /// <summary>
        /// Lista todas as classes
        /// </summary>
        /// <returns>Uma lista de classes e um status code 200 - OK </returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_classeRepository.Listar());
        }

        /// <summary>
        /// Busca uma classe através do seu ID
        /// </summary>
        /// <param name="id">ID da classe que será buscada</param>
        /// <returns>Uma classe que será buscada</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            //Retorna a resposta da requisição fazenda a chamada para o método
            return Ok(_classeRepository.BuscarPorId(id));
        }

        /// <summary>
        /// Cadastra uma nova classe
        /// </summary>
        /// <param name="novaClasse">Objeto chamado novaClasse</param>
        /// <returns>Um status code - 201</returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(Classe novaClasse)
        {
            //Faz a chamada para o método
            _classeRepository.Cadastrar(novaClasse);

            //Retorna um status code
            return StatusCode(201); 
        }

        /// <summary>
        /// Atualiza uma classe existente
        /// </summary>
        /// <param name="id">ID da Classe que será atualizada</param>
        /// <param name="classeAtualizada">Objeto classeAtualizada com as novas informações</param>
        /// <returns>Retorna um status code 204 - No Content</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Classe classeAtualizada)
        {
            //Faz a chamada para o método
            _classeRepository.Atualizar(id, classeAtualizada);

            //Retorna um status code
            return StatusCode(204);
        }

        /// <summary>
        /// Deleta uma classe existente
        /// </summary>
        /// <param name="id">Id da classe que será deletada</param>
        /// <returns>Retorna um status code 204 - No Content</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete (int id)
        {
            //Faz a chamada para o método
            _classeRepository.Deletar(id);

            //Retorna um status code
            return StatusCode(204);
        }
    }
}
