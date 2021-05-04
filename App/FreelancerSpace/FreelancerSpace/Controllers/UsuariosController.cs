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
            return View();
        }

        public IActionResult ValidarLogin(UsuariosModel model)
        {
            try
            {
                model.senha = new UsuarioRepository().Encrypt(model.senha);
                var mapper = new Mapper(AutoMapperConfig.RegisterMappings());
                var user = mapper.Map<Usuario>(model);
                if (new UsuarioRepository().validarLogin(user.Username, user.Senha) != null) { 
                    HttpContext.Session.SetInt32("idPessoa", user);
                    HttpContext.Session.SetString("idGrupoAcesso", user.IdGrupoAcesso);
                    HttpContext.Session.SetInt32("username", user.Username);
                    return RedirectToAction("Index", "Home");
                };

            }
            catch (Exception ex)
            {
                ViewBag.message = "Usuário ou senha invalido!";
            }
            if(model == null)
            {
                return View();
            }
            else
            {
                return RedirectToPage("Home");
            }
        }


        public IActionResult Create(UsuariosModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var mapper = new Mapper(AutoMapperConfig.RegisterMappings());

                    model.senha = new UsuarioRepository().Encrypt(model.senha);
                    
                    Usuario user = mapper.Map<Usuario>(model);

                    UsuarioRepository rep = new UsuarioRepository();
                    rep.add(user);

                    ViewBag.message = "Usuário Salvo com Sucesso!";
                }
            }
            catch (Exception ex)
            {
                ViewBag.message = "Não foi possível salvar o usuário!";
            }

            return View();
        }


    }
}
