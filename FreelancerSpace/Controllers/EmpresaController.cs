using FreelancerSpace.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreelancerSpace.Controllers
{
    public class EmpresaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        public JsonResult Salvar()
        {
            EmpresaModel empresa = new EmpresaModel();

            return new JsonResult(empresa);
        }


        public IActionResult Perfil()
        {
            return View();
        }
    }
}
