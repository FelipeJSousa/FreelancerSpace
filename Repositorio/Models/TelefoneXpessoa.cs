using System;
using System.Collections.Generic;

#nullable disable

namespace Repositorio.Models
{
    public partial class TelefoneXpessoa
    {
        public int IdTelefone { get; set; }
        public int IdPessoa { get; set; }
        public int Id { get; set; }

        public virtual Pessoa IdPessoaNavigation { get; set; }
        public virtual Telefone IdTelefoneNavigation { get; set; }
    }
}
