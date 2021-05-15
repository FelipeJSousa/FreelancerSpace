using Microsoft.EntityFrameworkCore;
using Repositorio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Repositorio.Repositorios
{
    public class AcessoRepository : BaseRepository<Acesso>
    {
        public new List<Acesso> getAll()
        {
            using (_context = new FreelancerSpaceContext())
            {
                List<Acesso> list = _context.Acessos.Include("IdFuncionalidadeNavigation")
                                                    .Include("IdGrupoNavigation")
                                                    .Include("IdPermissaoNavigation").ToList();
                return list;
            }
        }
        public Acesso get(Expression<Func<Acesso,bool>> predicate)
        {
            using (_context = new FreelancerSpaceContext())
            {
                Acesso acesso = _context.Acessos.Include("IdFuncionalidadeNavigation")
                                                .Include("IdGrupoNavigation")
                                                .Include("IdPermissaoNavigation").FirstOrDefault(predicate);
                return acesso;
            }
        }
    }
}
