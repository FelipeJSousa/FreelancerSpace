using Microsoft.EntityFrameworkCore;
using Repositorio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositorio.Repositorios
{
    public class EmpresaRepository : BaseRepository<Empresa>
    {
        public new Empresa get(Usuario user)
        {
            Empresa empr = new Empresa();
            using (_context = new FreelancerSpaceContext())
            {
                empr = _context.Empresas.Include("UsernameNavigation").FirstOrDefault(x => x.Username == user.Username);
            }

            return empr;
        }
    }
}
