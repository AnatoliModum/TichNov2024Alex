using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDEstatus
{
    static internal class ControladorInecesario
    {
        private static EstatusControlles estCon = new EstatusControlles();

        public static void ReadAll()
        {
            
            try
            {
                foreach (var estatus in estCon.ReadEstatus())
                {
                    Console.WriteLine( $"Clave {estatus.id}: {estatus.nombre}   ->   Estatus: {estatus.clave}\n" );
                }
            }
            catch
            {
                Console.WriteLine("Error en CI");
            }
        }
        public static void ReadOne(int id)
        {
            bool val = false;

            try
            {
                
                foreach (var estatus in estCon.ReadEstatus())
                {
                    if (estatus.id == id) { Console.WriteLine($"Clave: {estatus.nombre}   ->   Estatus: {estatus.clave}\n"); val = true; }
                }

                if (!val) { Console.WriteLine("Alumno no encontrado"); }

            }
            catch
            {
                Console.WriteLine("Error en CI");
            }
        }
        public static void CreateState(int id, string nombre, string estatus)
        {
            EstatusAlumnos newAlumnito = new EstatusAlumnos(id, nombre, estatus);
            bool val = true;    

            try {

                if (estCon.ReadEstatus().Count == 0) { estCon.CreateEstatus(newAlumnito); } else
                {
                    foreach (var alumBusqueda in estCon.ReadEstatus())
                    {
                        if (alumBusqueda.id == id) { Console.WriteLine("El id del alumno ya existe"); val = false; break; }
                    }
                    if (val) { estCon.CreateEstatus(newAlumnito); }
                }
            }
            catch { Console.WriteLine("Error en CI"); }
        }
        public static void UpdateEstatus(int id, string nombre, string estatus)
        {
            bool val = true;

            try
            {
                foreach(var alumBusqueda in estCon.ReadEstatus())
                {
                    if (alumBusqueda.id == id) { estCon.UpdateEstatus(id, nombre, estatus); val = false; break; } 
                }
                if (val) { Console.WriteLine("El alumno no existe, valide su id"); }
            }
            catch
            {
                Console.WriteLine("Error en CI");
            }
            
        }
        public static void Delete(int id)
        {
            bool val = true;

            try
            {
                foreach(var alumnBusqueda in estCon.ReadEstatus())
                {
                    if (alumnBusqueda.id == id) { estCon.DeleteEstatus(id); val = false; break; } 
                }

                if (val) { Console.WriteLine("El alumno no existe, valide su id"); }

            }
            catch
            {
                Console.WriteLine("Error en CI");
            }
            
        }
        public static void Presentacion()
        {
            bool continuar = true;
            int seleccion = 0;

            while (continuar)
            {
                seleccion = 0;
                int id = 0;
                string estatus = "";
                string nombre = "";

                Console.Clear();
                Console.WriteLine("" +
                    "1. Consultar Todos\n" +
                    "2. Consultar Solo uno\n" +
                    "3. Agregar\n" +
                    "4. Actualizar\n" +
                    "5. Eliminar\n" +
                    "6. Terminar\n");
                seleccion = int.Parse(Console.ReadLine().Trim());

                switch (seleccion)
                {
                    case 1: ControladorInecesario.ReadAll(); break;
                    case 2:
                        Console.WriteLine("Ingrese el id de su estatus: \n");
                        ControladorInecesario.ReadOne(int.Parse(Console.ReadLine().Trim()));
                        break;
                    case 3:
                        Console.Write("Ingresa el id de su estatus: \n");
                        id = int.Parse(Console.ReadLine());
                        Console.WriteLine("\nIngresa la clave del estatus: \n");
                        nombre = Console.ReadLine();
                        Console.WriteLine("\nIngresa el estatus: \n");
                        estatus = Console.ReadLine();
                        ControladorInecesario.CreateState(id, nombre, estatus);
                        break;
                    case 4:
                        Console.Write("Ingresa el id de su alumno: \n");
                        id = int.Parse(Console.ReadLine());
                        Console.WriteLine("\nIngresa la nueva clave del estatus: \n");
                        nombre = Console.ReadLine();
                        Console.WriteLine("\nIngresa el nuevo nombre del estatus: \n");
                        estatus = Console.ReadLine();
                        ControladorInecesario.UpdateEstatus(id, nombre, estatus);
                        break;
                    case 5:
                        Console.Write("Ingresa el id para eliminar: \n");
                        id = int.Parse(Console.ReadLine());
                        ControladorInecesario.Delete(id);
                        break;
                    case 6: continuar = false; break;
                    default: Console.WriteLine("Ingresa una opcion valida"); ; break;

                }

                Console.WriteLine("Presione una tecla para continuar......");
                Console.ReadKey();
            }
        }

    }
}
