using AutoMapper;
using FreelancerSpace.Models;
using Microsoft.AspNetCore.Mvc;
using Repositorio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Repositorio.Repositorios;
using Microsoft.AspNetCore.Http;

namespace FreelancerSpace.Controllers
{
    public class UsuariosController : Controller
    {
        public IActionResult Login()
        {
            ViewBag.message = TempData["redirectMessage"]?.ToString();
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("Login");
        }

        public IActionResult ValidarLogin(string txtusername, string txtsenha)
        {
            Usuario user = new Usuario();
            try
            {
                user = new UsuarioRepository().validarLogin(txtusername, txtsenha);
                if (user != null)
                {
                    var pes = new PessoaRepository().get(user);
                    if (pes != null)
                    {
                        HttpContext.Session.SetInt32("idPessoa", pes.Id);
                        HttpContext.Session.SetString("nome", pes.Nome);
                        HttpContext.Session.SetString("sobrenome", pes.Sobrenome);
                        HttpContext.Session.SetInt32("idGrupoAcesso", user.IdGrupoAcesso);
                        HttpContext.Session.SetString("username", user.Username);
                        return RedirectToAction("Index", "Home"); 
                    }

                    var empr = new EmpresaRepository().get(user);
                    if (empr != null)
                    {
                        HttpContext.Session.SetInt32("idEmpresa", empr.Id);
                        HttpContext.Session.SetString("nome", empr.NomeFantasia);
                        HttpContext.Session.SetString("razaosocial", empr.RazaoSocial);
                        HttpContext.Session.SetString("cnpj", empr.Cnpj);
                        HttpContext.Session.SetInt32("idGrupoAcesso", user.IdGrupoAcesso);
                        HttpContext.Session.SetString("username", user.Username);
                        return RedirectToAction("Index", "Home");
                    }
                };

            }
            catch (Exception ex)
            {
                TempData["redirectMessage"] = "Usuário ou senha invalido!";
                return View("Login");
            }
            TempData["redirectMessage"] = "Usuário ou senha invalido!";
            return View("Login");
        }

        public IActionResult Cadastro()
        {
            return View();
        }

        public IActionResult CreateUsuario(string txtusername, string txtsenha, string txtnome, string txtsobrenome, string txtcpf, string txtdataNasc)
        {
            try
            {
                txtsenha = new UsuarioRepository().Encrypt(txtsenha);
                Usuario user = new UsuarioRepository().add(txtusername, txtsenha);
                if (user.Username != null)
                {
                    DateTime datanasc = DateTime.Parse(txtdataNasc);
                    Pessoa pes = new PessoaRepository().add(new Pessoa()
                    {
                        Ativo = "S",
                        Cpf = txtcpf,
                        Nome = txtnome,
                        Sobrenome = txtsobrenome,
                        Usuario = user.Username,
                        DataNascimento = datanasc,
                    });

                    if (pes.Usuario != null)
                    {
                        ViewBag.message = "Usuário Salvo com Sucesso!";
                        return View("Login");
                    }
                    else
                    {
                        ViewBag.message = "Não foi possível salvar o usuário!";
                        return View("Cadastro");
                    }
                }
                else
                {
                    ViewBag.message = "Não foi possível salvar o usuário!";
                    return View("Cadastro");
                }
            }
            catch (Exception ex)
            {
                ViewBag.message = "Não foi possível salvar o usuário!";
                return View("Cadastro");
            }

        }

        [HttpPost]
        public virtual JsonResult Salvar([FromBody] UsuariosModel usuario)
        {
            try
            {
                usuario.senha = new UsuarioRepository().Encrypt(usuario.senha);
                Usuario user = new UsuarioRepository().add(usuario.username, usuario.senha);
            }
            catch (Exception ex)
            {
            }
            return new JsonResult(usuario);
        }

    }

}