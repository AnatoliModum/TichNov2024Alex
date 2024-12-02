using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    internal class ItemISR
    {
        public ItemISR(decimal _limInf, decimal _limSup, decimal _cuotaFija, decimal _porExced, decimal _subsidio)
        {
            limInf = _limInf;
            limSup = _limSup;
            cuotaFija = _cuotaFija;
            porExced = _porExced;
            subsidio = _subsidio;
        }
        public ItemISR() { }
        public decimal limInf { get; set; }
        public decimal limSup { get; set; }
        public decimal cuotaFija { get; set; }
        public decimal porExced { get; set; }
        public decimal subsidio { get; set; }
    }
}
