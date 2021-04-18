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
            using (_context = new FreelancerSpaceContext())
            {
                List<ProdutosServico> lista = (from x in _context.ProdutosServicos select new 
                                               ProdutosServico 
                                                { Id = x.Id, IdRamoAtividadeNavigation = x.IdRamoAtividadeNavigation, 
                                                    Descricao = x.Descricao, IdRamoAtividade = x.IdRamoAtividade, 
                                                    Nome = x.Nome} ).ToList();
                List<ProdutosServico> list = _context.ProdutosServicos.Include("IdRamoAtividadeNavigation").ToList();
                return list;
            }

        }
    }
}
