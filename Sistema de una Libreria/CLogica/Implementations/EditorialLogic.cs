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
    public class EditorialLogic : IEditorialLogic
    {
        IEditorialRepository _editorialRepository;

        public EditorialLogic(IEditorialRepository editorialrepository)
        {
            _editorialRepository = editorialrepository;
        }

        public async Task<List<Editorial>> GetAll()
        {
            return await _editorialRepository.GetAll();
        }
        public void AltaEditorial(Editorial editorialNueva)
        {

            List<string> camposErroneos = new List<string>();
            if (string.IsNullOrEmpty(editorialNueva.Nombre) || !IsValidName(editorialNueva.Nombre))
                camposErroneos.Add("Nombre");

            if (string.IsNullOrEmpty(editorialNueva.Direccion) || !IsValidName(editorialNueva.Direccion))
                camposErroneos.Add("Dirección");

            if (string.IsNullOrEmpty(editorialNueva.Contacto) || !IsValidName(editorialNueva.Contacto))

                if (camposErroneos.Count > 0)
                {
                    throw new ArgumentException("Los siguientes campos son inválidos: ", string.Join(", ", camposErroneos));
                }

            Editorial editorial = new Editorial();
            editorial.Nombre = editorialNueva.Nombre;
            editorial.Direccion = editorialNueva.Direccion;
            editorial.Contacto = editorialNueva.Contacto;

            _editorialRepository.Create(editorial);
            _editorialRepository.Save();
        }


        public void ActualizarEditorial(string nombre, Editorial editorialActualizar)
        {
            List<string> camposErroneos = new List<string>();
            if (string.IsNullOrEmpty(editorialActualizar.Nombre) || !IsValidName(editorialActualizar.Nombre))
                camposErroneos.Add("Nombre");

            if (string.IsNullOrEmpty(editorialActualizar.Direccion) || !IsValidName(editorialActualizar.Direccion))
                camposErroneos.Add("Dirección");

            if (string.IsNullOrEmpty(editorialActualizar.Contacto) || !IsValidName(editorialActualizar.Contacto))
                camposErroneos.Add("Contacto");

            if (camposErroneos.Count > 0)
            {
                throw new ArgumentException("Los siguientes campos son inválidos: ", string.Join(", ", camposErroneos));
            }

            if (string.IsNullOrEmpty(nombre) || !IsValidName(nombre))
                throw new ArgumentException("El nombre es inválido.");

            Editorial? editorial = _editorialRepository.FindByCondition(p => p.Nombre == nombre).FirstOrDefault();

            if (editorial == null)
            {
                throw new ArgumentNullException("No se  encontro una editorial con ese nombre");
            }

            editorial.Nombre = editorialActualizar.Nombre;
            editorial.Direccion = editorialActualizar.Direccion;
            editorial.Contacto = editorialActualizar.Contacto;

            _editorialRepository.Update(editorial);
            _editorialRepository.Save();
        }


        public void EliminarEditorial(string nombre)
        {
            if (string.IsNullOrEmpty(nombre) || !IsValidName(nombre))
                throw new ArgumentException("El nombre es inválido.");

            Editorial? editorial = _editorialRepository.FindByCondition(p => p.Nombre == nombre).FirstOrDefault();

            if (editorial == null)
            {
                throw new ArgumentNullException("No se encontro una editorial con ese nombre");
            }
            _editorialRepository.Delete(editorial);
            _editorialRepository.Save();
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
        private bool IsValidDireccion(string direccion)
        {
            return direccion.Length < 17 && direccion.All(c => Char.IsNumber(c));
        }
        private bool IsValidContacto(string contacto)
        {
            return contacto.Length < 17 && contacto.All(c => Char.IsNumber(c));
        }
        public bool IsValidTelefono(string telefono)
        {
            return telefono.Length == 10 && telefono.All(c => Char.IsNumber(c));
        }
        public bool IsValidEmail(string email)
        {
            return email.Contains('@') && !ContainsInvalidCharacter(email);
        }
        #endregion validaciones 
    }
}
