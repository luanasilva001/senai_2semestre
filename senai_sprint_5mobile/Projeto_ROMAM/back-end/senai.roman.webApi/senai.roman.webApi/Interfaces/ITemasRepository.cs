using senai.roman.webApi.Domains;
using System.Collections.Generic;

namespace senai.roman.webApi.Interfaces
{
    interface ITemasRepository
    {
        void Cadastrar(Tema novoTema);

        List<Tema> ListarTemas(int id);

        List<Tema> Listar();
    }
}
