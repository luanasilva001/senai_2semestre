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
    //ex: http://localhost:5000/api/tiposusuario
    [Route("api/[controller]")]

    //Define que é um controlador de API
    [ApiController]
    public class TiposUsuarioController : ControllerBase
    {
         /// <summary>
        /// Objeto _tipoUsuarioRepository que irá receber todos os métodos definidos na interface ITipoUsuarioRepository
        /// </summary>
        private ITipoUsuarioRepository _tipoUsuarioRepository { get; set; }

        public TiposUsuarioController()
        {
            _tipoUsuarioRepository = new TipoUsuarioRepository();
        }

        /// <summary>
        /// Lista todos os tipos de usuários
        /// </summary>
        /// <returns>Uma lista de tipos de usuários e um status code 200 - OK </returns>
        [HttpGet]
        public IActionResult Get()
        {
            //Retorna a resposta da requisição fazendo a chamada para o método
            return Ok(_tipoUsuarioRepository.Listar());
        }

        /// <summary>
        /// Busca um tipo de usuário através do seu ID
        /// </summary>
        /// <param name="id">ID do tipo de usuário que será buscada</param>
        /// <returns>Um tipo de usuário que será buscada</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            //Retorna a resposta da requisição fazenda a chamada para o método
            return Ok(_tipoUsuarioRepository.BuscarPorId(id));
        }

        /// <summary>
        /// Atualiza um tipo de usuário existente
        /// </summary>
        /// <param name="id">ID de um tipo de usuário que será atualizada</param>
        /// <param name="tipoUsuarioAtualizado">Objeto tipoUsuarioAtualizado com as novas informações</param>
        /// <returns>Retorna um status code 204 - No Content</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, TipoUsuario tipoUsuarioAtualizado)
        {
            //Faz a chamada para o método
            _tipoUsuarioRepository.Atualizar(id, tipoUsuarioAtualizado);

            //Retorna um status code
            return StatusCode(204);
        }

        /// <summary>
        /// Cadastra um novo tipo usuário
        /// </summary>
        /// <param name="novoTipoUsuario">Objeto chamado novoTipoUsuario</param>
        /// <returns>Um status code - 201</returns>
        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public IActionResult Post(TipoUsuario novoTipoUsuario)
        {
            //Faz a chamada para o método
            _tipoUsuarioRepository.Cadastrar(novoTipoUsuario);

            //Retorna um status code
            return StatusCode(201);
        }

        /// <summary>
        /// Deleta um tipo de usuário existente
        /// </summary>
        /// <param name="id">Id do tipo de usuário que será deletada</param>
        /// <returns>Retorna um status code 204 - No Content</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //Faz a chamada para o método
            _tipoUsuarioRepository.Deletar(id);

            //Retorna um status code
            return StatusCode(204);
        }
    }
}