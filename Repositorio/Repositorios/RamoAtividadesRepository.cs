using Repositorio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositorio.Repositorios
{
    public class RamoAtividadesRepository : BaseRepository<RamoAtividade>
    {
        public new List<RamoAtividade> getAll()
        {
            List<RamoAtividade> list = new List<RamoAtividade>();

            using (_context = new FreelancerSpaceContext())
            {
                list = _context.RamoAtividades.Where(x => x.Ativo.Equals("S")).ToList();
            }

            return list;
        }
        public new RamoAtividade get(int id)
        {
            RamoAtividade funcion = new RamoAtividade();

            using (_context = new FreelancerSpaceContext())
            {
                funcion = _context.RamoAtividades.FirstOrDefault(x => x.Ativo.Equals("S") && x.Id.Equals(id));
            }

            return funcion;
        }
    }
}
