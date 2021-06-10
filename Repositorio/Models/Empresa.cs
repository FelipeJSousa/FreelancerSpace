using System;
using System.Collections.Generic;

#nullable disable

namespace Repositorio.Models
{
    public partial class Empresa
    {
        public Empresa()
        {
            EnderecosXempresas = new HashSet<EnderecosXempresa>();
            FaqPergunta = new HashSet<FaqPergunta>();
            Funcionarios = new HashSet<Funcionario>();
            HorarioAtendimentoXempresas = new HashSet<HorarioAtendimentoXempresa>();
            NotaAvaliacaos = new HashSet<NotaAvaliacao>();
            PerfilEmpresas = new HashSet<PerfilEmpresa>();
            ProdutosServicosXempresas = new HashSet<ProdutosServicosXempresa>();
            TelefoneXempresas = new HashSet<TelefoneXempresa>();
        }

        public int Id { get; set; }
        public string Cnae { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string Cnpj { get; set; }
        public string Descricao { get; set; }
        public string ImagemDestaque { get; set; }
        public string Ativo { get; set; }
        public string Username { get; set; }

        public virtual Usuario UsernameNavigation { get; set; }
        public virtual ICollection<EnderecosXempresa> EnderecosXempresas { get; set; }
        public virtual ICollection<FaqPergunta> FaqPergunta { get; set; }
        public virtual ICollection<Funcionario> Funcionarios { get; set; }
        public virtual ICollection<HorarioAtendimentoXempresa> HorarioAtendimentoXempresas { get; set; }
        public virtual ICollection<NotaAvaliacao> NotaAvaliacaos { get; set; }
        public virtual ICollection<PerfilEmpresa> PerfilEmpresas { get; set; }
        public virtual ICollection<ProdutosServicosXempresa> ProdutosServicosXempresas { get; set; }
        public virtual ICollection<TelefoneXempresa> TelefoneXempresas { get; set; }
    }
}
