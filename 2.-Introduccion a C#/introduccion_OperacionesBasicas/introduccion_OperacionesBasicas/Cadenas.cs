using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace introduccion_OperacionesBasicas
{
    internal class Cadenas
    {
        public static void HolaMundo()
        {
            string nombre;
            string pApellido;
            string sApellido;
            int edad;
            string cadena;
            string ruta;

            Console.WriteLine("Proporciona tu nombre");
            nombre = Console.ReadLine();
            Console.WriteLine("Proporciona tu primer apellido");
            pApellido = Console.ReadLine();
            Console.WriteLine("Proporciona tu segundo apellido");
            sApellido = Console.ReadLine();
            Console.WriteLine("Proporciona tu edad");
            edad = int.Parse(Console.ReadLine());


            Console.WriteLine("Hola"+ nombre + pApellido + sApellido );
            Console.WriteLine("{0} {1} {2} tiene {3} años",nombre, pApellido, sApellido, edad);
            cadena = $"Gusto en conocerte {nombre.ToUpper()} {pApellido.ToUpper()} {sApellido.ToUpper()} !!!!! ";
            Console.WriteLine(cadena);
            ruta = @"C:\Users\Tichs\Documents\PracticasNov\Semana2_Net\Practica_1\introduccion_OperacionesBasicas\"+nombre.ToUpper().Trim() +pApellido.ToUpper().Trim() + sApellido.ToUpper().Trim() + ".docx";
            Console.WriteLine("El archivo fue almacenado en \n" + ruta);
            Console.WriteLine("Datos del usuario sin espacios: \n {0} {1} {2}",nombre.Trim(), pApellido.Trim(), sApellido.Trim());

            Console.ReadKey();
        }
    }
}
