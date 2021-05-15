using System;
using System.Collections.Generic;

#nullable disable

namespace Repositorio.Models
{
    public partial class EnderecosXempresa
    {
        public int IdEndereco { get; set; }
        public string IdEmpresa { get; set; }

        public virtual Empresa IdEmpresaNavigation { get; set; }
        public virtual Endereco IdEnderecoNavigation { get; set; }
    }
}
