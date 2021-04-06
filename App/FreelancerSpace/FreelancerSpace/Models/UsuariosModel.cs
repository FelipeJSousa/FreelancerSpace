using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FreelancerSpace.Models
{
    public class UsuariosModel
    {
        [KeyAttribute]
        [Required(ErrorMessage = "Usuário é obrigatório")]
        [Display(Name = "Usuário")]
        public string username { get; set; }

        [Required(ErrorMessage = "Senha é obrigatória")]
        [Display(Name = "Senha")]
        [StringLength(maximumLength: 50, ErrorMessage = "Informar no máximo 50 caracteres")]
        public string senha { get; set; }
    }
}
