using AutoMapper;
using FreelancerSpace.Models;
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
                }
                else
                {
                    grupoacessomodel.Id = 0;
                    acessosModel.Id = 0;
                }
                var listfuncionalidade = new FuncionalidadeRepository().getAll();
                funcionalidadesModels = mapper.Map<List<FuncionalidadesModel>>(listfuncionalidade);
                var listpermissoes = new PermissoesRepository().getAll();
                permissoesModels = mapper.Map<List<PermissoesModel>>(listpermissoes);
            }
            catch (Exception ex)
            {
                throw;
            }

            ViewBag.listFuncionalidades = funcionalidadesModels;
            ViewBag.listPermissoes = permissoesModels;
            return View(grupoacessomodel);
        }

        [HttpPost]
        public JsonResult Salvar([FromBody] JObject json)
        {
            var mapper = new Mapper(AutoMapperConfig.RegisterMappings());
            List<Acesso> acessos = new List<Acesso>();
            GrupoAcesso grupo = new GrupoAcesso();
            try
            {
                grupo = json["GrupoAcesso"].ToObject<GrupoAcesso>();
                acessos = json["Acessos"].ToObject<List<Acesso>>();
                if (grupo.Id > 0)
                {
                    if(new GrupoAcessoRepository().edit(grupo))
                    {
                        var listacessos = new AcessoRepository().getAll(x => x.IdGrupo == grupo.Id && x.Ativo.Equals("S"));
                        foreach (var item in listacessos)
                        {
                            item.Ativo = "N";
                            if(!new AcessoRepository().edit(item))
                            {
                                throw new Exception("Falha ao editar acessos.");
                            }
                        }
                        foreach (var item in acessos)
                        {
                            item.IdGrupo = grupo.Id;
                            if (!new AcessoRepository().add(item))
                            {
                                throw new Exception("Falha ao criar acesso.");
                            };
                        }
                    }
                    else
                    {
                        throw new Exception("Falha ao editar grupo de acesso.");
                    }
                }
                else
                {
                    if (new GrupoAcessoRepository().add(grupo))
                    {
                        foreach (var item in acessos)
                        {
                            item.IdGrupo = grupo.Id;
                            if (!new AcessoRepository().add(item))
                            {
                                throw new Exception("Falha ao criar acesso.");
                            };
                        }
                    }
                    else
                    {
                        throw new Exception("Falha ao criar grupo de acesso.");
                    };
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, responseText = ex.Message });
            }

            return new JsonResult(acessos);
        }
    }
}
