using System;
using System.Collections.Generic;

#nullable disable

namespace Repositorio.Models
{
    public partial class Funcionario
    {
        public int Id { get; set; }
        public int IdPessoa { get; set; }
        public string IdEmpresa { get; set; }
        public DateTime DataContratacao { get; set; }
        public string Ativo { get; set; }

        public virtual Empresa IdEmpresaNavigation { get; set; }
        public virtual Pessoa IdPessoaNavigation { get; set; }
    }
}
