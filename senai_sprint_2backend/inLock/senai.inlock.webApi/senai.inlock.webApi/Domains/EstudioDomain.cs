using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace senai.inlock.webApi.Domains
{
    public class EstudioDomain
    {
        public int idEstudio { get; set; }

        [Required(ErrorMessage = "Nome do estúdio obrigatório")]
        public string nomeEstudio { get; set; }
        public List<JogoDomain> jogo { get; set; }
    }
}
