using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreelancerSpace.Models
{
    public class FaqPerguntaModel
    {
        public int Id { get; set; }
        public int IdEmpresa { get; set; }
        public int IdUsuario { get; set; }
        public string Pergunta { get; set; }
        public DateTime DataHorario { get; set; }
        public string Anexo { get; set; }

        public virtual EmpresaModel IdEmpresaNavigation { get; set; }
        public virtual ICollection<FaqResposta> FaqResposta { get; set; }
    }
}
