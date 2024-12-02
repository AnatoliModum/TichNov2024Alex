using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuGeneral
{
    internal class ISR
    {

        public static string[,] CargarTabla()
        {
            string path = "";
            string lineaLectura;
            string[,] datos = new string[21, 6];
            int fila = 0;

            try
            {
                Console.WriteLine("Ingresa la dirección y nombre de tu archivo: \n");
                path = @"" + Console.ReadLine();
            }
            catch
            {
                Console.WriteLine("Archivo no encontrado");
            }

            try
            {
                using (StreamReader archivo = new StreamReader(path))
                {
                    while ((lineaLectura = archivo.ReadLine()) != null && fila < 21)
                    {
                        string[] campos = lineaLectura.Split(',');
                        for (int columna = 0; columna < 6; columna++)
                        {
                            datos[fila, columna] = campos[columna];
                        }
                        fila++;
                    }
                }
            }
            catch
            {
                Console.WriteLine("Error al leer el archivo");
            }


            /* for (int i = 0; i < 21; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    Console.Write(datos[i, j] + "\t");
                }
                Console.WriteLine();
            }*/

            return datos;
        }

        public static decimal Calcular(decimal sueldoQuincenal)
        {
            string[,] datosIsr = CargarTabla();
            decimal IsrTotal = 0;
            int indice = buscarDatosSubsidio(sueldoQuincenal, datosIsr);

            IsrTotal = sueldoQuincenal - decimal.Parse(datosIsr[indice, 1]);
            IsrTotal = (IsrTotal * decimal.Parse(datosIsr[indice, 4])) / 100;
            IsrTotal = IsrTotal + decimal.Parse(datosIsr[indice, 3]);
            IsrTotal = IsrTotal - decimal.Parse(datosIsr[indice, 5]);


            return IsrTotal;
        }

        public static int buscarDatosSubsidio(decimal sueldoQuincenal, string[,] datosIsr)
        {
            int indice = 0;
            decimal val1 = 0;
            decimal val2 = 0;

            for (int i = 0; i < 20; i++)
            {
                if (decimal.Parse(datosIsr[i, 1]) < sueldoQuincenal && decimal.Parse(datosIsr[i, 2]) > sueldoQuincenal)
                {
                    indice = i;
                    break;
                }
            }

            return indice;

        }

        public static void presentacion()
        {
            decimal sueldoQuincenal = 0;

            Console.WriteLine("Ingrese su sueldo mensual");
            sueldoQuincenal = (decimal.Parse(Console.ReadLine())) / 2;

            Console.WriteLine($"Su todal de ISR a pagar es: \n {Calcular(sueldoQuincenal).ToString("C2")}");
            Console.ReadKey();
        }
    }
}
