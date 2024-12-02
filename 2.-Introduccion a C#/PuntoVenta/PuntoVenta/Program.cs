using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoVenta
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String opcion = "";
            bool continuar = true;

            while (continuar)
            {
                ControllerArticulos ca = new ControllerArticulos();

                Console.Clear();
                Console.WriteLine("V) Iniciar nueva venta");
                Console.WriteLine("T) Terminar");
                opcion = Console.ReadLine().ToUpper().Trim();

                switch (opcion)
                {
                    case "V":
                        ca.IniciarVenta();
                        break;
                    case "T":
                        continuar = false;
                        break;
                        default: Console.WriteLine("Ingrese una opcion valida"); break;
                }
                Console.WriteLine("\n\n\nOprima una tecla para continuar.....");
                Console.ReadKey();
            }

        }
    }
}
