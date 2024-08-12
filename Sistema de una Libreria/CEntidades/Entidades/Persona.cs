using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEntidades.Entidades
{
    public class Persona
    {
        public int IdPersona { get; set; }
        public string Documento { get; set; }
        public string TipoDocumento { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set;}
        public string Telefono { get; set;}
        public string Nacionalidad { get; set; }
        public string Email { get; set; }
        public Autor? Autor { get; set; }
        public Cliente? Cliente { get; set; }
        public Empleado? Empleado { get; set; }
    }
}
