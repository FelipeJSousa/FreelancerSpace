using System;
using System.Collections.Generic;

#nullable disable

namespace Repositorio.Models
{
    public partial class Pai
    {
        public Pai()
        {
            Estados = new HashSet<Estado>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sigla { get; set; }

        public virtual ICollection<Estado> Estados { get; set; }
    }
}
