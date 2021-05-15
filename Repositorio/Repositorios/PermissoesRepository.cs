using Repositorio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositorio.Repositorios
{
    public class PermissoesRepository : BaseRepository<Permissoes>
    {
        public new List<Permissoes> getAll()
        {
            List<Permissoes> list = new List<Permissoes>();

            using (_context = new FreelancerSpaceContext())
            {
                list = _context.Permissoes.Where(x => x.Ativo.Equals("S")).ToList();
            }

            return list;
        }
        public new Permissoes get(int id)
        {
            Permissoes funcion = new Permissoes();

            using (_context = new FreelancerSpaceContext())
            {
                funcion = _context.Permissoes.FirstOrDefault(x => x.Ativo.Equals("S") && x.Id.Equals(id));
            }

            return funcion;
        }
    }
}
