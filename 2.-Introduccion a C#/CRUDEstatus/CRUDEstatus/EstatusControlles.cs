using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDEstatus
{
    internal class EstatusControlles
    {
        public static List<EstatusAlumnos> estAlum = new List<EstatusAlumnos>();

        public void CreateEstatus(EstatusAlumnos alumno)
        {
            try
            {
                estAlum.Add(alumno);
            }
            catch
            {
                Console.WriteLine( "Error al agregar el alumno" );
            }
        }
        public void DeleteEstatus(int id)
        {
            EstatusAlumnos delAlumn = new EstatusAlumnos();

            try{
                foreach (var alumno in estAlum)
                {
                    if (alumno.id == id) { delAlumn = alumno; break; }
                }

                estAlum.Remove(delAlumn);
            }
            catch{
                Console.WriteLine("Error al eliminar el alumno");
            }

            
        }
        public void UpdateEstatus(int id, string nombre, string estatus)
        {
            EstatusAlumnos delAlumn = new EstatusAlumnos();
            EstatusAlumnos updAlumn = new EstatusAlumnos(id,nombre,estatus);

            try
            {
                foreach (var alumno in estAlum)
                {
                    if (alumno.id == id) { delAlumn = alumno; break; }
                }

                estAlum.Remove(delAlumn);
                estAlum.Add(updAlumn);
            }
            catch
            {
                Console.WriteLine("Error al actualizar el alumno");
            }
        }
        public List<EstatusAlumnos> ReadEstatus()
        {
            return estAlum;
        }

    }
}
