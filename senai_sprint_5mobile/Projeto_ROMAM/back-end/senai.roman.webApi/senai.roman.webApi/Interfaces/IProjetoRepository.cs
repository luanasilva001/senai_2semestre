using senai.roman.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.roman.webApi.Interfaces
{
    interface IProjetoRepository
    {
        List<Projeto> Listar();

        void Cadastrar(Projeto novoProjeto);

        List<Projeto> ListarProjetos(int id);
    }
}
