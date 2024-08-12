using CEntidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEntidades.Metodos
{
    public class CRUDPedidos
    {
        public void AgregarPedido(Cliente ClientePedido, Libro CopiaLibro)
        {
            Venta LibroPedido = new Venta();

            LibroPedido.FechaVenta = DateTime.Now;
            LibroPedido.Cliente = ClientePedido;
            LibroPedido.Libro = CopiaLibro;


        }
        
            
    }
}
