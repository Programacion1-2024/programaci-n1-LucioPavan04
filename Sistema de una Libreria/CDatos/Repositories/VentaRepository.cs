using CDatos.Contexts;
using CDatos.Repositories.Contracts;
using CEntidades.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDatos.Repositories
{
    public class VentaRepository : Repository<Venta>, IVentaRepository
    {
        public VentaRepository(LibreriaContext context) : base(context)
        {
            async Task<List<Venta>> GetAll()
            {
                try
                {
                    return await _context.Venta.ToListAsync();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public Task<List<Venta>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
