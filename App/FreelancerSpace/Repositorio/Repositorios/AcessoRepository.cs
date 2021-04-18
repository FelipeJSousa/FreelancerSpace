using Microsoft.EntityFrameworkCore;
using Repositorio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositorio.Repositorios
{
    public class AcessoRepository : BaseRepository<Acesso>
    {
        public new List<Acesso> getAll()
        {
            using (_context = new FreelancerSpaceContext())
            {
                List<Acesso> list = _context.Acessos.Include("PermissaoCadastroNavigation")
                                                    .Include("PermissaoEstatisticasNavigation")
                                                    .Include("PermissaoFaqEmpresaNavigation")
                                                    .Include("PermissaoPerfilEmpresaNavigation").ToList();
                return list;
            }
        }
    }
}
