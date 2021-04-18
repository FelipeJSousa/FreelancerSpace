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
        [Required(ErrorMessage = "Permissão de Cadastro é obrigatório")]
        [Display(Name = "Permissão de Cadastro")]
        public int PermissaoCadastro { get; set; }
        [Required(ErrorMessage = "Permissão de Perfil Empresa é obrigatório")]
        [Display(Name = "Permissão de Perfil Empresa")]
        public int PermissaoPerfilEmpresa { get; set; }
        [Required(ErrorMessage = "Permissão de Faq é obrigatório")]
        [Display(Name = "Permissão de Faq")]
        public int PermissaoFaqEmpresa { get; set; }
        [Required(ErrorMessage = "Permissão de Estatisticas da Empresa é obrigatório")]
        [Display(Name = "Permissão de Estatisticas")]
        public int PermissaoEstatisticas { get; set; }

        public virtual PermissaoAcessoModel PermissaoCadastroNavigation { get; set; }
        public virtual PermissaoAcessoModel PermissaoEstatisticasNavigation { get; set; }
        public virtual PermissaoAcessoModel PermissaoFaqEmpresaNavigation { get; set; }
        public virtual PermissaoAcessoModel PermissaoPerfilEmpresaNavigation { get; set; }
        public virtual ICollection<GrupoAcessoModel> GruposAcessos { get; set; }
    }
}
