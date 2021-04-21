using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreelancerSpace.Models
{
    public class ClienteModel
    {
        public int Id { get; set; }
        public int IdPessoa { get; set; }
        public string Usuario { get; set; }
        public string Interesses { get; set; }

        public virtual PessoaModel IdPessoaNavigation { get; set; }
        public virtual UsuariosModel UsuarioNavigation { get; set; }
    }
}
