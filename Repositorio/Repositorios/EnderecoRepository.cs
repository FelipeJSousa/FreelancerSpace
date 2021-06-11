using Repositorio.Models;
using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
