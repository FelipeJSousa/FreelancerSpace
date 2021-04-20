using System;
using System.Collections.Generic;

#nullable disable

namespace Repositorio.Models
{
    public partial class Permissoes
    {
        public Permissoes()
        {
            Acessos = new HashSet<Acesso>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<Acesso> Acessos { get; set; }
    }
}
