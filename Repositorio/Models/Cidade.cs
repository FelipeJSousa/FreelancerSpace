using System;
using System.Collections.Generic;

#nullable disable

namespace Repositorio.Models
{
    public partial class Cidade
    {
        public int Id { get; set; }
        public int IdEstado { get; set; }
        public string Nome { get; set; }
        public string Sigla { get; set; }

        public virtual Estado IdEstadoNavigation { get; set; }
    }
}
