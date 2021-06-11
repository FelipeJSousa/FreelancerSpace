using System;
using System.Collections.Generic;

#nullable disable

namespace Repositorio.Models
{
    public partial class TelefoneXempresa
    {
        public int IdTelefone { get; set; }
        public int IdEmpresa { get; set; }
        public int Id { get; set; }

        public virtual Empresa IdEmpresaNavigation { get; set; }
        public virtual Telefone IdTelefoneNavigation { get; set; }
    }
}
