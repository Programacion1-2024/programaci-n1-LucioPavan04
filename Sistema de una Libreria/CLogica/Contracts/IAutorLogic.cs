using CEntidades.Entidades;

namespace CLogica.Contracts
{
    public interface IAutorLogic
    {
        Task<List<Autor>> GetAll();
    }
}
