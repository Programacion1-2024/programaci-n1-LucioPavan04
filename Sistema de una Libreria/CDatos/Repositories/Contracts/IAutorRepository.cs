

using CEntidades.Entidades;

namespace CDatos.Repositories.Contracts
{
    public interface IAutorRepository : IRepository<Autor>
    {
        Task<List<Autor>> GetAll();

    }
}
