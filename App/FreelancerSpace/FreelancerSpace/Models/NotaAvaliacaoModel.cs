using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreelancerSpace.Models
{
    public class NotaAvaliacaoModel
    {
        public int Id { get; set; }
        public int IdEmpresa { get; set; }
        public decimal NotaAvaliacao1 { get; set; }
        public DateTime DataAvaliacao { get; set; }

        public virtual EmpresaModel IdEmpresaNavigation { get; set; }
    }
}
