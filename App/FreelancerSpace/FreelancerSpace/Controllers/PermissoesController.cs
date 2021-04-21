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
    public class PermissoesController : Controller
    {
        public IActionResult Index()
        {
            List<PermissoesModel> list = new List<PermissoesModel>();

            try
            {
                var permissoes = new PermissoesRepository().getAll();
                list = new Mapper(AutoMapperConfig.RegisterMappings()).Map<List<PermissoesModel>>(permissoes);
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
            PermissoesModel permissoesModel = new PermissoesModel();
            try
            {
                if (id != null)
                {
                    var permissoes = new PermissoesRepository().get(id.Value);
                    permissoesModel = new Mapper(AutoMapperConfig.RegisterMappings()).Map<PermissoesModel>(permissoes);
                }
                else
                {
                    permissoesModel.Id = 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return View(permissoesModel);
        }

        public IActionResult Excluir(int id)
        {
            var permissoes = new PermissoesRepository().get(id);
            permissoes.Ativo = "N";
            if (new PermissoesRepository().edit(permissoes))
            {
                TempData["redirectMessage"] = $"Permissão {permissoes.Nome} foi excluída!";
            }
            else
            {
                TempData["redirectMessage"] = $"Não foi possível excluir a permissão {permissoes.Nome}!";
            }

            return RedirectToAction("Index");
        }

        public IActionResult Salvar(PermissoesModel model)
        {
            string operation = "";
            var mapper = new Mapper(AutoMapperConfig.RegisterMappings());
            try
            {
                if (ModelState.IsValid)
                {
                    Permissoes permissao = mapper.Map<Permissoes>(model);

                    PermissoesRepository rep = new PermissoesRepository();
                    if (permissao.Id != 0)
                    {
                        permissao.Ativo = "S";
                        operation = "edita";
                        if (!rep.edit(permissao))
                        {
                            TempData["redirectMessage"] = $"Não foi possível {operation}r a permissão!";
                        }
                    }
                    else
                    {
                        operation = "cria";
                        if (!rep.add(permissao))
                        {
                            TempData["redirectMessage"] = $"Não foi possível {operation}r a permissão!";
                        }
                    }

                    TempData["redirectMessage"] = $"Permissão {operation}da com Sucesso!";
                }
            }
            catch (Exception ex)
            {
                TempData["redirectMessage"] = $"Não foi possível {operation}r a permissão!";
            }

            return RedirectToAction("Index");
        }
    }
}
