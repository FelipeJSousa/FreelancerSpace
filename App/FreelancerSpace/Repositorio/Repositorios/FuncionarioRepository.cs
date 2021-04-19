using Microsoft.EntityFrameworkCore;
using Repositorio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositorio.Repositorios
{
    public class FuncionarioRepository : BaseRepository<Funcionario>
    {
        public new List<Funcionario> getAll()
        {
            List<ProdutosServico> list = new List<ProdutosServico>();
            using (_context = new FreelancerSpaceContext())
            {
                list = _context.ProdutosServicos.Include("IdRamoAtividadeNavigation").ToList();
            }
            return list;
        }
    }
}
