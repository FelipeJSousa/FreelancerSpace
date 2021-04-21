using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreelancerSpace.Models
{
    public class PerfilEmpresaModel
    {
        public int Id { get; set; }
        public decimal? Likes { get; set; }
        public decimal? Visualizacoes { get; set; }
        public int IdEmpresa { get; set; }

        public virtual EmpresaModel IdEmpresaNavigation { get; set; }
    }
}
