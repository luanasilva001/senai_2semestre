using System;
using System.ComponentModel.DataAnnotations;

namespace senai.inlock.webApi.Domains
{
    public class JogoDomain
    {
        public int idJogo { get; set; }
        public int? idEstudio { get; set; }

        [Required(ErrorMessage = "O nome do jogo é obrigatório")]
        public string nomeJogo { get; set; }

        [Required(ErrorMessage = "Informe uma descrição do jogo")]
        public string descricao { get; set; }

        [Required(ErrorMessage = "Informe a data de lançamento do jogo")]
        [DataType(DataType.Date)]
        public DateTime dataLancamento { get; set; }

        [Required(ErrorMessage = "O preço do jogo é obrigatório")]
        public decimal valor { get; set; }
        public EstudioDomain Estudio { get; set; }
    }
}
