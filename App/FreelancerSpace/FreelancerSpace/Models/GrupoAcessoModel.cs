using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FreelancerSpace.Models
{
    public class GrupoAcessoModel
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "Nome é obrigatório")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Descrição é obrigatório")]
        [Display(Name = "Descrição")]
        [StringLength(maximumLength: 100, ErrorMessage = "Informar no máximo 100 caracteres")]
        public string Descricao { get; set; }
        public int IdAcessos { get; set; }

        public virtual AcessosModel IdAcessosNavigation { get; set; }
        public virtual ICollection<UsuariosModel> Usuarios { get; set; }
    }
}
