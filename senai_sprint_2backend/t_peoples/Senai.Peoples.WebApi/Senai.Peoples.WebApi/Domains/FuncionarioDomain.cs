using System;
using System.ComponentModel.DataAnnotations;

namespace Senai.Peoples.WebApi.Domains
{
    public class FuncionarioDomain
    {
        public int idFuncionario { get; set; }

        [Required(ErrorMessage = "O nome do funcionário é obrigatório!")]
        public string nome { get; set; }

        public string sobrenome { get; set; }

        [Required(ErrorMessage = "Informe a data de nascimento do funcionário")]
        [DataType(DataType.Date)]
        public DateTime dataNascimento { get; set; }
    }
}
