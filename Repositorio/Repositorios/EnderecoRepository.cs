using Repositorio.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Repositorio.Repositorios
{
    public class EnderecoRepository : BaseRepository<Endereco>
    {
        public bool SalvarEnderecoEmpresa(int idEndereco, int idEmpresa)
        {
            try
            {
                using (_context = new FreelancerSpaceContext())
                {
                    var ret = _context.EnderecosXempresas.Add(new EnderecosXempresa() { IdEmpresa = idEmpresa, IdEndereco = idEndereco });
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public List<Endereco> getAll(int idEmpresa)
        {
            List<Endereco> list = new List<Endereco>();
            try
            {
                using (_context = new FreelancerSpaceContext())
                {
                    list = (from e in _context.Enderecos
                            join ee in _context.EnderecosXempresas on
                                e.Id equals ee.IdEndereco
                            where ee.IdEmpresa.Equals(idEmpresa)
                            && e.Ativo.Equals("S")
                            orderby e.Id
                            select e).ToList();
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
            List<Endereco> list = new List<Endereco>();
            try
            {
                using (_context = new FreelancerSpaceContext())
                {
                    list = (from e in _context.Enderecos
                            join ee in _context.EnderecosXempresas on
                                e.Id equals ee.IdEndereco
                            where ee.IdEmpresa.Equals(idEmpresa)
                            && e.Ativo.Equals("S")
                            orderby e.Id
                            select e).Where(x => !idNotIn.Contains(x.Id)).ToList();
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
