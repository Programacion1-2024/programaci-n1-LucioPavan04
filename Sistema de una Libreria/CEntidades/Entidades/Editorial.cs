using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEntidades.Entidades
{
    public class Editorial
    {
        public int IdEditorial { get; set; }
        public string Nombre { get; set;}
        public string Direccion { get; set; }
        public string Contacto { get; set; }
        public ICollection<Libro> Libros { get; set; }
    }
}
