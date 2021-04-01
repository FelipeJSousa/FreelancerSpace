using System;
using System.Collections.Generic;

#nullable disable

namespace Repositorio.Models
{
    public partial class ProdutosServico
    {
        public int Id { get; set; }
        public int IdAtividadeClasse { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public virtual AtividadesClass IdAtividadeClasseNavigation { get; set; }
    }
}
