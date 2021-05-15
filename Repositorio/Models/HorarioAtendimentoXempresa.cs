using System;
using System.Collections.Generic;

#nullable disable

namespace Repositorio.Models
{
    public partial class HorarioAtendimentoXempresa
    {
        public string IdEmpresa { get; set; }
        public int IdHorarioAtendimento { get; set; }

        public virtual Empresa IdEmpresaNavigation { get; set; }
        public virtual HorarioAtendimento IdHorarioAtendimentoNavigation { get; set; }
    }
}
