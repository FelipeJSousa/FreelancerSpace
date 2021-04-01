using System;
using System.Collections.Generic;

#nullable disable

namespace Repositorio.Models
{
    public partial class EnderecosXpessoa
    {
        public int IdEndereco { get; set; }
        public int IdPessoa { get; set; }

        public virtual Endereco IdEnderecoNavigation { get; set; }
        public virtual Pessoa IdPessoaNavigation { get; set; }
    }
}
