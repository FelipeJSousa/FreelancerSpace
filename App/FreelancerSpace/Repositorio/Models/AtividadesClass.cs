using System;
using System.Collections.Generic;

#nullable disable

namespace Repositorio.Models
{
    public partial class AtividadesClass
    {
        public AtividadesClass()
        {
            ProdutosServicos = new HashSet<ProdutosServico>();
        }

        public int Id { get; set; }
        public int IdAtividadeGrupos { get; set; }
        public string Nome { get; set; }

        public virtual AtividadesGrupo IdAtividadeGruposNavigation { get; set; }
        public virtual ICollection<ProdutosServico> ProdutosServicos { get; set; }
    }
}
