using System;
using System.Collections.Generic;

#nullable disable

namespace Repositorio.Models
{
    public partial class GrupoAcesso
    {
        public GrupoAcesso()
        {
            Acessos = new HashSet<Acesso>();
            Usuarios = new HashSet<Usuario>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<Acesso> Acessos { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
