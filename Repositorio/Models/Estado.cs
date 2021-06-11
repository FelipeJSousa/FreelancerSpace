using System;
using System.Collections.Generic;

#nullable disable

namespace Repositorio.Models
{
    public partial class Estado
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sigla { get; set; }
        public int IdPais { get; set; }

        public virtual Pai IdPaisNavigation { get; set; }
    }
}
