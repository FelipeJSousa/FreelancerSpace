using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FreelancerSpace.Models
{
    public class PermissaoAcessoModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Permissão Ler é obrigatório")]
        [Display(Name = "Ler")]
        public string Ler { get; set; }
        [Required(ErrorMessage = "Permissão Editar é obrigatório")]
        [Display(Name = "Editar")]
        public string Editar { get; set; }
        [Required(ErrorMessage = "Permissão Excluir é obrigatório")]
        [Display(Name = "Excluir")]
        public string Excluir { get; set; }
        [Required(ErrorMessage = "Permissão Criar é obrigatório")]
        [Display(Name = "Criar")]
        public string Criar { get; set; }

        public virtual ICollection<AcessosModel> AcessoPermissaoCadastroNavigations { get; set; }
        public virtual ICollection<AcessosModel> AcessoPermissaoEstatisticasNavigations { get; set; }
        public virtual ICollection<AcessosModel> AcessoPermissaoFaqEmpresaNavigations { get; set; }
        public virtual ICollection<AcessosModel> AcessoPermissaoPerfilEmpresaNavigations { get; set; }
    }
}
