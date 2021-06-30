using Microsoft.AspNetCore.Mvc;
using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interfaces;
using Senai.Peoples.WebApi.Repositories;
using System.Collections.Generic;

namespace Senai.Peoples.WebApi.Controllers
{
    //Define que o tipo de resposta da api será no formato json
    [Produces("application/json")]

    //Define que a rota de uma requisição será no formato dominio/api/nomeController
    // ex: http://localhost:5000/api/tipousuarios
    [Route("api/[controller]")]

    //Define que é um controlador de API
    [ApiController]
    public class TipoUsuariosController : ControllerBase
    {
        /// <summary>
        /// Objeto _funcionarioRepository que irá receber todos os métodos definidos na interface IFuncionarioRepository
        /// </summary>
        private ITipoUsuarioRepository _tiposUsuariosController { get; set; }

        /// <summary>
        /// Insta o objeto _funcionarioRepository para que haja a referencia aos metodos do repositorio
        /// </summary>
        public TipoUsuariosController()
        {
            //Instancia _funcionarioRepository para que os metodos do IFuncionarioRepository tenham referencia
            _tiposUsuariosController = new TipoUsuarioRepository();
        }

        /// <summary>
        /// Lista todos os tipos de usuários
        /// </summary>
        /// <returns>Uma lista de funcionarios code</returns>
        [HttpGet]
        public IActionResult Get()
        {
            //Cria uma lista nomeada listaFuncionarios para receber os dados
            List<TipoUsuarioDomain> listaTiposUsuarios = _tiposUsuariosController.ListarTiposUsuarios();

            //Retorna o status code 200(Ok) com a lista de funcionarios no formato JSON
            return Ok(listaTiposUsuarios);
        }
    }
}
