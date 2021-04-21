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
                list = _context.GrupoAcessos.Where(x => x.Ativo.Equals("S")).ToList();
            }
            return list;
        }
        public new GrupoAcesso get(int id)
        {
            GrupoAcesso ga = new GrupoAcesso();
            using (_context = new FreelancerSpaceContext())
            {
                ga = _context.GrupoAcessos.FirstOrDefault(x => x.Ativo.Equals("S") && x.Id.Equals(id));
            }
            return ga;
        }
    }
}
