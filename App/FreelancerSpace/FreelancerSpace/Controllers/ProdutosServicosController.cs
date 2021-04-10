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
        private List<ProdutosServicosModel> RelacionaProdsXRamos (List<ProdutosServicosModel> listservprod)
        {
            try
            {
                var listramo = new RamoAtividadesRepository().getAll();
                List<RamoAtividadeModel> listramomodel = null;
                listramomodel = new Mapper(AutoMapperConfig.RegisterMappings()).Map<List<RamoAtividadeModel>>(listramo);
                foreach (var item in listservprod)
                {
                    item.IdRamoAtividadeNavigation = listramomodel.FirstOrDefault(x => x.Id == item.IdRamoAtividade);
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return listservprod;
        }

        private List<ProdutosServicosModel> GetProdutosServicos()
        {
            List<ProdutosServicosModel> listprodservmodel = null;
            try
            {
                listprodservmodel = new Mapper(
                        AutoMapperConfig.RegisterMappings()
                    ).Map<List<ProdutosServicosModel>>(
                        new ProdutosServicosRepository().getAll()
                    );

                var listramo = new RamoAtividadesRepository().getAll();
                List<RamoAtividadeModel> listramomodel = null;
                listramomodel = new Mapper(AutoMapperConfig.RegisterMappings()).Map<List<RamoAtividadeModel>>(listramo);
                listprodservmodel = RelacionaProdsXRamos(listprodservmodel);
                ViewBag.listRamoAtividade = listramomodel;
            }
            catch (Exception ex)
            {
                throw;
            }

            return listprodservmodel;
        }


        public IActionResult Index()
         {
            return View(GetProdutosServicos());
        }


        public IActionResult Create()
        {
            var mapper = new Mapper(AutoMapperConfig.RegisterMappings());
            List<RamoAtividadeModel> listmodel = null;
            try
            {
                var list = new RamoAtividadesRepository().getAll();
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
            return View("Index", GetProdutosServicos());
        }

        public IActionResult Excluir(int id)
        {
            var prodserv = new ProdutosServicosRepository().get(id);
            if (new ProdutosServicosRepository().delete(prodserv))
            {
                ViewBag.message = $"Serviço/Produto {prodserv.Nome} foi excluído!";
            }
            else
            {
                ViewBag.message = $"Não foi possível excluir o serviço/produto {prodserv.Nome}!";
            }
            
            return View("Index", GetProdutosServicos());
        }
    }
}
