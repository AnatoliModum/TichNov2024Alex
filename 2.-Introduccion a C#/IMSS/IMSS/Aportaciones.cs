using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSS
{
    internal struct Aportaciones
    {
        public Aportaciones(decimal enfMaNew, decimal invaVi, decimal retiro, decimal cesan, decimal Infona)
        {
            EnfermedadMaternidad = enfMaNew; InvalidezVida = invaVi; Retiro = retiro; Cesantia = cesan; Infonavit = Infona;
        }
        public decimal EnfermedadMaternidad { get; set; }
        public decimal InvalidezVida { get; set; }
        public decimal Retiro { get; set; }
        public decimal Cesantia { get; set; }
        public decimal Infonavit { get; set; }


    }
}
