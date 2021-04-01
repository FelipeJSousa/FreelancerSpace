using System;
using System.Collections.Generic;

#nullable disable

namespace Repositorio.Models
{
    public partial class AtividadesGrupo
    {
        public AtividadesGrupo()
        {
            AtividadesClasses = new HashSet<AtividadesClass>();
        }

        public int Id { get; set; }
        public int IdAtividadeDivisao { get; set; }
        public string Nome { get; set; }

        public virtual AtividadesDiviso IdAtividadeDivisaoNavigation { get; set; }
        public virtual ICollection<AtividadesClass> AtividadesClasses { get; set; }
    }
}
