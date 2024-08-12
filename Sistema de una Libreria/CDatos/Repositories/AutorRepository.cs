using CDatos.Contexts;
using CDatos.Repositories.Contracts;
using CEntidades.Entidades;
using Microsoft.EntityFrameworkCore;

namespace CDatos.Repositories
{
    public class AutorRepository : Repository<Autor>, IAutorRepository
    {

        public AutorRepository(LibreriaContext context) : base(context)
        {
            
        }

        public async Task<List<Autor>> GetAll()
        {
            try
            {
                return await _context.Autor.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

      
    }
}
