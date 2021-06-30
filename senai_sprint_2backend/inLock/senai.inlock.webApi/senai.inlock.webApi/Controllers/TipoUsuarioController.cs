using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using senai.inlock.webApi.Repositories;
using System.Collections.Generic;

namespace senai.inlock.webApi.Controllers
{
    //Define que o tipo de resposta da api será no formato json
    [Produces("application/json")]

    //Define que a rota de uma requisição será no formato dominio/api/nomeController
    // ex: http://localhost:5000/api/tipousuario
    [Route("api/[controller]")]

    //Define que é um controlador de API
    [ApiController]
    public class TipoUsuarioController : ControllerBase
    {
        /// <summary>
        /// Objeto _tiposUsuariosController que irá receber todos os métodos definidos na interface ITipoUsuarioRepository
        /// </summary>
        private ITipoUsuarioRepository _tiposUsuariosController { get; set; }

        /// <summary>
        /// Insta o objeto _tiposUsuariosController para que haja a referencia aos metodos do repositorio
        /// </summary>
        public TipoUsuarioController()
        {
            //Instancia _tiposUsuariosController para que os metodos do ITipoUsuarioRepository tenham referencia
            _tiposUsuariosController = new TipoUsuarioRepository();
        }

        /// <summary>
        /// Lista todos os tipos de usuários
        /// </summary>
        /// <returns>Uma lista de tipos usuários code</returns>
        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult Get()
        {
            //Cria uma lista nomeada listaTiposUsuarios para receber os dados
            List<TipoUsuarioDomain> listaTiposUsuarios = _tiposUsuariosController.ListarTiposUsuarios();

            //Retorna o status code 200(Ok) com a lista de tipos de usuarios no formato JSON
            return Ok(listaTiposUsuarios);
        }
    }
}
