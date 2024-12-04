using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoDeVenta
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Ticket objTicket = new Ticket();
            objTicket.listaArticulos.Add( new ArticuloTich());
            objTicket.Imprimir();
            objTicket.listaArticulos.Add(new ArticuloNet());

            Console.ReadKey();
        }
    }
}
