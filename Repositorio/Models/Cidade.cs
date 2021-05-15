using System;
using System.Collections.Generic;

#nullable disable

namespace Repositorio.Models
{
    public partial class Cidade
    {
        public Cidade()
        {
            Enderecos = new HashSet<Endereco>();
        }

        public int Id { get; set; }
        public int IdEstado { get; set; }
        public string Nome { get; set; }
        public string Sigla { get; set; }

        public virtual Estado IdEstadoNavigation { get; set; }
        public virtual ICollection<Endereco> Enderecos { get; set; }
    }
}
