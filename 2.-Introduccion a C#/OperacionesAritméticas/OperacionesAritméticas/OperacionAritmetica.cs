using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperacionesAritméticas
{
    internal class OperacionAritmetica
    {
        

        public OperacionAritmetica(decimal newA, decimal newB, tipoOperacion nweOperacion)
        {
            a = newA;
            b = newB;
            operacion = nweOperacion;
        }

        public OperacionAritmetica() { }

        public decimal a { get; set; }

        public decimal b { get; set; }

        public tipoOperacion operacion { get; set; }


    }
}
