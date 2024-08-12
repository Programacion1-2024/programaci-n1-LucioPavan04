using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEntidades.Entidades
{
    public class AutorLibro
    {
        public int IdAutorLibro { get; set; }  
        public int IdAutor {  get; set; }
        public int IdLibro { get; set; }
    }
}
