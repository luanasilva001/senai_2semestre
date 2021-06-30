using Senai.Peoples.WebApi.Domains;
using System.Collections.Generic;

namespace Senai.Peoples.WebApi.Interfaces
{
    interface ITipoUsuarioRepository
    {
        List<TipoUsuarioDomain> ListarTiposUsuarios();
    }
}
