using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuGeneral
{
    internal class Poliza
    {
        public static PolizaResultado Calcular(DateTime inicioVigencia, timeType ttp ,int tiempo, decimal sumaAsegurada, DateTime fechaNacimiento, int genero)
        {
            PolizaResultado pr = new PolizaResultado();
            decimal prima = 0;
            DateTime fechaVencimiento = CalcularFechaVencimiento(tiempo, ttp, inicioVigencia);
            int difFecha = (fechaVencimiento - inicioVigencia).Days;
            decimal[,] arreglito = ArregloFactores();
            int indice = buscarArreglo(genero,CalcularEdad(fechaNacimiento));
            decimal facto = arreglito[indice, 2];
            prima = sumaAsegurada * facto * difFecha / 360;

            pr.prima = prima;
            pr.fechaTermino = fechaVencimiento;

            return pr;

        }

        public static DateTime CalcularFechaVencimiento(int tiempo, timeType ttp, DateTime inicioVigencia)
        {
            DateTime vencimiento = inicioVigencia;


            switch (ttp)
            {
                case timeType.Dia:
                    vencimiento = inicioVigencia.AddDays(tiempo);
                    break;
                case timeType.Mes:
                    vencimiento = inicioVigencia.AddMonths(tiempo);
                    break;
                case timeType.Año:
                    vencimiento = inicioVigencia.AddYears(tiempo);
                    break;
            }

            return vencimiento;

        }

        public static int CalcularEdad( DateTime fechaNacimiento )
        {
            int edad = DateTime.Today.Year - fechaNacimiento.Year;

            if (DateTime.Today < fechaNacimiento.AddYears(edad))
            {
                return --edad;
            }else{
                return edad;
            }

        }

        public static int buscarArreglo(int genero, int edad)
        {
            decimal[,] arreglito = Poliza.ArregloFactores();
            int limiteArregloSexo = (genero == 1) ? 5 : 11;
            int fila = -1;

            for (int i = limiteArregloSexo; i >= 0; i--)
            {
                if (arreglito[i, 3] <= edad && arreglito[i, 0] >= edad)
                {
                    fila = i;
                    break;
                }
            }

            return fila;
        }


        public static decimal[,] ArregloFactores()
        {
            decimal[,] Factosfactos = new decimal[12, 4];

            //Rango edad maxima

            Factosfactos[0, 0] = 20;
            Factosfactos[1, 0] = 30;
            Factosfactos[2, 0] = 40;
            Factosfactos[3, 0] = 50;
            Factosfactos[4, 0] = 60;
            Factosfactos[5, 0] = 61;

            Factosfactos[6, 0] = 20;
            Factosfactos[7, 0] = 30;
            Factosfactos[8, 0] = 40;
            Factosfactos[9, 0] = 50;
            Factosfactos[10, 0] = 60;
            Factosfactos[11, 0] = 61;


            // sexo
            Factosfactos[0, 1] = 1;
            Factosfactos[1, 1] = 1;
            Factosfactos[2, 1] = 1;
            Factosfactos[3, 1] = 1;
            Factosfactos[4, 1] = 1;
            Factosfactos[5, 1] = 1;

            Factosfactos[6, 1] = 2;
            Factosfactos[7, 1] = 2;
            Factosfactos[8, 1] = 2;
            Factosfactos[9, 1] = 2;
            Factosfactos[10, 1] = 2;
            Factosfactos[11, 1] = 2;

            //Factor
            Factosfactos[0, 2] = (decimal) 0.05;
            Factosfactos[1, 2] = (decimal) 0.1;
            Factosfactos[2, 2] = (decimal) 0.4;
            Factosfactos[3, 2] =  (decimal) 0.05;
            Factosfactos[4, 2] = (decimal) 0.651;
            Factosfactos[5, 2] = (decimal) .5;

            Factosfactos[6, 2] = (decimal) 0.05;
            Factosfactos[7, 2] = (decimal) 0.1;
            Factosfactos[8, 2] = (decimal) 0.4;
            Factosfactos[9, 2] = (decimal) 0.05;
            Factosfactos[10, 2] = (decimal) 0.651;
            Factosfactos[11, 2] = (decimal) .5;

            // Rango de edad minima
            Factosfactos[0, 3] = 0;
            Factosfactos[1, 3] = 21;
            Factosfactos[2, 3] = 31;
            Factosfactos[3, 3] = 41;
            Factosfactos[4, 3] = 51;
            Factosfactos[5, 3] = 61;

            Factosfactos[6, 3] = 0;
            Factosfactos[7, 3] = 21;
            Factosfactos[8, 3] = 31;
            Factosfactos[9, 3] = 41;
            Factosfactos[10, 3] = 51;
            Factosfactos[11, 3] = 61;

            return Factosfactos;

        }

        public static Tiempo calcularPeriodo(String periodo)
        {
            Tiempo tmp = new Tiempo();

            string[] partes = periodo.Split(' '); 
            int cantidad = int.Parse(partes[0]); 
            int tipo = 0; 


            switch (partes[1].ToLower()) {
                case "día":
                case "días":
                case "dia":
                case "dias":
                    tipo = 0; 
                    break; 
                case "mes": 
                case "meses": 
                    tipo = 1; 
                    break; 
                case "año": 
                case "años": 
                    tipo = 2; 
                    break; 
                default: throw new ArgumentException("Tipo de periodo no válido");
            }

            tmp.ttp = (timeType)tipo;
            tmp.tiempo = cantidad;

            return tmp;
        }

        public static int validarSexo(String sexo)
        {
            int sexoInt = 0;

            switch (sexo.ToLower())
            {
                case "masculino":
                case "hombre":
                    sexoInt = 1;
                    break;
                case "femenino":
                case "mujer":
                    sexoInt = 2;
                    break;
                default: throw new ArgumentException("Tipo de sexo no válido");
            }

            return sexoInt;
        }

        public static void Presentacion()
        {
            DateTime inicioVigencia; int tiempo; timeType ttp; decimal sumaAsegurada; DateTime fechaNacimiento; int genero;
            String periodo;

            Console.WriteLine("Proporciona la fecha de inicio de Vigencia (aaaa-mm-dd) : \n");
            inicioVigencia = DateTime.Parse( Console.ReadLine() );

            Console.WriteLine("Proporciona para cuanto tiempo requieres la póliza (ejemplo 2 años): \n");
            periodo = Console.ReadLine();

            tiempo = calcularPeriodo(periodo).tiempo;
            ttp = calcularPeriodo(periodo).ttp;

            Console.WriteLine("Proporciona la suma asegurada: \n");
            sumaAsegurada = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Proporciona la fecha de Nacimiento del  asegurado (aaaa -mm-dd) : \n");
            fechaNacimiento = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Proporciona el género del asegurado: \n");
            genero = Poliza.validarSexo(Console.ReadLine());

            PolizaResultado pr = new PolizaResultado();
            pr = Poliza.Calcular(inicioVigencia, ttp, tiempo, sumaAsegurada, fechaNacimiento, genero);

            Console.WriteLine($"La Póliza vencerá el : {pr.fechaTermino.ToShortDateString()} \n" +
                $"La prima a pagar es de: {pr.prima.ToString("C2")} \n");

        }
    }
}
