using System;
using System.Collections.Generic;

#nullable disable

namespace Repositorio.Models
{
    public partial class NotaAvaliacao
    {
        public int Id { get; set; }
        public string IdEmpresa { get; set; }
        public decimal NotaAvaliacao1 { get; set; }
        public DateTime DataAvaliacao { get; set; }

        public virtual Empresa IdEmpresaNavigation { get; set; }
    }
}
