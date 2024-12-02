using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    internal class Triangulo : IFigura
    {
        public decimal _base { get; set; }
        public decimal altura { get; set; }

        public Triangulo()
        {
        }

        public Triangulo(decimal _base_ , decimal _altura)
        {
            this._base = _base_;
            this.altura = _altura;
        }

        public decimal Area()
        {
            return (this._base * this.altura) / 2;
        }

        public decimal Perimetro()
        {
            decimal lado = (decimal)Math.Sqrt((double)(_base / 2 * _base / 2 + altura * altura)); 
            return _base + 2 * lado;
        }
    }
}
