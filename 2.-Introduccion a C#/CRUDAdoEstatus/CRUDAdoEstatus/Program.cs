using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDAdoEstatus
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ADOEstatus estaControl = new ADOEstatus();

            estaControl.Presentacion();
        }
    }
}
