using System;
using System.Collections.Generic;

#nullable disable

namespace Repositorio.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Pessoas = new HashSet<Pessoa>();
        }

        public string Username { get; set; }
        public int IdGrupoAcesso { get; set; }
        public string Senha { get; set; }
        public string Ativo { get; set; }

        public virtual GrupoAcesso IdGrupoAcessoNavigation { get; set; }
        public virtual ICollection<Pessoa> Pessoas { get; set; }
    }
}
