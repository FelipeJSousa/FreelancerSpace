using AutoMapper;
using FreelancerSpace.Models;
using Microsoft.AspNetCore.Http;
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


        public IActionResult Index(int? idEmpresa)
        {
            List<ProdutosServicosModel> prodserv = new List<ProdutosServicosModel>();
            if (idEmpresa.HasValue)
            {
                prodserv = new Mapper(AutoMapperConfig.RegisterMappings())
                                        .Map<List<ProdutosServicosModel>>(new ProdutosServicosRepository().getAll(idEmpresa.Value));
            }
            else if (HttpContext.Session.GetInt32("idGrupoAcesso") == 1)
            {
                prodserv = GetProdutosServicos();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            return View(prodserv);
        }

        //public IActionResult Index(int? id)
        //{
        //    List<ProdutosServicosModel> listprodservmodel = null;
        //    try
        //    {
        //        if (id != null)
        //        {
        //            listprodservmodel = new Mapper(AutoMapperConfig.RegisterMappings())
        //                                       .Map<List<ProdutosServicosModel>>(
        //                                           new ProdutosServicosRepository().getAllProdServ(id.Value)
        //            );
        //        }
        //        else
        //        {

        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //    ViewBag.message = TempData["redirectMessage"]?.ToString();
        //    return View(listprodservmodel);
        //}


        public IActionResult Create(int? id)
        {
            ProdutosServicosModel prodservmodel = new ProdutosServicosModel();
            var mapper = new Mapper(AutoMapperConfig.RegisterMappings());
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
            }
            catch (Exception)
            {
                throw;
            }

            return View(prodservmodel);
        }
        [HttpPost]
        public virtual JsonResult Salvar([FromBody] ProdutosServicosModel model)
        {
            string operation = "";
            var mapper = new Mapper(AutoMapperConfig.RegisterMappings());
            ProdutosServico prodserv = new ProdutosServico();
            try
            {
                if (model?.Id != null)
                {
                    prodserv = mapper.Map<ProdutosServico>(model);
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
                        prodserv.Ativo = "S";
                        operation = "cria";
                        if (!rep.add(prodserv))
                        {
                            TempData["redirectMessage"] = $"Não foi possível {operation}r o Produto/Serviço!";
                        }
                    }
                    TempData["redirectMessage"] = $"Produto/Serviço {operation}do com Sucesso!";
                }
            }
            catch (Exception ex)
            {
                TempData["redirectMessage"] = $"Não foi possível {operation}r o Produto/Serviço!";
            }
            return new JsonResult(prodserv);
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

        public JsonResult Listar(string name)
        {
            var mapper = new Mapper(AutoMapperConfig.RegisterMappings());
            List<ProdutosServicosModel> listmodel = new List<ProdutosServicosModel>();
            try
            {
                if (String.IsNullOrEmpty(name)) 
                {
                    listmodel = mapper.Map<List<ProdutosServicosModel>>(new ProdutosServicosRepository().getAllProdServ());
                }
                else
                {
                    listmodel = mapper.Map<List<ProdutosServicosModel>>(new ProdutosServicosRepository().listar(name));
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return new JsonResult(listmodel);
        }
    }
}
