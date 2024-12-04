using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoDeVenta
{
    internal class Ticket
    {
        public List<IArticulo> listaArticulos = new List<IArticulo>();

        public void Imprimir()
        {
            foreach ( var articulo in listaArticulos )
            {
                Console.WriteLine(articulo.Imprimir());
            }
        }
    }
}
