using System;
using System.Collections.Generic;

#nullable disable

namespace Repositorio.Models
{
    public partial class PermissaoAcesso
    {
        public PermissaoAcesso()
        {
            AcessoPermiassaoCadastroNavigations = new HashSet<Acesso>();
            AcessoPermiassaoEstatisticasNavigations = new HashSet<Acesso>();
            AcessoPermiassaoFaqEmpresaNavigations = new HashSet<Acesso>();
            AcessoPermiassaoPerfilEmpresaNavigations = new HashSet<Acesso>();
        }

        public int Id { get; set; }
        public string Ler { get; set; }
        public string Editar { get; set; }
        public string Excluir { get; set; }
        public string Criar { get; set; }

        public virtual ICollection<Acesso> AcessoPermiassaoCadastroNavigations { get; set; }
        public virtual ICollection<Acesso> AcessoPermiassaoEstatisticasNavigations { get; set; }
        public virtual ICollection<Acesso> AcessoPermiassaoFaqEmpresaNavigations { get; set; }
        public virtual ICollection<Acesso> AcessoPermiassaoPerfilEmpresaNavigations { get; set; }
    }
}
