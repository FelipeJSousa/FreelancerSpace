using AutoMapper;
using FreelancerSpace.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Repositorio.Models;
using Repositorio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace FreelancerSpace.Controllers
{
    public class EmpresaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Cadastro()
        {
            return View();
        }

        public IActionResult Perfil(int? id)
        {
            EmpresaModel empr = new EmpresaModel();
            List<EnderecoModel> end = new List<EnderecoModel>();
            List<TelefoneModel> tel = new List<TelefoneModel>();
            CnaeModel cnae = new CnaeModel();
            var mapper = new Mapper(AutoMapperConfig.RegisterMappings());
            try
            {
                if (id != null)
                {
                    empr = mapper.Map<EmpresaModel>(new EmpresaRepository().get(id.Value));
                }
                else { 
                
                }
                tel = mapper.Map<List<TelefoneModel>>(new TelefoneRepository().getAll(empr.Id.Value));
                end = mapper.Map<List<EnderecoModel>>(new EnderecoRepository().getAll(empr.Id.Value));
                cnae = mapper.Map<CnaeModel>(new CnaeRepository().get(empr.Cnae));
            }
            catch (Exception ex)
            {
                throw;
            }

            @ViewBag.Telefones = tel;
            @ViewBag.Enderecos = end;
            @ViewBag.Cnae = cnae;
            return View(empr);
        }


        [HttpPost]
        public IActionResult Salvar([FromBody] JObject json)
        {
            Empresa empr = new Empresa();
            List<Endereco> ende = new List<Endereco>();
            List<Telefone> tel = new List<Telefone>();
            Usuario usuario = new Usuario();
            try
            {
                empr = json["Empresa"].ToObject<Empresa>();
                ende = json["Enderecos"].ToObject<List<Endereco>>();
                tel = json["Telefones"].ToObject<List<Telefone>>();
                usuario = json["Usuario"].ToObject<Usuario>();
                string operation = "";

                if (empr?.Id != null)
                {
                    if (usuario.Senha != "|")
                    {
                        usuario.IdGrupoAcesso = 5;
                        usuario.Senha = new UsuarioRepository().Encrypt(usuario.Senha);
                        if (!new UsuarioRepository().add(usuario))
                        {
                            throw new Exception($"Não foi possível {operation}r o endereco da Empresa!");
                        }
                    }

                    EmpresaRepository rep = new EmpresaRepository();
                    if (empr.Id != 0)
                    {
                        empr.Ativo = "S";
                        operation = "edita";
                        if (!rep.edit(empr))
                        {
                            throw new Exception($"Não foi possível {operation}r o endereco da Empresa!");
                        }
                    }
                    else
                    {
                        empr.Ativo = "S";
                        operation = "cria";
                        if (!rep.add(empr))
                        {
                            throw new Exception($"Não foi possível {operation}r o endereco da Empresa!");
                        }
                    }

                    foreach (var itel in tel)
                    {
                        itel.Ativo = "S";
                        new TelefoneRepository().delete(empr.Id, tel.Select((e) => e.Id).ToList());
                        if (itel.Id != 0 && !new TelefoneRepository().edit(itel)) 
                        {
                            throw new Exception($"Não foi possível {operation}r o endereco da Empresa!");
                        }
                        if(itel.Id == 0){
                            if (new TelefoneRepository().add(itel))
                            {
                                if (!new TelefoneRepository().SalvarTelefoneEmpresa(itel.Id, empr.Id))
                                {
                                    throw new Exception($"Não foi possível {operation}r o endereco da Empresa!");
                                }
                            }
                            else
                            {
                                throw new Exception($"Não foi possível {operation}r o endereco da Empresa!");
                            }
                        }
                    }
                    foreach (var iend in ende)
                    {
                        iend.Ativo = "S";
                        new EnderecoRepository().delete(empr.Id, ende.Select((e) => e.Id).ToList());
                        if (iend.Id != 0 && !new EnderecoRepository().edit(iend))
                        {
                            throw new Exception($"Não foi possível {operation}r o endereco da Empresa!");
                        }
                        if(iend.Id == 0)
                        {
                            if (new EnderecoRepository().add(iend)) 
                            { 
                                if(!new EnderecoRepository().SalvarEnderecoEmpresa(iend.Id, empr.Id))
                                {
                                    throw new Exception($"Não foi possível {operation}r o endereco da Empresa!");
                                }
                            }
                            else
                            {
                                throw new Exception($"Não foi possível {operation}r o endereco da Empresa!");
                            }
                        }
                    }
                    empr = rep.get(empr.Id);
                    TempData["redirectMessage"] = $"Empresa {operation}do com Sucesso!";
                }
            }
            catch (Exception ex)
            {
                return BadRequest(Json(new { success = false, responseText = ex.Message }));
            }
            return Ok(new JsonResult(empr));
        }

        public IActionResult Detalhes(int id)
        {
            EmpresaModel empr = new EmpresaModel();
            empr = new Mapper(AutoMapperConfig.RegisterMappings())
                                                .Map<EmpresaModel>(new EmpresaRepository().get(id));

            ViewBag.prodserv = new Mapper(AutoMapperConfig.RegisterMappings())
                                            .Map<List<ProdutosServicosModel>>(new ProdutosServicosRepository().getAll(empr.Id.Value));
            return View(empr);
        }

        [HttpGet]
        public IActionResult Buscar(string busca)
        {
            List<EmpresaModel> empr = new List<EmpresaModel>();
            try
            {
                empr = new Mapper(AutoMapperConfig.RegisterMappings())
                                                        .Map<List<EmpresaModel>>(new EmpresaRepository().getAll(busca)); 
                if (busca == "" || empr.Count == 0)
                {
                    if (empr.Count == 0)
                    {
                        empr = new Mapper(AutoMapperConfig.RegisterMappings())
                                                .Map<List<EmpresaModel>>(new EmpresaRepository().getAll());
                        throw new Exception();
                    }
                    empr = new Mapper(AutoMapperConfig.RegisterMappings())
                                                .Map<List<EmpresaModel>>(new EmpresaRepository().getAll());
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new JsonResult(empr));
            }
            return Ok(new JsonResult(empr));
        }

    }
}
