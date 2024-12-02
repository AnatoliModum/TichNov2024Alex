using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    internal class Estatus
    {
        public Estatus(int _id, string _nombre)
        {
            this.id = _id;
            this.nombre = _nombre;
        }
        public Estatus() { }
        public int id { get; set; }
        public String nombre { get; set; }
    }
}
