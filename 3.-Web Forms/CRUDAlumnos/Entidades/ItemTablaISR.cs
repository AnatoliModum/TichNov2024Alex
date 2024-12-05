using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ItemTablaISR
    {
        public decimal limiteInferior { get; set; }
        public decimal limiteSuperior { get; set; }
        public decimal cuotaFija { get; set; }
        public decimal excedente { get; set; }
        public decimal subsidio { get; set; }
        public decimal ISR { get; set; }
    }
}
