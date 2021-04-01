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
        public int PermiassaoCadastro { get; set; }
        public int PermiassaoPerfilEmpresa { get; set; }
        public int PermiassaoFaqEmpresa { get; set; }
        public int PermiassaoEstatisticas { get; set; }

        public virtual PermissaoAcesso PermiassaoCadastroNavigation { get; set; }
        public virtual PermissaoAcesso PermiassaoEstatisticasNavigation { get; set; }
        public virtual PermissaoAcesso PermiassaoFaqEmpresaNavigation { get; set; }
        public virtual PermissaoAcesso PermiassaoPerfilEmpresaNavigation { get; set; }
        public virtual ICollection<GruposAcesso> GruposAcessos { get; set; }
    }
}
