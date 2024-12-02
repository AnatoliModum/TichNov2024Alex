using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDEstados
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool continuar = true;
            int seleccion = 0;

            while (continuar)
            {
                seleccion = 0;
                int id = 0;
                string estado = "";

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
                    case 2: Console.WriteLine("Ingrese su id: \n");
                            ControladorInecesario.ReadOne(int.Parse(Console.ReadLine().Trim())); 
                        break;
                    case 3: Console.Write("Ingresa un id: \n");
                            id = int.Parse(Console.ReadLine());
                            Console.WriteLine("\nIngresa tu estado: \n");
                            estado = Console.ReadLine();
                            ControladorInecesario.CreateState(id,estado); 
                        break;
                    case 4:
                            Console.Write("Ingresa el id para actualizar: \n");
                            id = int.Parse(Console.ReadLine());
                            Console.WriteLine("\nIngresa tu nuevo estado: \n");
                            estado = Console.ReadLine();
                            ControladorInecesario.Update(id, estado);
                        break;
                    case 5:
                            Console.Write("Ingresa el id para eliminar: \n");
                            id = int.Parse(Console.ReadLine());
                            ControladorInecesario.Delete(id);
                        break;
                    case 6: continuar = false; break;
                    default: Console.WriteLine("Ingresa una opcion valida"); ; break;

                }
            }
        }
    }
}
