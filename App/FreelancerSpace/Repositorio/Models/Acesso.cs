using System;
using System.Collections.Generic;

#nullable disable

namespace Repositorio.Models
{
    public partial class Acesso
    {
        public Acesso()
        {
            GruposAcessos = new HashSet<GruposAcesso>();
        }

        public int Id { get; set; }
        public int PermissaoCadastro { get; set; }
        public int PermissaoPerfilEmpresa { get; set; }
        public int PermissaoFaqEmpresa { get; set; }
        public int PermissaoEstatisticas { get; set; }

        public virtual PermissaoAcesso PermissaoCadastroNavigation { get; set; }
        public virtual PermissaoAcesso PermissaoEstatisticasNavigation { get; set; }
        public virtual PermissaoAcesso PermissaoFaqEmpresaNavigation { get; set; }
        public virtual PermissaoAcesso PermissaoPerfilEmpresaNavigation { get; set; }
        public virtual ICollection<GruposAcesso> GruposAcessos { get; set; }
    }
}
