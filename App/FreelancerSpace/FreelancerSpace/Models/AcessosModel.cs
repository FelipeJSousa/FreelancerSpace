using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FreelancerSpace.Models
{
    public class AcessosModel
    {
        public int Id { get; set; }
        public int IdGrupo { get; set; }
        public int IdFuncionalidade { get; set; }
        public int IdPermissao { get; set; }
        
        public virtual FuncionalidadesModel IdFuncionalidadeNavigation { get; set; }
        public virtual GrupoAcessoModel IdGrupoNavigation { get; set; }
        public virtual PermissoesModel IdPermissaoNavigation { get; set; }

    }
}
