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
    //ex: http://localhost:5000/api/usuario
    [Route("api/[controller]")]

    //Define que é um controlador de API
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        /// <summary>
        /// Objeto _usuarioRepository que irá receber todos os métodos definidos na interface IUsuarioRepository
        /// </summary>
        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_usuarioRepository.Listar());
        }

        [HttpGet("email-listado")]
        public IActionResult Login ()
        {
            return Ok(_usuarioRepository.ListarEmail());
        }

        /// <summary>
        /// Lista todos os usuarios com seus respectivos tipos
        /// </summary>
        /// <returns>Uma lista de usuarios com seus respectivos tipos e um status code 200 - OK </returns>
        [HttpGet("tipo-usuario")]
        public IActionResult GetTipoUsuario()
        {
            return Ok(_usuarioRepository.ListarTipoUsuario());
        }

        /// <summary>
        /// Busca um usuário através do seu ID
        /// </summary>
        /// <param name="id">ID do usuário que será buscado</param>
        /// <returns>Um usuário que será buscada</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            //Retorna a resposta da requisição fazenda a chamada para o método
            return Ok(_usuarioRepository.BuscarPorId(id));
        }

        /// <summary>
        /// Atualiza um usuário existente
        /// </summary>
        /// <param name="id">ID do usuário que será atualizado</param>
        /// <param name="usuarioAtualizado">Objeto usuarioAtualizado com as novas informações</param>
        /// <returns>Retorna um status code 204 - No Content</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Usuario usuarioAtualizado)
        {
            //Faz a chamada para o método
            _usuarioRepository.Atualizar(id, usuarioAtualizado);

            //Retorna um status code
            return StatusCode(204);
        }

        /// <summary>
        /// Cadastra um novo usuário
        /// </summary>
        /// <param name="novoUsuario">Objeto chamado novoUsuario</param>
        /// <returns>Um status code - 201</returns>
        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public IActionResult Post(Usuario novoUsuario)
        {
            //Faz a chamada para o método
            _usuarioRepository.Cadastrar(novoUsuario);

            //Retorna um status code
            return StatusCode(201);
        }

        /// <summary>
        /// Deleta um usuário existente
        /// </summary>
        /// <param name="id">Id do usuário que será deletado</param>
        /// <returns>Retorna um status code 204 - No Content</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //Faz a chamada para o método
            _usuarioRepository.Deletar(id);

            //Retorna um status code
            return StatusCode(204);
        }
    }
}