using Microsoft.EntityFrameworkCore;
using Repositorio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositorio.Repositorios
{
    public class FuncionalidadeRepository : BaseRepository<Funcionalidade>
    {
        public new List<Funcionalidade> getAll()
        {
            List<Funcionalidade> list = new List<Funcionalidade>();

            using (_context = new FreelancerSpaceContext())
            {
                list = _context.Funcionalidades.Where(x => x.Ativo.Equals("S")).ToList();
            }

            return list;
        }
        public new Funcionalidade get(int id)
        {
            Funcionalidade funcion = new Funcionalidade();

            using (_context = new FreelancerSpaceContext())
            {
                funcion = _context.Funcionalidades.FirstOrDefault(x => x.Ativo.Equals("S") && x.Id.Equals(id));
            }

            return funcion;
        }

    }
}
