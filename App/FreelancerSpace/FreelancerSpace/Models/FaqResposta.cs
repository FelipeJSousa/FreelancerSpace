using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreelancerSpace.Models
{
    public class FaqResposta
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int IdPergunta { get; set; }
        public string Resposta { get; set; }
        public DateTime DataHorario { get; set; }
        public string Anexo { get; set; }

        public virtual FaqPerguntaModel IdPerguntaNavigation { get; set; }
    }
}
