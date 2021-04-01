using System;
using System.Collections.Generic;

#nullable disable

namespace Repositorio.Models
{
    public partial class Cliente
    {
        public int Id { get; set; }
        public int IdPessoa { get; set; }
        public string Usuario { get; set; }
        public string Interesses { get; set; }

        public virtual Pessoa IdPessoaNavigation { get; set; }
        public virtual Usuario UsuarioNavigation { get; set; }
    }
}
