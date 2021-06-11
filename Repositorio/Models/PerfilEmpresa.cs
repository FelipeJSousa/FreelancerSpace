using System;
using System.Collections.Generic;

#nullable disable

namespace Repositorio.Models
{
    public partial class PerfilEmpresa
    {
        public int Id { get; set; }
        public decimal? Likes { get; set; }
        public decimal? Visualizacoes { get; set; }
        public int IdEmpresa { get; set; }

        public virtual Empresa IdEmpresaNavigation { get; set; }
    }
}
