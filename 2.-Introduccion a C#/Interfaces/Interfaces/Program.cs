using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IFigura[] figuras = new IFigura[2] { new Triangulo(5, 6), new Cuadrado(5) };

            foreach (var figura in figuras)
            {
                Console.WriteLine($" Figura: {figura.ToString().Substring(11)}  |  Area: {figura.Area()}  |  Perimetro:  {figura.Perimetro()}");
            }
            Console.ReadKey();
        }
    }
}
