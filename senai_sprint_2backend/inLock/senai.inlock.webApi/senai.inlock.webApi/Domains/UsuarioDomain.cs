using System.ComponentModel.DataAnnotations;

namespace senai.inlock.webApi.Domains
{
    public class UsuarioDomain
    {
        public int idUsuario { get; set; }

        public int idTipoUsuario { get; set; }

        // Define que o campo é obrigatório
        [Required(ErrorMessage = "Informe o e-mail")]
        public string email { get; set; }

        // Define que o campo é obrigatório, com no mínimo 3 e no máxiimo 20 caracteres
        [Required(ErrorMessage = "Informe a senha")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "O campo senha precisa ter no mínimo 3 caracteres")]
        public string senha { get; set; }
    }
}
