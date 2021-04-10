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
    public class RamoAtividadeController : Controller
    {
        public IActionResult Index()
        {
            var mapper = new Mapper(AutoMapperConfig.RegisterMappings());
            List<RamoAtividade> listRamo = new RamoAtividadesRepository().getAll();
            List<RamoAtividadeModel> listRamoModel = mapper.Map<List<RamoAtividadeModel>>(listRamo);
            return View(listRamoModel);
        }
        public IActionResult Create(int? id)
        {
            RamoAtividadeModel ramoModel = new RamoAtividadeModel();
            if(id != null)
            {
                var ramo = new RamoAtividadesRepository().get(id.Value);
                ramoModel = new Mapper(AutoMapperConfig.RegisterMappings()).Map<RamoAtividadeModel>(ramo);
            }
            else
            {
                ramoModel.Id = 0;
            }

            return View(ramoModel);
        }

        public IActionResult Salvar(RamoAtividadeModel model)
        {
            string operation = "";
            var mapper = new Mapper(AutoMapperConfig.RegisterMappings());
            try
            {
                if (ModelState.IsValid)
                {
                    Repositorio.Models.RamoAtividade ramo = mapper.Map<Repositorio.Models.RamoAtividade>(model);

                    RamoAtividadesRepository rep = new RamoAtividadesRepository();
                    if(ramo.Id != 0)
                    {
                        operation = "edita";
                        rep.edit(ramo);
                    }
                    else
                    {
                        operation = "cria";
                        rep.add(ramo);
                    }

                    ViewBag.message = $"Ramo de atividade {operation}do com Sucesso!";
                }
            }
            catch (Exception ex)
            {
                ViewBag.message = $"Não foi possível {operation}r o Ramo de atividade!";
            }
            List<RamoAtividade> listRamo = new RamoAtividadesRepository().getAll();
            List<RamoAtividadeModel> listRamoModel = mapper.Map<List<RamoAtividadeModel>>(listRamo);
            return View("Index", listRamoModel);
        }

        public IActionResult Excluir(int id)
        {
            var ramo = new RamoAtividadesRepository().get(id);
            if(new RamoAtividadesRepository().delete(ramo))
            {
                ViewBag.message = $"Ramo de atividade {ramo.Nome} foi excluído!";
            }
            else
            {
                ViewBag.message = $"Não foi possível excluir o ramo de atividade {ramo.Nome}!";
            }
            var mapper = new Mapper(AutoMapperConfig.RegisterMappings());
            List<RamoAtividade> listRamo = new RamoAtividadesRepository().getAll();
            List<RamoAtividadeModel> listRamoModel = mapper.Map<List<RamoAtividadeModel>>(listRamo);
            return View("Index", listRamoModel);
        }
    }
}
