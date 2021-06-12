using AutoMapper;
using FreelancerSpace.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Repositorio.Repositorios;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FreelancerSpace.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.nome = HttpContext.Session.GetString("nome");
            ViewBag.grupoacesso = HttpContext.Session.GetInt32("idGrupoAcesso");
            ViewBag.username = HttpContext.Session.GetString("username");
            if (HttpContext.Session.GetInt32("idPessoa").HasValue) {
                ViewBag.idPessoa = HttpContext.Session.GetInt32("idPessoa");
                ViewBag.sobrenome = HttpContext.Session.GetString("sobrenome");
            };
            if (HttpContext.Session.GetInt32("idEmpresa").HasValue)
            {
                ViewBag.idEmpresa = HttpContext.Session.GetInt32("idEmpresa");
            }

            List<EmpresaModel> empr = new List<EmpresaModel>();
            empr = new Mapper(AutoMapperConfig.RegisterMappings()).Map<List<EmpresaModel>>(new EmpresaRepository().getAll());
            ViewBag.empresa = empr;
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
