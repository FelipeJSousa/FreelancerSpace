using System;
using System.Collections.Generic;

#nullable disable

namespace Repositorio.Models
{
    public partial class Telefone
    {
        public Telefone()
        {
            TelefoneXempresas = new HashSet<TelefoneXempresa>();
            TelefoneXpessoas = new HashSet<TelefoneXpessoa>();
        }

        public int Id { get; set; }
        public string Numero { get; set; }

        public virtual ICollection<TelefoneXempresa> TelefoneXempresas { get; set; }
        public virtual ICollection<TelefoneXpessoa> TelefoneXpessoas { get; set; }
    }
}
