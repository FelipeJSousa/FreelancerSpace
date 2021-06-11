using Repositorio.Models;
using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
