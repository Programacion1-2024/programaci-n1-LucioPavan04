using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEntidades.Entidades
{
    public class Libro
    {
        public int IdLibro { get; set; }
        public string ISBN { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public float PrecioVenta { get; set; }
        public ICollection<Autor> Autores { get; set; }
        public Editorial Editorial { get; set; }
        public ICollection<Genero> Generos { get; set; }
        public ICollection<Copia> Copias { get; set; }
        public ICollection<Venta> Ventas { get; set; }
    }
}
