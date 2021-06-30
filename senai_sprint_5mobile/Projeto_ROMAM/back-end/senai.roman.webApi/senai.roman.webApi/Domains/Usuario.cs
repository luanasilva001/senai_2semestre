using System;
using System.Collections.Generic;

#nullable disable

namespace senai.roman.webApi.Domains
{
    public partial class Usuario
    {
        public Usuario()
        {
            Projetos = new HashSet<Projeto>();
            Temas = new HashSet<Tema>();
        }

        public int IdUsuario { get; set; }
        public int? IdTipoUsuario { get; set; }
        public string Email { get; set; }
        public string NomeUsuario { get; set; }
        public string Senha { get; set; }

        public virtual TipoUsuario IdTipoUsuarioNavigation { get; set; }
        public virtual ICollection<Projeto> Projetos { get; set; }
        public virtual ICollection<Tema> Temas { get; set; }
    }
}
