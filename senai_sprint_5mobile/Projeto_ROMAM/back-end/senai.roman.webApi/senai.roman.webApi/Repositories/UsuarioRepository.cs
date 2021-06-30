using senai.roman.webApi.Contexts;
using senai.roman.webApi.Domains;
using senai.roman.webApi.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace senai.roman.webApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        RomanContext ctx = new RomanContext();
        public Usuario BuscarPorEmailSenha(string email, string senha)
        {
            return ctx.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }

        public List<Usuario> Listar()
        {
            return ctx.Usuarios.ToList();
        }
    }
}
