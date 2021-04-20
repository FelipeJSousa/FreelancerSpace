using Microsoft.EntityFrameworkCore;
using Repositorio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositorio.Repositorios
{
    public class GrupoAcessoRepository : BaseRepository<GrupoAcesso>
    {
        public new List<GrupoAcesso> getAll()
        {
            List<GrupoAcesso> list = new List<GrupoAcesso>();
            using (_context = new FreelancerSpaceContext())
            {
                list = _context.GrupoAcessos.Include("IdAcessosNavigation").ToList();
            }
            return list;
        }
        public new GrupoAcesso get(int id)
        {
            GrupoAcesso ga = new GrupoAcesso();
            using (_context = new FreelancerSpaceContext())
            {
                ga = _context.GrupoAcessos.Include("IdAcessosNavigation").FirstOrDefault(x => x.Id.Equals(id));
            }
            return ga;
        }
    }
}
