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
    public class EmpresaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Cadastro()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Salvar([FromBody] EmpresaModel empresaModel)
        {
            var mapper = new Mapper(AutoMapperConfig.RegisterMappings());
            Empresa empresa = new Empresa();
            try
            {
                if (empresaModel?.Id != null)
                {

                    empresa = mapper.Map<Empresa>(empresaModel);
                    string operation = "";

                    EmpresaRepository rep = new EmpresaRepository();
                    if (empresa.Id != 0)
                    {
                        empresa.Ativo = "S";
                        operation = "edita";
                        if (!rep.edit(empresa))
                        {
                            TempData["redirectMessage"] = $"Não foi possível {operation}r a Empresa!";
                        }
                    }
                    else
                    {
                        empresa.Ativo = "S";
                        operation = "cria";
                        if (!rep.add(empresa))
                        {
                            TempData["redirectMessage"] = $"Não foi possível {operation}r a Empresa!";
                        }
                    }

                    TempData["redirectMessage"] = $"Empresa {operation}do com Sucesso!";
                }
            }
            catch (Exception ex)
            {

            }
            return new JsonResult(empresa);
        }


        public IActionResult Perfil()
        {
            return View();
        }
    }
}
