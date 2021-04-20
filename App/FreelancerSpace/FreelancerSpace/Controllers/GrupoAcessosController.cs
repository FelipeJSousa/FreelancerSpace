using AutoMapper;
using FreelancerSpace.Models;
using Microsoft.AspNetCore.Mvc;
using Repositorio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreelancerSpace.Controllers
{
    public class GrupoAcessosController : Controller
    {
        public IActionResult Index()
        {
            List<GrupoAcessoModel> list = new Mapper(AutoMapperConfig.
                                                    RegisterMappings())
                                                    .Map<List<GrupoAcessoModel>>(new GrupoAcessoRepository().getAll());
            return View(list);
        }

        public IActionResult Create(int? id)
        {
            GrupoAcessoModel grupoacessomodel = new GrupoAcessoModel();
            var mapper = new Mapper(AutoMapperConfig.RegisterMappings());
            List<AcessosModel> acessos = null;
            try
            {
                if (id != null)
                {
                    var grupacesso = new GrupoAcessoRepository().get(id.Value);
                    grupoacessomodel = new Mapper(AutoMapperConfig.RegisterMappings()).Map<GrupoAcessoModel>(grupacesso);
                }
                else
                {
                    grupoacessomodel.Id = 0;
                }
            }
            catch (Exception)
            {
                throw;
            }

            return View(grupoacessomodel);
        }
    }
}
