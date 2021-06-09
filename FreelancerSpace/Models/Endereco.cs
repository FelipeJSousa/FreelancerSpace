using System;
using System.Collections.Generic;

#nullable disable

namespace FreelancerSpace.Models
{
    public class EnderecoModel
    {
        public int? Id { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
        public string Ativo { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
        public string Complemento { get; set; }
    }
}
