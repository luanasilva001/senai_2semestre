using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using senai.hroads.webApi_.Domains;
using senai.hroads.webApi_.Interfaces;
using senai.hroads.webApi_.Repositories;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace senai.hroads.webApi_.Controllers
{
    //Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    //Define que a rota da requisição será no formato dominió/api/nomeController
    //ex: http://localhost:5000/api/personagens
    [Route("api/[controller]")]

    //Define que é um controlador de API
    [ApiController]
    public class PersonagensController : ControllerBase
    {
         /// <summary>
        /// Objeto _personagemRepository que irá receber todos os métodos definidos na interface IPersonagemRepository
        /// </summary>
        private IPersonagemRepository _personagemRepository { get; set; }

        public PersonagensController()
        {
            _personagemRepository = new PersonagemRepository();
        }

        /// <summary>
        /// Lista todos os personagens
        /// </summary>
        /// <returns>Uma lista de personagens e um status code 200 - OK </returns>
        [Authorize(Roles = "Administrador, Jogador")]
        [HttpGet]
        public IActionResult Get()
        {
            //Retorna a resposta da requisição fazendo a chamada para o método
            return Ok(_personagemRepository.Listar());
        }

        /// <summary>
        /// Lista todos os personagens de um jogador
        /// </summary>
        /// <returns>Uma lista de personagens com o seu jogador e um status code 200 - OK </returns>
        ///////EXTRA//////////
        [HttpGet("personagens-lista")]
        public IActionResult GetPersonagens()
        {
             int idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

            return Ok(_personagemRepository.ListarJogadores(idUsuario));
        }

        /// <summary>
        /// Lista todos os personagens com suas classes ordenadas de A - Z
        /// </summary>
        /// <returns>Uma lista de personagens e sua classe ordenada de A - Z e um status code 200 - OK </returns>
        ///////EXTRA//////////
        [HttpGet("ordenacao")]
        public IActionResult GetOrder()
        {
            return Ok(_personagemRepository.ListaOrdenada());
        }

        [Authorize(Roles = "Administrador")]
        [HttpGet("administrador")]
        public IActionResult GetAdm()
        {
            return Ok(_personagemRepository.Listar());
        }


        /// <summary>
        /// Lista todos os personagens
        /// </summary>
        /// <returns>Uma lista de personagens e um status code 200 - OK </returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            //Retorna a resposta da requisição fazendo a chamada para o método
            return Ok(_personagemRepository.BuscarPorId(id));
        }

        /// <summary>
        /// Lista todos os personagens com seus respectivos tipos
        /// </summary>
        /// <returns>Uma lista de personagens com suas respectivas classes e um status code 200 - OK </returns>
        [HttpGet("personagem-classe")]
        public IActionResult GetClasse()
        {
            //Retorna a resposta da requisição fazendo a chamada para o método
            return Ok(_personagemRepository.ListarClasse());
        }

        /// <summary>
        /// Atualiza um personagem existente
        /// </summary>
        /// <param name="id">ID do personagem que será atualizada</param>
        /// <param name="personagemAtualizado">Objeto personagemAtualizado com as novas informações</param>
        /// <returns>Retorna um status code 204 - No Content</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Personagem personagemAtualizado)
        {
            //Faz a chamada para o método
            _personagemRepository.Atualizar(id, personagemAtualizado);

            //Retorna um status code
            return StatusCode(204);
        }

        /// <summary>
        /// Cadastra um novo personagem
        /// </summary>
        /// <param name="novoPersonagem">Objeto chamado novoPersonagem</param>
        /// <returns>Um status code - 201</returns>
        /*[Authorize(Roles = "Jogador")]*/
        [HttpPost]
        public IActionResult Post(Personagem novoPersonagem)
        {
            try
            {
                
            Personagem personagem = new Personagem() {

                    IdPersonagem = novoPersonagem.IdPersonagem,
                    
                    IdUsuario =  Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value),

                    NomePersonagem = novoPersonagem.NomePersonagem,

                    CapacidadeMaximaVida = novoPersonagem.CapacidadeMaximaVida,

                    CapacidadeMaximaMana = novoPersonagem.CapacidadeMaximaMana,

                    DataAtualização = DateTime.Now,

                    DataDeCriacao = DateTime.Now,

                    IdClasse = novoPersonagem.IdClasse,
                
            };

            //Faz a chamada para o método
            _personagemRepository.Cadastrar(personagem);

            //Retorna um status code
            return StatusCode(201);
                
            }
            catch (Exception ex)
            {
                // Retorna a resposta da requisição 400 - Bad Request e a exception
                return BadRequest(ex);
            }
            
        }

        /// <summary>
        /// Deleta um personagem existente
        /// </summary>
        /// <param name="id">Id do personagem que será deletada</param>
        /// <returns>Retorna um status code 204 - No Content</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //Faz a chamada para o método
            _personagemRepository.Deletar(id);

            //Retorna um status code
            return StatusCode(204);
        }
    }
}