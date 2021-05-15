using System;
using System.Collections.Generic;

#nullable disable

namespace Repositorio.Models
{
    public partial class ProdutosServico
    {
        public int Id { get; set; }
        public int IdRamoAtividade { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Ativo { get; set; }

        public virtual RamoAtividade IdRamoAtividadeNavigation { get; set; }
    }
}
