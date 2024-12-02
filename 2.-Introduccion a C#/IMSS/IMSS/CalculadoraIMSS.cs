using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSS
{
    internal class CalculadoraIMSS
    {

        public static Aportaciones Calcular(decimal SBC, decimal UMA, int entidad)
        {
            Aportaciones apor = new Aportaciones();
            
            if ( entidad.Equals(1) )
            {
                apor.EnfermedadMaternidad = (SBC - (UMA * 3)) * decimal.Parse("0.04");
                apor.InvalidezVida = (SBC) * decimal.Parse("0.0625");
                apor.Retiro = (SBC) * decimal.Parse("0");
                apor.Cesantia = (SBC) * decimal.Parse("0.1125");
                apor.Infonavit = (SBC) * decimal.Parse("0");
            }
            else if (entidad.Equals(2))
            {
                apor.EnfermedadMaternidad = (SBC - UMA) * decimal.Parse("0.11");
                apor.InvalidezVida = (SBC - UMA) * decimal.Parse("0.175");
                apor.Retiro = (SBC - UMA) * decimal.Parse("0.2");
                apor.Cesantia = (SBC - UMA) * decimal.Parse("0.3150");
                apor.Infonavit = (SBC - UMA) * decimal.Parse("0.5");
            }

            return apor;
        }

        public static void Presentacion()
        {
            decimal SBC; decimal UMA; int entidad;
            Aportaciones apo = new Aportaciones();

            Console.WriteLine("Ingrese su Salario Base de Cotización (SBC) mensual");
            SBC = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese su Unidad de Medida de Actualización(UMA)");
            UMA = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Seleccione una Opcion \n 1.- Trabajador \n 2.- Patron");
            entidad = int.Parse(Console.ReadLine());

            apo = CalculadoraIMSS.Calcular(SBC, UMA, entidad);

            Console.WriteLine($"" +
                $"1.- Enfermedades y Maternidad: {apo.EnfermedadMaternidad} \n" +
                $"2.- Invalidez y Vida : {apo.InvalidezVida} \n" +
                $"3.- Retiro: {apo.Retiro} \n" +
                $"4.- Cesantia: {apo.Cesantia} \n" +
                $"5.- Credito Infonavit: {apo.Infonavit} \n");
            Console.ReadKey();
        }

    }
}
