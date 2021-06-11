using System;
using System.Collections.Generic;

#nullable disable

namespace Repositorio.Models
{
    public partial class EnderecosXempresa
    {
        public int IdEndereco { get; set; }
        public int IdEmpresa { get; set; }
        public int Id { get; set; }

        public virtual Empresa IdEmpresaNavigation { get; set; }
        public virtual Endereco IdEnderecoNavigation { get; set; }
    }
}
