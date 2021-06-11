using System;
using System.Collections.Generic;

#nullable disable

namespace Repositorio.Models
{
    public partial class HorarioAtendimento
    {
        public HorarioAtendimento()
        {
            HorarioAtendimentoXempresas = new HashSet<HorarioAtendimentoXempresa>();
        }

        public int Id { get; set; }
        public string DiasAtendimento { get; set; }
        public string HorarioAtendimento1 { get; set; }

        public virtual ICollection<HorarioAtendimentoXempresa> HorarioAtendimentoXempresas { get; set; }
    }
}
