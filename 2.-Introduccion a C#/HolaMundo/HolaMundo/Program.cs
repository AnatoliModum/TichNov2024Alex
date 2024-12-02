using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolaMundo
{
    internal class Program
    {

        static void Main(string[] args)
        {

            string nombre;
            String saludoEstatico;
            saludo saluditoObjetoNoEstatico = new saludo();


            Console.WriteLine("Cual Es tu Nombre?");

            nombre = Console.ReadLine();
            Console.WriteLine("Hola " + nombre + ", como estas?");
            Console.WriteLine(saludo.SaludarEstatico("Pepillo"));
            Console.WriteLine(saluditoObjetoNoEstatico.SaludarNoEstatico("Pepillo no estatico"));
            Console.ReadKey();
        }

    }
}
