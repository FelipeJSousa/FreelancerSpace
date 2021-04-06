using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FreelancerSpace.Models
{
    public class RamoAtividadeModel
    {
        public RamoAtividadeModel()
        {
            ProdutosServicos = new HashSet<ProdutosServicosModel>();
        }

        [KeyAttribute]
        public int Id { get; set; }
        [Required(ErrorMessage = "Nome do ramo de atividade é obrigatório")]
        [Display(Name = "Nome Ramo de atividade")]
        public string Nome { get; set; }

        public virtual ICollection<ProdutosServicosModel> ProdutosServicos { get; set; }
    }
}
