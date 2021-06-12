using Repositorio.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Repositorio.Repositorios
{
    public class TelefoneRepository : BaseRepository<Telefone>
    {
        public bool SalvarTelefoneEmpresa(int idTelefone, int idEmpresa)
        {
            try
            {
                using (_context = new FreelancerSpaceContext())
                {
                    var ret = _context.TelefoneXempresas.Add(new TelefoneXempresa() { IdEmpresa = idEmpresa, IdTelefone = idTelefone });
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public List<Telefone> getAll(int idEmpresa)
        {
            List<Telefone> list = new List<Telefone>();
            try
            {
                using (_context = new FreelancerSpaceContext())
                {
                    list = (from t in _context.Telefones
                                join te in _context.TelefoneXempresas on
                                    t.Id equals te.IdTelefone
                                where te.IdEmpresa.Equals(idEmpresa)
                                && t.Ativo.Equals("S")
                                orderby t.Id
                                select t).ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return list;
        }

        public bool delete(int idEmpresa, List<int> idNotIn)
        {
            List<Telefone> list = new List<Telefone>();
            try
            {
                using (_context = new FreelancerSpaceContext())
                {
                    list = (from t in _context.Telefones
                                join te in _context.TelefoneXempresas on
                                    t.Id equals te.IdTelefone
                                where te.IdEmpresa.Equals(idEmpresa)
                                && t.Ativo.Equals("S")
                                orderby t.Id
                                select t).Where(x => !idNotIn.Contains(x.Id)).ToList();
                    foreach (var item in list)
                    {
                        item.Ativo = "N";
                        _context.Entry(item).State = EntityState.Modified;
                    }
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}
