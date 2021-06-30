using System.ComponentModel.DataAnnotations;

namespace senai.inlock.webApi.Domains
{
    public class TipoUsuarioDomain
    {
        public int idTipoUsuario { get; set; }

        [Required(ErrorMessage = "O nome do tipo de usuário é obrigatório!")]
        public string tituloTipoUsuario { get; set; }
    }
}
