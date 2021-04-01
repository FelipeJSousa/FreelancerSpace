using System;
using System.Collections.Generic;

#nullable disable

namespace Repositorio.Models
{
    public partial class Endereco
    {
        public int Id { get; set; }
        public int IdTipoEndereco { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
        public int IdCidade { get; set; }
        public int IdEstado { get; set; }

        public virtual Cidade IdCidadeNavigation { get; set; }
        public virtual Estado IdEstadoNavigation { get; set; }
        public virtual TiposEndereco IdTipoEnderecoNavigation { get; set; }
    }
}
