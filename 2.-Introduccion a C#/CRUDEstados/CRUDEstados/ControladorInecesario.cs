using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDEstados
{
    static internal class ControladorInecesario
    {
        static EstadosController eco = new EstadosController();

        public static void ReadAll()
        {

            try{
                Console.WriteLine("Estados: ");
                foreach (var par in eco.ReadEstados())
                {
                    Console.WriteLine($"{par.Value}\n");
                }
                Console.ReadKey();
            }
            catch
            {
                Console.WriteLine("Error al leer los datos");
            }

            
        }
        public static void CreateState(int id, string estado)
        {
            try{

                if (eco.ReadEstados().Count == 0) { eco.CreateEstados(id, estado); }

                foreach (var par in eco.ReadEstados())
                {
                    if (par.Key == id) { Console.WriteLine($"El estado ya existe"); } else { eco.CreateEstados(id, estado); }
                }

            }
            catch
            {
                Console.WriteLine("Error al crear el estado");
            }
        }
        public static void ReadOne(int id)
        {

            try
            {
                Console.WriteLine("Estado: ");
                foreach (var par in eco.ReadEstados())
                {
                    if(par.Key == id) { Console.WriteLine($"{par.Value}\n"); }
                }
                Console.ReadKey();
            }
            catch
            {
                Console.WriteLine("Error al leer los datos");
            }


        }
        public static void Update(int id, string estado)
        {
            try{
                foreach (var par in eco.ReadEstados())
                {
                    if (par.Key == id) { eco.UpdateEstados(id, estado); } else { Console.WriteLine("El estado no existe"); }
                }
            }catch{
                Console.WriteLine("Error al actualizar el estado");
            }
        }
        public static void Delete(int id)
        {
            try{
                foreach (var par in eco.ReadEstados())
                {
                    if (par.Key == id) { eco.DeleteEstados(id); } else { Console.WriteLine("El estado no existe"); }
                }
            }
            catch{
                Console.WriteLine("Error al eliminar el estado");
            }
        }
    }
}
