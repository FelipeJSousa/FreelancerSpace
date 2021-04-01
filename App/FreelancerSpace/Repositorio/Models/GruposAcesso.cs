using System;
using System.Collections.Generic;

#nullable disable

namespace Repositorio.Models
{
    public partial class GruposAcesso
    {
        public GruposAcesso()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int IdAcessos { get; set; }

        public virtual Acesso IdAcessosNavigation { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
