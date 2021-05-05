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

        public IActionResult ValidarLogin(string txtusername, string txtsenha)
        {
            Usuario user = new Usuario();
            try
            {
                user = new UsuarioRepository().validarLogin(txtusername, txtsenha);
                if (user != null) {
                    var pes = new PessoaRepository().get(user);
                    HttpContext.Session.SetInt32("idPessoa", pes.Id);
                    HttpContext.Session.SetString("nome", pes.Nome);
                    HttpContext.Session.SetString("sobrenome", pes.Sobrenome);
                    HttpContext.Session.SetInt32("idGrupoAcesso", user.IdGrupoAcesso);
                    HttpContext.Session.SetString("username", user.Username);
                    return RedirectToAction("Index", "Home");
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

        public IActionResult Create(string txtusername, string txtsenha)
        {
            try
            {
                txtsenha = new UsuarioRepository().Encrypt(txtsenha);
                UsuarioRepository rep = new UsuarioRepository();
                if (rep.add(txtusername, txtsenha))
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
            catch (Exception ex)
            {
                ViewBag.message = "Não foi possível salvar o usuário!";
                return View("Cadastro");
            }

        }


    }
}
