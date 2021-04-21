using System;
using System.Collections.Generic;

#nullable disable

namespace Repositorio.Models
{
    public partial class FaqPergunta
    {
        public FaqPergunta()
        {
            FaqResposta = new HashSet<FaqResposta>();
        }

        public int Id { get; set; }
        public string IdEmpresa { get; set; }
        public int IdUsuario { get; set; }
        public string Pergunta { get; set; }
        public DateTime DataHorario { get; set; }
        public string Anexo { get; set; }

        public virtual Empresa IdEmpresaNavigation { get; set; }
        public virtual ICollection<FaqResposta> FaqResposta { get; set; }
    }
}
