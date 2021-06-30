using senai.inlock.webApi.Domains;
using System.Collections.Generic;

namespace senai.inlock.webApi.Interfaces
{
    interface ITipoUsuarioRepository
    {
        List<TipoUsuarioDomain> ListarTiposUsuarios();
    }
}
