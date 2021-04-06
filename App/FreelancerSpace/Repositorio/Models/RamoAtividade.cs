using System;
using System.Collections.Generic;

#nullable disable

namespace Repositorio.Models
{
    public partial class RamoAtividade
    {
        public RamoAtividade()
        {
            ProdutosServicos = new HashSet<ProdutosServico>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<ProdutosServico> ProdutosServicos { get; set; }
    }
}
