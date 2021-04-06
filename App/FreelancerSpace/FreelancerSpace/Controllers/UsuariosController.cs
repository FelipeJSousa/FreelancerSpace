using AutoMapper;
using FreelancerSpace.Models;
using Microsoft.AspNetCore.Mvc;
using Repositorio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Repositorio.Repositorios;

namespace FreelancerSpace.Controllers
{
    public class UsuariosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult salvar(UsuariosModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var mapper = new Mapper(AutoMapperConfig.RegisterMappings());

                    Usuario user = mapper.Map<Usuario>(model);
                    user.IdGrupoAcesso = 1;

                    UsuarioRepository rep = new UsuarioRepository();
                    rep.add(user);

                    ViewBag.message = "Usuário Salvo com Sucesso!";
                }
            }
            catch (Exception)
            {
                ViewBag.message = "Não foi possível salvar o usuário!";
            }

            return View("Index");
        }
    }
}
