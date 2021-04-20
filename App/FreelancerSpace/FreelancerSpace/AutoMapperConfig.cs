using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreelancerSpace.Models;
using Repositorio.Models;

namespace FreelancerSpace
{
    public class AutoMapperConfig : Profile
    {

        public static MapperConfiguration RegisterMappings()

        {

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Usuario, UsuariosModel>();
                cfg.CreateMap<UsuariosModel, Usuario>();
                
                cfg.CreateMap<RamoAtividade, AcessosModel>();
                cfg.CreateMap<AcessosModel, RamoAtividade>();

                cfg.CreateMap<GruposAcesso, GrupoAcessoModel>();
                cfg.CreateMap<GrupoAcessoModel, GruposAcesso>();
                
                cfg.CreateMap<PermissaoAcesso, PermissoesModel>();
                cfg.CreateMap<PermissoesModel, PermissaoAcesso>();

                cfg.CreateMap<Acesso, AcessosModel>();
                cfg.CreateMap<AcessosModel, Acesso>();


            });
            return config;

        }


    }
}
