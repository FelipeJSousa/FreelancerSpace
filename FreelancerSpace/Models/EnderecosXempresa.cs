using System;
using System.Collections.Generic;

#nullable disable

namespace FreelancerSpace.Models
{
    public class EnderecosXempresaModel
    {
        public int IdEndereco { get; set; }
        public int IdEmpresa { get; set; }

        public virtual EmpresaModel IdEmpresaNavigation { get; set; }
        public virtual EnderecoModel IdEnderecoNavigation { get; set; }
    }
}
