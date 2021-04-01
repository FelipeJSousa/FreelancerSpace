using System;
using System.Collections.Generic;

#nullable disable

namespace Repositorio.Models
{
    public partial class ProdutosServicosXempresa
    {
        public int IdProdutoServico { get; set; }
        public int IdEmpresa { get; set; }

        public virtual Empresa IdEmpresaNavigation { get; set; }
        public virtual ProdutosServico IdProdutoServicoNavigation { get; set; }
    }
}
