using System;
using System.Collections.Generic;

#nullable disable

namespace Repositorio.Models
{
    public partial class AtividadesDiviso
    {
        public AtividadesDiviso()
        {
            AtividadesGrupos = new HashSet<AtividadesGrupo>();
            Empresas = new HashSet<Empresa>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<AtividadesGrupo> AtividadesGrupos { get; set; }
        public virtual ICollection<Empresa> Empresas { get; set; }
    }
}
