using CDatos.Contexts;
using CDatos.Repositories.Contracts;
using CEntidades.Entidades;
using Microsoft.EntityFrameworkCore;


namespace CDatos.Repositories
{
    public class EditorialRepository : Repository<Editorial>, IEditorialRepository
    {
        public EditorialRepository(LibreriaContext context) : base(context) { }
        public async Task<List<Editorial>> GetAll()
        {
            try
            {
                return await _context.Editorial.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}