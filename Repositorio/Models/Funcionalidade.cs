using System;
using System.Collections.Generic;

#nullable disable

namespace Repositorio.Models
{
    public partial class Funcionalidade
    {
        public Funcionalidade()
        {
            Acessos = new HashSet<Acesso>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Ativo { get; set; }
        public string Caminho { get; set; }

        public virtual ICollection<Acesso> Acessos { get; set; }
    }
}
