using System;
using System.Collections.Generic;

#nullable disable

namespace senai_wishlist_webApi.Domains
{
    public partial class ListaDesejo
    {
        public int IdDesejo { get; set; }
        public int? IdUsuario { get; set; }
        public string Descricaodesejo { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
