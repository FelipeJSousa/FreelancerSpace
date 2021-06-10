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
        [HttpPost]
        public JsonResult Salvar([FromBody] JObject json)
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
                    usuario.IdGrupoAcesso = 1;
                    if (!new UsuarioRepository().add(usuario))
                    {
                        throw new Exception($"Não foi possível {operation}r o endereco da Empresa!");
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
                    foreach (var iend in ende)
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
                    empr = rep.get(empr.Id);
                    TempData["redirectMessage"] = $"Empresa {operation}do com Sucesso!";
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, responseText = ex.Message });
            }
            return new JsonResult(empr);
        }


        public IActionResult Perfil()
        {
            return View();
        }
    }
}
