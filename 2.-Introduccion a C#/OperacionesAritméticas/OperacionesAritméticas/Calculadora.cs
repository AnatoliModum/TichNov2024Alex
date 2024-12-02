using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperacionesAritméticas
{
    internal class Calculadora
    {

        public static decimal sumar(decimal a, decimal b)
        {
            decimal resultado = a + b;

            return resultado;
        }

        public static decimal restar (decimal a, decimal b)
        {
            decimal resultado = a - b;

            return resultado;
        }

        public static decimal multiplicar(decimal a, decimal b)
        {
            decimal resultado = a * b;

            return resultado;
        }

        public static decimal dividir(decimal a, decimal b)
        {
            decimal resultado = a / b;

            return resultado;
        }

        public static decimal modulo(decimal a, decimal b)
        {
            decimal resultado = a % b;

            return resultado;
        }

        public static Resultado Simultaneas(decimal a, decimal b)
        {
            Resultado resultados = new Resultado();

            resultados.suma = Calculadora.sumar(a, b);
            resultados.resta = Calculadora.restar(a, b);
            resultados.multiplicacion = Calculadora.multiplicar(a, b);
            resultados.division = Calculadora.dividir(a, b);
            resultados.modulo = Calculadora.modulo(a, b);

            return resultados;
        }

        public static decimal Operacion(OperacionAritmetica ope)
        {
            decimal resultados = 0;

            switch (ope.operacion)
            {
                case tipoOperacion.suma: resultados =  Calculadora.sumar(ope.a, ope.b);
                    break;
                case tipoOperacion.resta: resultados = Calculadora.restar(ope.a, ope.b);
                    break;
                case tipoOperacion.multiplicacion: resultados = Calculadora.multiplicar(ope.a, ope.b);
                    break;
                case tipoOperacion.division: resultados = Calculadora.dividir(ope.a, ope.b);
                    break;
                case tipoOperacion.modulo: resultados = Calculadora.modulo(ope.a, ope.b);
                    break;
            }

            return resultados;

        }


        public static void Presentacion()
        {
            int contador = 0;
            OperacionAritmetica opa = new OperacionAritmetica();
            Resultado resul = new Resultado(); 

            Console.WriteLine("Solicite una operacion: \n");
            foreach (tipoOperacion opes in Enum.GetValues(typeof(tipoOperacion)))
            {
                Console.WriteLine("{0} .- {1} ", contador, opes);
                contador++;
            }

            tipoOperacion opes2 = (tipoOperacion)int.Parse(Console.ReadLine());

            opa.operacion = opes2;
            Console.WriteLine("Ingrese el valor de a: ");
            opa.a = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el valor de b: ");
            opa.b = int.Parse(Console.ReadLine());

            if(opa.operacion != tipoOperacion.todo)
            {
                Console.WriteLine("El resultado de su " + opa.operacion.ToString() + " es: " + Calculadora.Operacion(opa));
            }
            else
            {
                resul = Calculadora.Simultaneas(opa.a, opa.b);
                Console.WriteLine("El resultado de su suma es: " + resul.suma.ToString() + "\n");
                Console.WriteLine("El resultado de su resta es: " + resul.resta.ToString() + "\n");
                Console.WriteLine("El resultado de su multiplicacion es: " + resul.multiplicacion.ToString() + "\n");
                Console.WriteLine("El resultado de su division es: " + resul.division.ToString() + "\n");
                Console.WriteLine("El resultado de su modulo es: " + resul.modulo.ToString() + "\n");
            }


            Console.ReadKey();
        }


    }
}
