using System;
using System.Collections.Generic;

#nullable disable

namespace Repositorio.Models
{
    public partial class Pessoa
    {
        public Pessoa()
        {
            Clientes = new HashSet<Cliente>();
            Funcionarios = new HashSet<Funcionario>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Ativo { get; set; }
        public string Usuario { get; set; }

        public virtual Usuario UsuarioNavigation { get; set; }
        public virtual ICollection<Cliente> Clientes { get; set; }
        public virtual ICollection<Funcionario> Funcionarios { get; set; }
    }
}
