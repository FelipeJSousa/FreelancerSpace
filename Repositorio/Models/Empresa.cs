using System;
using System.Collections.Generic;

#nullable disable

namespace Repositorio.Models
{
    public partial class Empresa
    {
        public Empresa()
        {
            FaqPergunta = new HashSet<FaqPergunta>();
            Funcionarios = new HashSet<Funcionario>();
            NotaAvaliacaos = new HashSet<NotaAvaliacao>();
            PerfilEmpresas = new HashSet<PerfilEmpresa>();
        }

        public string Id { get; set; }
        public string Cnae { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string Cnpj { get; set; }
        public string Descricao { get; set; }
        public string ImagemDestaque { get; set; }
        public string Ativo { get; set; }

        public virtual ICollection<FaqPergunta> FaqPergunta { get; set; }
        public virtual ICollection<Funcionario> Funcionarios { get; set; }
        public virtual ICollection<NotaAvaliacao> NotaAvaliacaos { get; set; }
        public virtual ICollection<PerfilEmpresa> PerfilEmpresas { get; set; }
    }
}
