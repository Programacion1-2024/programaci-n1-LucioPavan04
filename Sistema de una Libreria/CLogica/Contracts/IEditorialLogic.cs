using CEntidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLogica.Contracts
{
    public interface IEditorialLogic
    {
       Task<List<Editorial>> GetAll();

       void AltaEditorial(Editorial editorial);

       void ActualizarEditorial(string nombre, Editorial editorialActualizar);

       void EliminarEditorial(string nombre);
        
    }
}
