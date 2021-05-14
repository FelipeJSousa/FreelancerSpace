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
    public class FuncionalidadesController : Controller
    {
        public IActionResult Index()
        {
            List<FuncionalidadesModel> list = new List<FuncionalidadesModel>();
            try
            {
                list = new Mapper(AutoMapperConfig.RegisterMappings()).Map<List<FuncionalidadesModel>>(new FuncionalidadeRepository().getAll());
            }
            catch (Exception ex)
            {

                throw;
            }
            ViewBag.message = TempData["redirectMessage"]?.ToString();
            return View(list);
        }
        public IActionResult Create(int? id)
        {
            FuncionalidadesModel funcionModel = new FuncionalidadesModel();
            var mapper = new Mapper(AutoMapperConfig.RegisterMappings());
            try
            {
                if (id != null)
                {
                    var funcion = new FuncionalidadeRepository().get(id.Value);
                    funcionModel = new Mapper(AutoMapperConfig.RegisterMappings()).Map<FuncionalidadesModel>(funcion);
                }
                else
                {
                    funcionModel.Id = 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return View(funcionModel);
        }
        public IActionResult Excluir(int id)
        {
            var funcion = new FuncionalidadeRepository().get(id);
            funcion.Ativo = "N";
            if (new FuncionalidadeRepository().edit(funcion))
            {
                TempData["redirectMessage"] = $"Funcionalidade {funcion.Nome} foi excluída!";
            }
            else
            {
                TempData["redirectMessage"] = $"Não foi possível excluir a funcionalidade {funcion.Nome}!";
            }

            return RedirectToAction("Index");
        }

        public IActionResult Salvar(FuncionalidadesModel model)
        {
            string operation = "";
            var mapper = new Mapper(AutoMapperConfig.RegisterMappings());
            try
            {
                if (ModelState.IsValid)
                {
                    Funcionalidade funcion = mapper.Map<Funcionalidade>(model);

                    FuncionalidadeRepository rep = new FuncionalidadeRepository();
                    if (funcion.Id != 0)
                    {
                        funcion.Ativo = "S";
                        operation = "edita";
                        if (!rep.edit(funcion))
                        {
                            TempData["redirectMessage"] = $"Não foi possível {operation}r a funcionalidade!";
                        }
                    }
                    else
                    {
                        operation = "cria";
                        if (!rep.add(funcion))
                        {
                            TempData["redirectMessage"] = $"Não foi possível {operation}r a funcionalidade!";
                        }
                    }

                    TempData["redirectMessage"] = $"Funcionalidade {operation}da com Sucesso!";
                }
            }
            catch (Exception ex)
            {
                TempData["redirectMessage"] = $"Não foi possível {operation}r a funcionalidade!";
            }

            return RedirectToAction("Index");
        }
    }
}
