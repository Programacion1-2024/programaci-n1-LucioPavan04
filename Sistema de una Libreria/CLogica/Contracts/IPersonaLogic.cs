using CEntidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLogica.Contracts
{
    public interface IPersonaLogic
    {
        Task<List<Persona>> GetAll();

        void AltaPersona(Persona perosna);

        void ActualizarPersona(string documento, Persona personaActualizar);

        void EliminarPersona(string documento);


    }
}
