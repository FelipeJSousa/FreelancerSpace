﻿using AutoMapper;
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

        public static MapperConfiguration RegisterMappings(){
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Usuario, UsuariosModel>();
                cfg.CreateMap<UsuariosModel, Usuario>();
                
                cfg.CreateMap<ProdutosServico, ProdutosServicosModel>();
                cfg.CreateMap<ProdutosServicosModel, ProdutosServico>();

                cfg.CreateMap<GrupoAcesso, GrupoAcessoModel>();
                cfg.CreateMap<GrupoAcessoModel, GrupoAcesso>();
                
                cfg.CreateMap<Permissoes, PermissoesModel>();
                cfg.CreateMap<PermissoesModel, Permissoes>();

                cfg.CreateMap<Acesso, AcessosModel>();
                cfg.CreateMap<AcessosModel, Acesso>();

                cfg.CreateMap<Funcionalidade, FuncionalidadesModel>();
                cfg.CreateMap<FuncionalidadesModel, Funcionalidade>();

                cfg.CreateMap<Cnae, CnaeModel>();
                cfg.CreateMap<CnaeModel, Cnae>();

                cfg.CreateMap<EmpresaModel, Empresa>();
                cfg.CreateMap<Empresa, EmpresaModel>();

                cfg.CreateMap<TelefoneModel, Telefone>();
                cfg.CreateMap<Telefone, TelefoneModel>();

                cfg.CreateMap<EnderecoModel, Endereco>();
                cfg.CreateMap<Endereco, EnderecoModel>();

            });
            return config;
        }


    }
}
