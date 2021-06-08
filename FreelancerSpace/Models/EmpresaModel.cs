using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreelancerSpace.Models
{
    public class EmpresaModel
    {
        public int Id { get; set; }
        public int Cnae { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string Cnpj { get; set; }
        public string Descricao { get; set; }
        public string ImagemDestaque { get; set; }

        public virtual ICollection<FaqPerguntaModel> FaqPergunta { get; set; }
        public virtual ICollection<FuncionariosModel> Funcionarios { get; set; }
        public virtual ICollection<NotaAvaliacaoModel> NotaAvaliacaos { get; set; }
        public virtual ICollection<PerfilEmpresaModel> PerfilEmpresas { get; set; }
    }
}
