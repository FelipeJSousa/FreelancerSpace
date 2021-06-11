using System;
using System.Collections.Generic;

#nullable disable

namespace Repositorio.Models
{
    public partial class HorarioAtendimentoXempresa
    {
        public int IdEmpresa { get; set; }
        public int IdHorarioAtendimento { get; set; }
        public int Id { get; set; }

        public virtual Empresa IdEmpresaNavigation { get; set; }
        public virtual HorarioAtendimento IdHorarioAtendimentoNavigation { get; set; }
    }
}
