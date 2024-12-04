using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolaMundoWindowsForm
{
    internal class Estado
    {
        public Estado(int _id, string _nombre)
        {
            id = _id;
            nombre = _nombre;
        }
        public Estado()
        {

        }
        public int id { get; set; }
        public string nombre { get; set; }

    }
}
