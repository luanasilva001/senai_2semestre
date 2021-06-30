using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.roman.webApi.Domains;
using senai.roman.webApi.Interfaces;
using senai.roman.webApi.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace senai.roman.webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TemasController : ControllerBase
    {
        private ITemasRepository _temaRepository { get; set; }
        public TemasController()
        {
            _temaRepository = new TemaRepository();
        }

        [Authorize (Roles = "1")]
        [HttpGet]
        public IActionResult Get()
        {
            int idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

            return Ok(_temaRepository.ListarTemas(idUsuario));
        }

        [Authorize(Roles = "1")]
        [HttpGet("listartodas")]
        public IActionResult GetTemas()
        {

            return Ok(_temaRepository.Listar());
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post (Tema novoTema)
        {
            try
            {
                Tema tema = new Tema()
                {
                    IdTema = novoTema.IdTema,

                    TituloTema = novoTema.TituloTema,

                    IdUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value),

                };

                _temaRepository.Cadastrar(tema);

                return StatusCode(201);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
