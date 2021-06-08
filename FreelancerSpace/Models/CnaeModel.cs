﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreelancerSpace.Models
{
    public class CnaeModel
    {
        public int Id { get; set; }
        public string CodSecao { get; set; }
        public string DescSecao { get; set; }
        public string CodDivisao { get; set; }
        public string DescDivisao { get; set; }
        public string CodGrupo { get; set; }
        public string DescGrupo { get; set; }
        public string CodClasse { get; set; }
        public string DescClasse { get; set; }
        public string CodSubclasse { get; set; }
        public string DescSubclasse { get; set; }

        public virtual ICollection<ProdutosServicosModel> ProdutosServicos { get; set; }
    }
}