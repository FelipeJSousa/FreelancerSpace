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
    public class ProdutosServicosController : Controller
    {
        public IActionResult Create()
        {
            var mapper = new Mapper(AutoMapperConfig.RegisterMappings());
            List<RamoAtividadeModel> listmodel = null;
            try
            {
                var list = new RamoAtividadeRepository().getAll();
                listmodel = mapper.Map<List<RamoAtividadeModel>>(list);
            }
            catch (Exception)
            {

                throw;
            }



            ViewBag.listRamoAtividade = listmodel;

            return View();
        }
    }
}
