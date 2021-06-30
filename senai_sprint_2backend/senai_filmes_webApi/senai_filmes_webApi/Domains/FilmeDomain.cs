using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webApi.Domains
{
    /// <summary>
    /// Classe que representa a entidade (tabela) filmes
    /// </summary>
    public class FilmeDomain
    {

        public int idFilme { get; set; }

        [Required(ErrorMessage = "Título do filme obrigatório")]
        public string titulo { get; set; }

        public int idGenero { get; set; }

        [Required (ErrorMessage = "Gênero do filme obrigatório")]
        public GeneroDomain genero { get; set; }
    }
}
