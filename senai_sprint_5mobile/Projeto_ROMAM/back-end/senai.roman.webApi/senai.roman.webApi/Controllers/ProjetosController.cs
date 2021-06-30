using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.roman.webApi.Domains;
using senai.roman.webApi.Interfaces;
using senai.roman.webApi.Repositories;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace senai.roman.webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProjetosController : ControllerBase
    {
        private IProjetoRepository _consultaRepository { get; set; }

        public ProjetosController()
        {
            _consultaRepository = new ProjetoRepository();
        }

        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult Get()
        {
            int idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

            return Ok(_consultaRepository.ListarProjetos(idUsuario));
        }

        [Authorize(Roles = "1")]
        [HttpGet("listartodas")]
        public IActionResult GetProjetos()
        {
            return Ok(_consultaRepository.Listar());
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post (Projeto novoProjeto)
        {
            try
            {
                Projeto projeto = new Projeto()
                {
                    IdProjeto = novoProjeto.IdProjeto,
                    IdTema = novoProjeto.IdTema,
                    Projeto1 = novoProjeto.Projeto1,
                    IdUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value)
                };
                _consultaRepository.Cadastrar(projeto);

                return StatusCode(201);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
