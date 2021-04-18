using Microsoft.EntityFrameworkCore;
using Repositorio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositorio.Repositorios
{
    public class GrupoAcessoRepository : BaseRepository<GruposAcesso>
    {
        public new List<GruposAcesso> getAll()
        {
            using (_context = new FreelancerSpaceContext())
            {
                List<GruposAcesso> list = _context.Acessos.Include("IdAcessosNavigation").ToList();
                return list;
            }
        }
    }
}
