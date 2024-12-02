using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDEstatus
{
    internal class EstatusAlumnos
    {
        public EstatusAlumnos(int _id, string _nombre, string _clave)
        {
            id = _id;
            nombre = _nombre;
            clave = _clave;
        }
        public EstatusAlumnos() { }
        public int id { get; set; }
        public String nombre { get; set; }
        public String clave{ get; set; }
    }
}
