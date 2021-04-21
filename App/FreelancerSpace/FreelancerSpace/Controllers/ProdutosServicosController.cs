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
        private List<ProdutosServicosModel> GetProdutosServicos()
        {
            List<ProdutosServicosModel> listprodservmodel = null;
            try
            {
                listprodservmodel = new Mapper(AutoMapperConfig.RegisterMappings())
                                                .Map<List<ProdutosServicosModel>>(
                                                    new ProdutosServicosRepository().getAllProdServ()
                );
            }
            catch (Exception ex)
            {
                throw;
            }

            return listprodservmodel;
        }


        public IActionResult Index()
        {
            ViewBag.message = TempData["redirectMessage"]?.ToString();
            return View(GetProdutosServicos());
        }


        public IActionResult Create(int? id)
        {
            ProdutosServicosModel prodservmodel = new ProdutosServicosModel();
            var mapper = new Mapper(AutoMapperConfig.RegisterMappings());
            List<RamoAtividadeModel> listmodel = null;
            try
            {
                if (id != null)
                {
                    var prodserv = new ProdutosServicosRepository().get(id.Value);
                    prodservmodel = new Mapper(AutoMapperConfig.RegisterMappings()).Map<ProdutosServicosModel>(prodserv);
                }
                else
                {
                    prodservmodel.Id = 0;
                }
                var list = new RamoAtividadesRepository().getAll();
                listmodel = mapper.Map<List<RamoAtividadeModel>>(list);
            }
            catch (Exception)
            {
                throw;
            }

            ViewBag.listRamoAtividade = listmodel;

            return View(prodservmodel);
        }

        public IActionResult Salvar(ProdutosServicosModel model)
        {
            string operation = "";
            var mapper = new Mapper(AutoMapperConfig.RegisterMappings());
            try
            {
                if (ModelState.IsValid)
                {
                    ProdutosServico prodserv = mapper.Map<ProdutosServico>(model);

                    ProdutosServicosRepository rep = new ProdutosServicosRepository();
                    if (prodserv.Id != 0)
                    {
                        prodserv.Ativo = "S";
                        operation = "edita";
                        if (!rep.edit(prodserv))
                        {
                            TempData["redirectMessage"] = $"Não foi possível {operation}r o Produto/Serviço!";
                        }
                    }
                    else
                    {
                        operation = "cria";
                        if (!rep.add(prodserv))
                        {
                            TempData["redirectMessage"] = $"Não foi possível {operation}r o Produto/Serviço!";
                        }
                    }

                    TempData["redirectMessage"] = $"Ramo de atividade {operation}do com Sucesso!";
                }
            }
            catch (Exception ex)
            {
                TempData["redirectMessage"] = $"Não foi possível {operation}r o Produto/Serviço!";
            }
            return RedirectToAction("Index");
        }

        public IActionResult Excluir(int id)
        {
            var prodserv = new ProdutosServicosRepository().get(id);
            prodserv.Ativo = "N";
            if (new ProdutosServicosRepository().edit(prodserv))
            {
                TempData["redirectMessage"] = $"O produto/servico {prodserv.Nome} foi excluído!";
            }
            else
            {
                TempData["redirectMessage"] = $"Não foi possível excluir o produto/servico {prodserv.Nome}!";
            }

            return RedirectToAction("Index");
        }
    }
}
