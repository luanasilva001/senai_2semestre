using System;
using System.Collections.Generic;

#nullable disable

namespace senai.roman.webApi.Domains
{
    public partial class Projeto
    {
        public int IdProjeto { get; set; }
        public int? IdTema { get; set; }
        public string Projeto1 { get; set; }
        public int? IdUsuario { get; set; }

        public virtual Tema IdTemaNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
