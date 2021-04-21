using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreelancerSpace.Models
{
    public class FuncionariosModel
    {
        public int Id { get; set; }
        public int IdPessoa { get; set; }
        public string Username { get; set; }
        public int IdEmpresa { get; set; }
        public DateTime DataContratacao { get; set; }

        public virtual EmpresaModel IdEmpresaNavigation { get; set; }
        public virtual PessoaModel IdPessoaNavigation { get; set; }
        public virtual UsuariosModel UsernameNavigation { get; set; }
    }
}
