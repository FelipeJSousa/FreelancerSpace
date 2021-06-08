using Repositorio.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Repositorio.Repositorios
{
    public class CnaeRepository : BaseRepository<CnaeRepository>
    {
        public List<Cnae> getTopAtividades(string atividade)
        {
            List<Cnae> list = new List<Cnae>();
            using (_context = new FreelancerSpaceContext())
            {
                list = _context.Cnae.Where(x => x.DescSubclasse.ToLower().Contains(atividade.ToLower())).Take(12).ToList();
            }
            return list;
        }

    }
}
