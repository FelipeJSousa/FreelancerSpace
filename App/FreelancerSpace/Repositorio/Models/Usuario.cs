using System;
using System.Collections.Generic;

#nullable disable

namespace Repositorio.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Clientes = new HashSet<Cliente>();
            Funcionarios = new HashSet<Funcionario>();
        }

        public string Username { get; set; }
        public int IdGrupoAcesso { get; set; }
        public string Senha { get; set; }
        public string Ativo { get; set; }

        public virtual GrupoAcesso IdGrupoAcessoNavigation { get; set; }
        public virtual ICollection<Cliente> Clientes { get; set; }
        public virtual ICollection<Funcionario> Funcionarios { get; set; }
    }
}
