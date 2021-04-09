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
        public IActionResult Index()
        {
            var list = new ProdutosServicosRepository().getAll();
            var mapper = new Mapper(AutoMapperConfig.RegisterMappings());
            List<ProdutosServicosModel> listmodel = mapper.Map<List<ProdutosServicosModel>>(list);


            return View(listmodel);
        }


        public IActionResult Create()
        {
            var mapper = new Mapper(AutoMapperConfig.RegisterMappings());
            List<RamoAtividadeModel> listmodel = null;
            try
            {
                var list = new ProdutoServicosRepository().getAll();
                listmodel = mapper.Map<List<RamoAtividadeModel>>(list);
            }
            catch (Exception)
            {
                throw;
            }



            ViewBag.listRamoAtividade = listmodel;

            return View();
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
                        operation = "edita";
                        rep.edit(prodserv);
                    }
                    else
                    {
                        operation = "cria";
                        rep.add(prodserv);
                    }

                    ViewBag.message = $"Ramo de atividade {operation}do com Sucesso!";
                }
            }
            catch (Exception ex)
            {
                ViewBag.message = $"Não foi possível {operation}r o Produto/Serviço!";
            }
            List<ProdutosServico> listprodserv = new ProdutosServicosRepository().getAll();
            List<ProdutosServicosModel> listprodservmodel = mapper.Map<List<ProdutosServicosModel>>(listprodserv);
            return View("Index", listprodservmodel);
        }

        public IActionResult Excluir(int id)
        {
            var prodserv = new ProdutoServicosRepository().get(id);
            if (new ProdutoServicosRepository().delete(prodserv))
            {
                ViewBag.message = $"Ramo de atividade {prodserv.Nome} foi excluído!";
            }
            else
            {
                ViewBag.message = $"Não foi possível excluir o ramo de atividade {prodserv.Nome}!";
            }
            var mapper = new Mapper(AutoMapperConfig.RegisterMappings());
            List<RamoAtividade> listprodserv = new ProdutoServicosRepository().getAll();
            List<RamoAtividadeModel> listprodservmodel = mapper.Map<List<RamoAtividadeModel>>(listprodserv);
            return View("Index", listprodservmodel);
        }
    }
}
