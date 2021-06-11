using System;
using System.Collections.Generic;

#nullable disable

namespace Repositorio.Models
{
    public partial class ProdutosServico
    {
        public ProdutosServico()
        {
            ProdutosServicosXempresas = new HashSet<ProdutosServicosXempresa>();
        }

        public int Id { get; set; }
        public string IdRamoAtividade { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Ativo { get; set; }

        public virtual Cnae IdRamoAtividadeNavigation { get; set; }
        public virtual ICollection<ProdutosServicosXempresa> ProdutosServicosXempresas { get; set; }
    }
}
