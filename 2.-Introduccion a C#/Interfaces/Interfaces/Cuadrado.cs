using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    internal class Cuadrado : IFigura
    {
        public decimal lado { get; set; }

        public Cuadrado()
        {
        }

        public Cuadrado(decimal _lado)
        {
            lado = _lado;
        }

        public decimal Area()
        {
            return this.lado * this.lado;
        }

        public decimal Perimetro()
        {
            return this.lado * 4;
        }
    }
}
