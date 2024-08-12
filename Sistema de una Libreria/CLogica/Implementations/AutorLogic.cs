using CDatos.Repositories.Contracts;
using CEntidades.Entidades;
using CLogica.Contracts;

namespace CLogica.Implementations
{
    public class AutorLogic : IAutorLogic
    {
        private IAutorRepository _AutorRepository;

        public AutorLogic(IAutorRepository AutorRepository)
        {
            _AutorRepository = AutorRepository;
        }

        public async Task<List<Autor>> GetAll()
        {
            return await _AutorRepository.GetAll();
        }
    }
}
