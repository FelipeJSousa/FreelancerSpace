using System;
using System.Collections.Generic;

#nullable disable

namespace Repositorio.Models
{
    public partial class TiposEndereco
    {
        public TiposEndereco()
        {
            Enderecos = new HashSet<Endereco>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Endereco> Enderecos { get; set; }
    }
}
