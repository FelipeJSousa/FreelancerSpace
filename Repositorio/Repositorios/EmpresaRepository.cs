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

        public new List<Empresa> getAll()
        {
            List<Empresa> empr = new List<Empresa>();
            try
            {
                using (_context = new FreelancerSpaceContext())
                {
                    empr = _context.Empresas.Where(x => x.Ativo.Equals("S")).ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return empr;
        }
        public List<Empresa> getAll(string busca)
        {
            List<Empresa> empr = new List<Empresa>();
            try
            {
                using (_context = new FreelancerSpaceContext())
                {
                    empr = (from e in _context.Empresas
                            join c in _context.Cnae on e.Cnae equals c.CodCnae
                            where e.Ativo.Equals("S") && 
                            (e.NomeFantasia.Contains(busca) || e.RazaoSocial.Contains(busca) ||
                             e.Descricao.Contains(busca) || c.DescSubclasse.Contains(busca))
                            select e).ToList(); 
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return empr;
        }
        public Empresa get(Usuario user)
        {
            Empresa empr = new Empresa();
            using (_context = new FreelancerSpaceContext())
            {
                empr = _context.Empresas.Include("UsernameNavigation")
                    .Include("Funcionarios")
                    .Include("NotaAvaliacaos")
                    .Include("FaqPergunta").FirstOrDefault(x => x.Username == user.Username && x.Ativo.Equals("S"));
            }

            return empr;
        }
        public new Empresa get(int id)
        {
            Empresa empr = new Empresa();
            try
            {
                using (_context = new FreelancerSpaceContext())
                {
                    empr = _context.Empresas.AsNoTracking().FirstOrDefault(x => x.Id.Equals(id) && x.Ativo.Equals("S"));
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return empr;
        }

    }
}
