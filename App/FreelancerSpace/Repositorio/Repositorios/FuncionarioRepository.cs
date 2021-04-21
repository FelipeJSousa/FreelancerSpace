using Microsoft.EntityFrameworkCore;
using Repositorio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositorio.Repositorios
{
    public class FuncionarioRepository : BaseRepository<Funcionario>
    {
        public new List<Funcionario> getAll()
        {
            List<Funcionario> list = new List<Funcionario>();
            using (_context = new FreelancerSpaceContext())
            {
            list = _context.Funcionarios.Include("IdEmpresaNavigation")
                                        .Include("IdPessoaNavigation")
                                        .Include("UsernameNavigation").ToList();
            }
            return list;
        }
    }
}
