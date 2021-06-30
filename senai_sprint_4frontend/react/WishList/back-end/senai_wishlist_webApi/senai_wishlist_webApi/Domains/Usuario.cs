using System;
using System.Collections.Generic;

#nullable disable

namespace senai_wishlist_webApi.Domains
{
    public partial class Usuario
    {
        public Usuario()
        {
            ListaDesejos = new HashSet<ListaDesejo>();
        }

        public int IdUsuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public virtual ICollection<ListaDesejo> ListaDesejos { get; set; }
    }
}
