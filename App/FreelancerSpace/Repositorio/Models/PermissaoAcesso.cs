using System;
using System.Collections.Generic;

#nullable disable

namespace Repositorio.Models
{
    public partial class PermissaoAcesso
    {
        public PermissaoAcesso()
        {
            AcessoPermissaoCadastroNavigations = new HashSet<Acesso>();
            AcessoPermissaoEstatisticasNavigations = new HashSet<Acesso>();
            AcessoPermissaoFaqEmpresaNavigations = new HashSet<Acesso>();
            AcessoPermissaoPerfilEmpresaNavigations = new HashSet<Acesso>();
        }

        public int Id { get; set; }
        public string Ler { get; set; }
        public string Editar { get; set; }
        public string Excluir { get; set; }
        public string Criar { get; set; }

        public virtual ICollection<Acesso> AcessoPermissaoCadastroNavigations { get; set; }
        public virtual ICollection<Acesso> AcessoPermissaoEstatisticasNavigations { get; set; }
        public virtual ICollection<Acesso> AcessoPermissaoFaqEmpresaNavigations { get; set; }
        public virtual ICollection<Acesso> AcessoPermissaoPerfilEmpresaNavigations { get; set; }
    }
}
