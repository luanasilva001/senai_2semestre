using Microsoft.AspNetCore.Mvc;
using senai_wishlist_webApi.Domains;
using senai_wishlist_webApi.Repositories;

namespace senai_wishlist_webApi.Controllers
{
    //Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    //Define que a rota da requisição será no formato dominió/api/nomeController
    //ex: http://localhost:5000/api/listadesejo
    [Route("api/[controller]")]

    //Define que é um controlador de API
    [ApiController]
    public class ListaDesejoController : ControllerBase
    {
        private ListaDesejoRepository _listaDesejoRepository { get; set; }

        public ListaDesejoController()
        {
            _listaDesejoRepository = new ListaDesejoRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_listaDesejoRepository.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_listaDesejoRepository.BuscarPorId(id));
        }

        [HttpPost]
        public IActionResult Post(ListaDesejo novaLista)
        {
            _listaDesejoRepository.Cadastrar(novaLista);

            return StatusCode(201);
        }
    }
}
