using Repositorio.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Repositorio.Repositorios
{
    public class ProdutosServicosRepository : BaseRepository<ProdutosServico>
    {

        public bool SalvarProdServEmpresa(int idprodserv, int idEmpresa)
        {
            try
            {
                using (_context = new FreelancerSpaceContext())
                {
                    var ret = _context.ProdutosServicosXempresas.Add(new ProdutosServicosXempresa() { IdProdutoServico = idprodserv, IdEmpresa = idEmpresa });
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
        public List<ProdutosServico> getAllProdServ()
        {
            List<ProdutosServico> list = new List<ProdutosServico>();
            using (_context = new FreelancerSpaceContext())
            {
                list = _context.ProdutosServicos.Include("IdRamoAtividadeNavigation").Where(x => x.Ativo.Equals("S")).ToList();
            }
            return list;
        }

        public List<ProdutosServico> getAll(int idEmpresa)
        {
            List<ProdutosServico> list = new List<ProdutosServico>();
            using (_context = new FreelancerSpaceContext())
            {
                list = (from p in _context.ProdutosServicos
                        join pse in _context.ProdutosServicosXempresas on
                           p.Id equals pse.IdProdutoServico
                        where pse.IdEmpresa.Equals(idEmpresa)
                        && p.Ativo.Equals("S")
                        orderby p.Nome
                        select p).Include("IdRamoAtividadeNavigation").ToList();
            }
            return list;
        }


        public new ProdutosServico get(int id)
        {
            ProdutosServico prodserv = new ProdutosServico();
            using (_context = new FreelancerSpaceContext())
            {
                prodserv = _context.ProdutosServicos.Include("IdRamoAtividadeNavigation").FirstOrDefault(x => x.Ativo.Equals("S") && x.Id.Equals(id));
            }
            return prodserv;
        }
        public List<ProdutosServico> listar(string name)
        {
            List<ProdutosServico> prodserv = new List<ProdutosServico>();
            using (_context = new FreelancerSpaceContext())
            {
                prodserv = _context.ProdutosServicos.Include("IdRamoAtividadeNavigation").Where(x => x.Ativo.Equals("S") && x.Nome.ToUpper().Contains(name.ToUpper())).ToList();
            }
            return prodserv;
        }
    }
}
