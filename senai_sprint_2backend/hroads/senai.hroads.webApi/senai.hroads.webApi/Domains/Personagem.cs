using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai.hroads.webApi_.Domains
{
    public partial class Personagem
    {
        public int IdPersonagem { get; set; }

        [Required (ErrorMessage = "Nome do personagem é obrigatório!")]
        public string NomePersonagem { get; set; }

        [Required (ErrorMessage = "Capacidade máxima de vida mana é obrigatório!")]
        public int CapacidadeMaximaVida { get; set; }

        [Required (ErrorMessage = "Capacidade máxima mana é obrigatório!")]
        public int CapacidadeMaximaMana { get; set; }

        [Required (ErrorMessage = "Data de atualização é obrigatório!")]
        [DataType(DataType.Date)]
        public DateTime DataAtualização { get; set; }

        [Required (ErrorMessage = "Data de criação é obrigatório!")]
        [DataType(DataType.Date)]
        public DateTime DataDeCriacao { get; set; }
        public int? IdClasse { get; set; }
        public int? IdUsuario { get; set; }

        public virtual Classe IdClasseNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
