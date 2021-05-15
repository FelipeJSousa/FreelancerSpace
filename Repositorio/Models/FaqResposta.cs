using System;
using System.Collections.Generic;

#nullable disable

namespace Repositorio.Models
{
    public partial class FaqResposta
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int IdPergunta { get; set; }
        public string Resposta { get; set; }
        public DateTime DataHorario { get; set; }
        public string Anexo { get; set; }

        public virtual FaqPergunta IdPerguntaNavigation { get; set; }
    }
}
