using AutoMapper;
using FreelancerSpace.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
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


        public IActionResult Index(int? id)
        {
            List<ProdutosServicosModel> prodserv = new List<ProdutosServicosModel>();
            if (id.HasValue)
            {
                prodserv = new Mapper(AutoMapperConfig.RegisterMappings())
                                        .Map<List<ProdutosServicosModel>>(new ProdutosServicosRepository().getAll(id.Value));
                ViewBag.idEmpresa = id;
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

        public IActionResult Create(int? id, int? idEmpresa)
        {
            ProdutosServicosModel prodservmodel = new ProdutosServicosModel();
            var mapper = new Mapper(AutoMapperConfig.RegisterMappings());
            try
            {
                if (id != 0)
                {
                    var prodserv = new ProdutosServicosRepository().get(id.Value);
                    prodservmodel = new Mapper(AutoMapperConfig.RegisterMappings()).Map<ProdutosServicosModel>(prodserv);
                    var temp = mapper.Map<List<ProdutosServicosModel>>(new ProdutosServicosRepository().
                                        getAll(idEmpresa.Value));
                    if (temp.FirstOrDefault(x=> x.Id == prodservmodel.Id)==null)
                    {
                        throw new Exception();
                    }
                    ViewBag.idempresa = idEmpresa.Value;
                }
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
            return View(prodservmodel);
        }
        [HttpPost]
        public virtual JsonResult Salvar([FromBody] JObject json)
        {
            string operation = "";
            ProdutosServicosModel model = json["produtoservico"].ToObject<ProdutosServicosModel>(); 
            int idempresa = int.Parse(json["idempresa"].ToString()); 
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
                    if (new ProdutosServicosRepository().SalvarProdServEmpresa(prodserv.Id, idempresa))
                    {
                        throw new Exception();
                    };
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
