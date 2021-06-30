using senai_wishlist_webApi.Domains;
using System.Collections.Generic;

namespace senai_wishlist_webApi.Interfaces
{
    interface IListaDesejo
    {
        List<ListaDesejo> Listar();

        ListaDesejo BuscarPorId(int id);

        void Cadastrar(ListaDesejo novaListaDesejo);
    }
}
