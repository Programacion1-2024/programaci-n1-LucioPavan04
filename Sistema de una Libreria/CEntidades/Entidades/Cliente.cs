using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEntidades.Entidades
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public bool EsSocio {  get; set; }
        public bool PagaIVA { get; set; }
        public Persona Persona { get; set; } 
        public ICollection<Prestamo> Prestamos { get; set; }
        public ICollection<Venta> Ventas { get; set; }
    }
}
