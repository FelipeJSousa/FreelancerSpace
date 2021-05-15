using System;
using System.Collections.Generic;

#nullable disable

namespace Repositorio.Models
{
    public partial class Estado
    {
        public Estado()
        {
            Cidades = new HashSet<Cidade>();
            Enderecos = new HashSet<Endereco>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sigla { get; set; }
        public int IdPais { get; set; }

        public virtual Pai IdPaisNavigation { get; set; }
        public virtual ICollection<Cidade> Cidades { get; set; }
        public virtual ICollection<Endereco> Enderecos { get; set; }
    }
}
