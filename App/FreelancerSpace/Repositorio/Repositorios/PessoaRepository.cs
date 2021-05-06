using Microsoft.EntityFrameworkCore;
using Repositorio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositorio.Repositorios
{
    public class PessoaRepository : BaseRepository<Pessoa>
    {
        public Pessoa get(Usuario user)
        {
            Pessoa pes = new Pessoa();
            using (_context = new FreelancerSpaceContext())
            {
                pes = _context.Pessoas.Include("UsuarioNavigation").FirstOrDefault(x => x.Usuario == user.Username);
            }

            return pes;
        }

        public new Pessoa add(Pessoa pes)
        {
            using (_context = new FreelancerSpaceContext())
            {
                _context.Pessoas.Add(pes);
                _context.SaveChanges();
            }

            return pes;
        }
    }
}
