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
            List<GruposAcesso> list = new List<GruposAcesso>();
            using (_context = new FreelancerSpaceContext())
            {
                list = _context.GruposAcessos.Include("IdAcessosNavigation").ToList();
            }
            return list;
        }
    }
}
