using AutoMapper;
using FreelancerSpace.Models;
using Microsoft.AspNetCore.Mvc;
using Repositorio.Models;
using Repositorio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreelancerSpace.Controllers
{
    public class CnaeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult BuscarAtividade(string nome)
        {
            List<Cnae> lista = new List<Cnae>();
            if (!String.IsNullOrEmpty(nome))
            {
                lista = new CnaeRepository().getTopAtividades(nome);
                var mapper = new Mapper(AutoMapperConfig.RegisterMappings());
                List<CnaeModel> listap = mapper.Map<List<CnaeModel>>(lista);
            }
            return new JsonResult(lista);
        }
    }
}
