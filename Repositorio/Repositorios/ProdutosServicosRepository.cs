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
        public List<ProdutosServico> getAllProdServ()
        {
            List<ProdutosServico> list = new List<ProdutosServico>();
            using (_context = new FreelancerSpaceContext())
            {
                list = _context.ProdutosServicos.Include("IdRamoAtividadeNavigation").Where(x => x.Ativo.Equals("S")).ToList();
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
