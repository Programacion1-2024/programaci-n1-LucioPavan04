using CDatos.Repositories.Contracts;
using CEntidades.Entidades;
using CLogica.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLogica.Implementations
{
    public class PersonaLogic : IPersonaLogic
    {

        IPersonaRepository _personaRepository;

        public PersonaLogic(IPersonaRepository personarepository)
        {
            _personaRepository = personarepository;
        }
        public void AltaPersona(Persona personaNueva)
        {
            List<string> camposErroneos = new List<string>();
            if (string.IsNullOrEmpty(personaNueva.Nombre) || !IsValidName(personaNueva.Nombre))
                camposErroneos.Add("Nombre");

            if (string.IsNullOrEmpty(personaNueva.Apellido) || !IsValidName(personaNueva.Apellido))
                camposErroneos.Add("Apellido");

            if (string.IsNullOrEmpty(personaNueva.Documento) || !IsValidName(personaNueva.Documento) || _personaRepository.FindByCondition(p => p.Documento == personaNueva.Documento).Count() != 0)
                camposErroneos.Add("Documento");

            if (string.IsNullOrEmpty(personaNueva.Telefono) || !IsValidName(personaNueva.Telefono))
                camposErroneos.Add("Teléfono");

            if (string.IsNullOrEmpty(personaNueva.Email) || !IsValidName(personaNueva.Email))
                camposErroneos.Add("Email");

            if (camposErroneos.Count > 0)
            {
                throw new ArgumentException("Los siguientes campos son inválidos: ", string.Join(", ", camposErroneos));
            }

            Persona persona = new Persona();
            persona.Nombre = personaNueva.Nombre;
            persona.Apellido = personaNueva.Apellido;
            persona.Nacionalidad = personaNueva.Nacionalidad;
            persona.Documento = personaNueva.Documento;
            persona.Telefono = personaNueva.Telefono;
            persona.Email = personaNueva.Email;
            persona.TipoDocumento = personaNueva.TipoDocumento;

            if (personaNueva.Autor != null)
            {
                persona.Autor = personaNueva.Autor;
            }
            if (personaNueva.Empleado != null)
            {
                persona.Empleado = personaNueva.Empleado;
            }
            if (personaNueva.Cliente != null)
            {
                persona.Cliente = personaNueva.Cliente;
            }
            _personaRepository.Create(persona);
            _personaRepository.Save();
        }


        public void ActualizarPersona(string documento, Persona personaActualizar)
        {
            List<string> camposErroneos = new List<string>();
            if (string.IsNullOrEmpty(personaActualizar.Nombre) || !IsValidName(personaActualizar.Nombre))
                camposErroneos.Add("Nombre");

            if (string.IsNullOrEmpty(personaActualizar.Apellido) || !IsValidName(personaActualizar.Apellido))
                camposErroneos.Add("Apellido");

            if (string.IsNullOrEmpty(personaActualizar.Documento) || !IsValidName(personaActualizar.Documento))
                camposErroneos.Add("Documento");

            if (string.IsNullOrEmpty(personaActualizar.Telefono) || !IsValidName(personaActualizar.Telefono))
                camposErroneos.Add("Teléfono");

            if (string.IsNullOrEmpty(personaActualizar.Email) || !IsValidName(personaActualizar.Email))
                camposErroneos.Add("Email");


            if (camposErroneos.Count > 0)
            {
                throw new ArgumentException("Los siguientes campos son inválidos: ", string.Join(", ", camposErroneos));
            }

            if (string.IsNullOrEmpty(documento) || !IsValidDoxumento(documento))
                throw new ArgumentException("El documento ingresado es inválido.");

            Persona? persona = _personaRepository.FindByCondition(p => p.Documento == documento).FirstOrDefault();

            if (persona == null)
            {
                throw new ArgumentNullException("No se ha encontrado una persona con ese documento");
            }

            persona.Nombre = personaActualizar.Nombre;
            persona.Apellido = personaActualizar.Apellido;
            persona.Documento = personaActualizar.Documento;
            persona.Telefono = personaActualizar.Telefono;
            persona.Email = personaActualizar.Email;

            _personaRepository.Update(persona);
            _personaRepository.Save();
        }

        public void EliminarPersona(string documento)
        {
            if (string.IsNullOrEmpty(documento) || !IsValidDoxumento(documento))
                throw new ArgumentException("El documento ingresado es inválido.");

            Persona? persona = _personaRepository.FindByCondition(p => p.Documento == documento).FirstOrDefault();

            if (persona == null)
            {
                throw new ArgumentNullException("No se ha encontrado una persona con ese documento");
            }
            _personaRepository.Delete(persona);
            _personaRepository.Save();
        }

        #region validaciones
        private bool ContainsInvalidCharacter(string text)
        {
            char[] caracteres = { '!', '"', '#', '$', '%', '/', '(', ')', '=', '.', ',' };
            return caracteres.Any(c => text.Contains(c));
        }
        private bool IsValidName(string nombre)
        {
            return nombre.Length < 15 && !ContainsInvalidCharacter(nombre);
        }
        private bool IsValidDoxumento(string documento)
        {
            return documento.Length == 8 && documento.All(c => Char.IsNumber(c));
        }
        public bool IsValidTelefono(string telefono)
        {
            return telefono.Length == 10 && telefono.All(c => Char.IsNumber(c));
        }
        public bool IsValidEmail(string email)
        {
            return email.Contains('@') && !ContainsInvalidCharacter(email);
        }

        public Task<List<Persona>> GetAll()
        {
            throw new NotImplementedException();
        }
        #endregion validaciones 

    }


}
