﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Repositorio.Models
{
    public partial class Funcionario
    {
        public int Id { get; set; }
        public int IdPessoa { get; set; }
        public string Username { get; set; }
        public int IdEmpresa { get; set; }
        public DateTime DataContratacao { get; set; }

        public virtual Empresa IdEmpresaNavigation { get; set; }
        public virtual Pessoa IdPessoaNavigation { get; set; }
        public virtual Usuario UsernameNavigation { get; set; }
    }
}