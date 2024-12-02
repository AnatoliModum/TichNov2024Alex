using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuGeneral
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int contador = 0;
            bool continuar = true;
            Opciones opc2;


            while (continuar)
            {
                contador = 0;
                Console.WriteLine("Solicite una operacion: \n");
                foreach (Opciones opc in Enum.GetValues(typeof(Opciones)))
                {
                    Console.WriteLine("{0} .- {1} ", contador, opc);
                    contador++;
                }

                opc2 = (Opciones)int.Parse(Console.ReadLine());

                switch (opc2)
                {
                    case Opciones.Cadenas:
                        Arreglos.Cadenas();
                        break;
                    case Opciones.Numeros:
                        Arreglos.Enteros();
                        break;
                    case Opciones.Mayusculas:
                        Arreglos.ConvierteATipoOracion();
                        break;
                    case Opciones.Poliza:
                        Poliza.Presentacion();
                        break;
                    case Opciones.Salir:
                        continuar = false;
                        break;
                     case Opciones.ArchivoTxt:
                         Archivotxt.Presentacion();
                         break;
                     default:
                        Console.WriteLine("Ingrese una opcion valida");
                        break;
                }

               Console.ReadKey();
           }

        }
    }
}