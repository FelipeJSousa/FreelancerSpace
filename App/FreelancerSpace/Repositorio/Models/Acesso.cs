using System;
using System.Collections.Generic;

#nullable disable

namespace Repositorio.Models
{
    public partial class Acesso
    {
        public int Id { get; set; }
        public int IdGrupo { get; set; }
        public int IdFuncionalidade { get; set; }
        public int IdPermissao { get; set; }

        public virtual Funcionalidade IdFuncionalidadeNavigation { get; set; }
        public virtual GrupoAcesso IdGrupoNavigation { get; set; }
        public virtual Permissoes IdPermissaoNavigation { get; set; }
    }
}
