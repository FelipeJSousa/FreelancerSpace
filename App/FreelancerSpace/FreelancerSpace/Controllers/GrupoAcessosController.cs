using AutoMapper;
using FreelancerSpace.Models;
using Microsoft.AspNetCore.Mvc;
using Repositorio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreelancerSpace.Controllers
{
    public class GrupoAcessosController : Controller
    {
        public IActionResult Index()
        {
            List<GrupoAcessoModel> list = new Mapper(AutoMapperConfig.
                                                    RegisterMappings())
                                                    .Map<List<GrupoAcessoModel>>(new GrupoAcessoRepository().getAll());
            return View(list);
        }

        public IActionResult Create(int? id)
        {
            GrupoAcessoModel grupoacessomodel = new GrupoAcessoModel();
            AcessosModel acessosModel = new AcessosModel();
            List<FuncionalidadesModel> funcionalidadesModels = new List<FuncionalidadesModel>();
            List<PermissoesModel> permissoesModels = new List<PermissoesModel>();
            var mapper = new Mapper(AutoMapperConfig.RegisterMappings());
            try
            {
                if (id != null)
                {
                    var grupacesso = new GrupoAcessoRepository().get(id.Value);
                    grupoacessomodel = mapper.Map<GrupoAcessoModel>(grupacesso);
                    var acesso = new AcessoRepository().get(x => x.IdGrupo.Equals(grupoacessomodel.Id) && x.Ativo.Equals("S"));
                    acessosModel = mapper.Map<AcessosModel>(acesso);
                    var listfuncionalidade = new FuncionalidadeRepository().getAll();
                    funcionalidadesModels = mapper.Map<List<FuncionalidadesModel>>(listfuncionalidade);
                    var listpermissoes = new PermissoesRepository().getAll();
                    permissoesModels = mapper.Map<List<PermissoesModel>>(listpermissoes);
                }
                else
                {
                    grupoacessomodel.Id = 0;
                    acessosModel.Id = 0;
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            ViewBag.listFuncionalidades = funcionalidadesModels;
            ViewBag.listPermissoes = permissoesModels;
            return View(acessosModel);
        }
    }
}
