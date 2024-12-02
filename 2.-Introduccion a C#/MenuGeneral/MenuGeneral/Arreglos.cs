using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuGeneral
{
    internal class Arreglos
    {
        public static void Cadenas()
        {
            string nombreCompleto = "";
            string nomComConver = "";
            string[] palabras;

            Console.WriteLine("Proporciona tu nombre completo");
            nombreCompleto = Console.ReadLine();
            
            for (int i = 0; nombreCompleto.Length > i; i++ )
            {
                if (nombreCompleto.Substring(i, 1).Equals(" "))
                {
                    nomComConver = nomComConver + "\n";
                }
                else
                {
                    nomComConver = nomComConver + nombreCompleto.Substring(i, 1);
                }
            }
            Console.WriteLine($"\nHola\n {nomComConver}");

            palabras = nombreCompleto.Split(' ');

            string primerApellido = palabras[1];

            Console.WriteLine($"\nApellido en Vertical \n");

            foreach (char letra in primerApellido) {
                Console.WriteLine(letra);
            }
            Console.ReadKey();
        }

        public static void Enteros()
        {
            String numeroString = "";
            String[] numeros;
            int[] numCon;

            Console.WriteLine("Ingresa 5 numeros: \n");
            numeroString = Console.ReadLine();

            numeros = numeroString.Split(' ');

            numCon = new int[numeros.Length];

            for (int i = 0; i < numeros.Length; i++)
            {
                numCon[i] = Convert.ToInt32(numeros[i]);
            }

            Array.Sort(numCon);

            Console.WriteLine( "\nEl numero mayor es: " + numCon[numCon.Length-1]);
            
            Console.ReadKey();
        }

        public static void ConvierteATipoOracion()
        {
            String oracion = "";
            String oracionUpper = "";

            Console.WriteLine("Ingresa una oracion: \n");
            oracion = Console.ReadLine();

            oracion = oracion.ToLower();
            oracion = " " + oracion;

            for (int i = 0 ; oracion.Length > i ; i ++)
            {
                if (oracion.Substring(i, 1).Equals(" "))
                {
                    oracionUpper = oracionUpper + " " + (oracion.Substring(i + 1, 1)).ToUpper();
                    oracion = oracion.Remove(i + 1, 1);
                }
                else
                {
                    oracionUpper = oracionUpper + oracion.Substring(i, 1);
                }
            }

            Console.WriteLine("\nSu oracion: \n" + oracionUpper);
            Console.ReadKey();

        }
    }
}
