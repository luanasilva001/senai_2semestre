using senai.roman.webApi.Domains;
using System.Collections.Generic;

namespace senai.roman.webApi.Interfaces
{
    interface IUsuarioRepository
    {
        Usuario BuscarPorEmailSenha(string email, string senha);

        List<Usuario> Listar();

    }
}

