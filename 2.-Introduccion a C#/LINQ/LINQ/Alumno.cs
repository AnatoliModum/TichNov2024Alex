using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    internal class Alumno
    {
        public Alumno(int _id, string _nombre, decimal _calificacion, int _idEstado, int _idEstatus)
        {
            id = _id;
            nombre = _nombre;
            calificacion = _calificacion;
            idEstado = _idEstado;
            idEstatus = _idEstatus;
        }
        public Alumno() { }
        public int id { get; set; }
        public string nombre { get; set; }
        public decimal calificacion { get; set; }
        public int idEstado { get; set; }
        public int idEstatus { get; set; }
    }
}
