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
                
                cfg.CreateMap<RamoAtividade, RamoAtividadeModel>();
                cfg.CreateMap<RamoAtividadeModel, RamoAtividade>();

            });
            return config;

        }


    }
}
