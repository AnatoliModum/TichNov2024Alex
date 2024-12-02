using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    internal class OperacionesLINQ
    {
        public static void CargarLists()
        {

            Consultas();
            Console.ReadKey();
        }
        public static List<Alumno> CargarListsAlumnos()
        {
            string path = @"C:\Users\Tichs\Documents\PracticasNov\Semana2_Net\Practica_1\LINQ\LINQ\Alumnos.json";
            List<Alumno> alumnos = new List<Alumno>();

            try
            {
                using (StreamReader archivito = File.OpenText(path)) {
                    var json = archivito.ReadToEnd();
                    alumnos = JsonConvert.DeserializeObject<List<Alumno>>(json);
                }
            }
            catch
            {
                Console.WriteLine("Error al obtener lista de alumnos");
            }

            
            
            return alumnos;

        }
        public static List<Estado> CargarListsEstados()
        {
            string path = @"C:\Users\Tichs\Documents\PracticasNov\Semana2_Net\Practica_1\LINQ\LINQ\Estados.json";
            List<Estado> estados = new List<Estado>();

            try
            {
                using (StreamReader archivito = File.OpenText(path))
                {
                    var json = archivito.ReadToEnd();
                    estados = JsonConvert.DeserializeObject<List<Estado>>(json);
                }
            }
            catch
            {
                Console.WriteLine("Error al obtener lista de alumnos");
            }



            return estados;
        }
        public static List<Estatus> CargarListsEstatus()
        {
            string path = @"C:\Users\Tichs\Documents\PracticasNov\Semana2_Net\Practica_1\LINQ\LINQ\Estatus.json";
            List<Estatus> estatuses = new List<Estatus>();

            try
            {
                using (StreamReader archivito = File.OpenText(path))
                {
                    var json = archivito.ReadToEnd();
                    estatuses = JsonConvert.DeserializeObject<List<Estatus>>(json);
                }
            }
            catch
            {
                Console.WriteLine("Error al obtener lista de alumnos");
            }



            return estatuses;
        }
        public static List<ItemISR> CargarListsTablaISR()
        {
            string[,] datos = new string[21, 6];
            string path = @"C:\Users\Tichs\Documents\PracticasNov\Semana2_Net\Practica_1\LINQ\LINQ\ISR.csv";
            string lineaLectura;
            int fila = 0;
            List<ItemISR> isrList = new List<ItemISR> ();
            ItemISR itemISR = new ItemISR();

            try
            {
                using (StreamReader archivo = new StreamReader(path))
                {
                    while ((lineaLectura = archivo.ReadLine()) != null && fila < 21)
                    {
                        string[] campos = lineaLectura.Split(',');
                        for (int columna = 0; columna < 6; columna++)
                        {
                            datos[fila, columna] = campos[columna];
                        }
                        fila++;
                    }
                }
            }
            catch
            {
                Console.WriteLine("Error al leer el archivo ISR");
            }

            for ( int i = 0; i <= 20; i++ )
            {
                itemISR = new ItemISR ();
                itemISR.limInf = decimal.Parse(datos[i,1]);
                itemISR.limSup = decimal.Parse(datos[i, 2]);
                itemISR.cuotaFija = decimal.Parse(datos[i, 3]);
                itemISR.porExced = decimal.Parse(datos[i, 4]);
                itemISR.subsidio = decimal.Parse(datos[i, 5]);

                isrList.Add(itemISR);
            }

            return isrList;
        }


        public static void Consultas()
        {
            List<Estado> tableEstados = CargarListsEstados();
            List<Alumno> tableAlumno = CargarListsAlumnos();
            List<Estatus> tableEstatus = CargarListsEstatus();
            List<ItemISR> tableISR = CargarListsTablaISR();

            var queryEstados = from estados in tableEstados where estados.id == 5 select estados;
            foreach (var estadosRes in queryEstados)
            {
                Console.WriteLine($"Estados con id 5: {estadosRes.nombre}");
            }



            var queryAlumno = from alucno in tableAlumno where alucno.idEstado == 29 | alucno.idEstado == 13 orderby alucno.nombre ascending select alucno;
            Console.WriteLine("\n\n\n\n\nAlumnos con idEstado 29 y 13: \n");
            foreach (var alumnosRes in queryAlumno)
            {
                Console.WriteLine($"{alumnosRes.nombre} -> idEstado: {alumnosRes.idEstado}");
            }



            var queryAlumno2 = from alucno in tableAlumno where (alucno.idEstado == 19 | alucno.idEstado == 20) & (alucno.idEstatus == 4 | alucno.idEstatus == 5) select alucno;
            Console.WriteLine("\n\n\n\n\nAlumnos con idEstado 19 y 20 y con idEstatus 4 o 5: \n");
            foreach (var alumnosRes in queryAlumno2)
            {
                Console.WriteLine($"{alumnosRes.nombre} -> idEstado: {alumnosRes.idEstado} -> idEstatus: {alumnosRes.idEstatus}");
            }



            queryAlumno = from alucno in tableAlumno where alucno.calificacion >= 6 orderby alucno.calificacion descending select alucno;
            Console.WriteLine("\n\n\n\n\nAlumnos con calificacion igual o mayor de 6: \n");
            foreach (var alumnosRes in queryAlumno)
            {
                Console.WriteLine($"{alumnosRes.nombre} ->  Calificacion: {alumnosRes.calificacion}");
            }



            decimal promedioAlumnos = 0;
            int contador = 0;
            var queryAlumno3 = from alucno in tableAlumno select alucno;
            foreach (var alumnosRes in queryAlumno3)
            {
                promedioAlumnos = promedioAlumnos + alumnosRes.calificacion; contador++;
            } promedioAlumnos = promedioAlumnos / contador;
            Console.WriteLine($"\n\n\n\n\nPromedio de calificacion de los alumnos: {promedioAlumnos}\n");



            var queryAlumno4 = from alucno in tableAlumno select alucno;
            bool val10 = false;
            bool val67 = false;
            foreach (var alumnosRes in queryAlumno4)
            {
                if (alumnosRes.calificacion == 10) { val10 = true; }
                if (alumnosRes.calificacion > 7 | alumnosRes.calificacion < 6) { val67 = true; }
            }
            if (val10 & val67) { Console.WriteLine($"\n\n\n\n\n Ninguna condicion aplicable para el aumento de calificaciones \n"); }
            else if ( !val10 ){
                foreach (var alumnosRes in queryAlumno4)
                {
                    Console.WriteLine($"Alumno: {alumnosRes.nombre}  ->  Calificacion:  {(alumnosRes.calificacion + 1)}");
                }
            }else if (!val67)
            {
                foreach (var alumnosRes in queryAlumno4)
                {
                    Console.WriteLine($"Alumno: {alumnosRes.nombre}  ->  Calificacion:  {(alumnosRes.calificacion + 2)}");
                }
            }



            var resulAluEst = tableAlumno.Join(tableEstados,
                                 alucno => alucno.idEstado,
                                 esta => esta.id,
                                 (alucno, esta) => new { tableAlumno = alucno, tableEstados = esta })
                                 .Where(alu_esta => alu_esta.tableAlumno.idEstatus == 3);

            Console.WriteLine("\n\n\n\n\nAlumnos con estatus 3: \n");
            foreach (var alumnosRes in resulAluEst)
            {
                Console.WriteLine($"idAlumno : {alumnosRes.tableAlumno.id} ->  Nombre : {alumnosRes.tableAlumno.nombre}  ->  Estado: {alumnosRes.tableEstados.nombre} ");
            }



            /*var resulAluEsta = tableAlumno.Join(tableEstatus,
                                 alucno => alucno.idEstatus,
                                 esta => esta.id,
                                 (alucno, esta) => new { tableAlumno = alucno, tableEstatus = esta })
                                 .Where(alu_esta => alu_esta.tableAlumno.idEstatus == 2).OrderBy(alu_esta => alu_esta.tableAlumno.nombre);*/
            var resulAluEsta = from alu in tableAlumno
                                join esta in tableEstatus on alu.idEstatus equals esta.id
                                where esta.id == 2
                                orderby alu.nombre
                                select new { nameAlumno = alu.nombre , idAlumno = alu.id , nameEstado = esta.nombre , idEstado = esta.id };

            Console.WriteLine("\n\n\n\n\nAlumnos con estatus 2: \n");
            if (resulAluEsta.Count() != 0) {

                foreach (var alumnosRes in resulAluEsta)
                {
                    Console.WriteLine($"idAlumno : {alumnosRes.idAlumno} ->  Nombre : {alumnosRes.nameAlumno}  ->  Estado: {alumnosRes.nameEstado}  ->  idEstatus:  {alumnosRes.idEstado}");
                }

            } else { Console.WriteLine("No se encontraron alumnos con dichas condiciones "); }


            //7.2.1.9
            Console.WriteLine("\n\n\n\n\nMostar en la consola los siguientes datos, de aquellos alumnos cuyo estatus sea mayor a 2, ordenado por nombre del estatus");
            var resulAluEstaEsta = from alu in tableAlumno
                                   join estado in tableEstados on alu.idEstado equals estado.id
                                   join estatus in tableEstatus on alu.idEstatus equals estatus.id
                                   where alu.idEstatus > 2
                                   orderby estatus.nombre ascending
                                   select new { idAlumno = alu.id, Nombre = alu.nombre, Estado_ = estado.nombre, Status = estatus.nombre };
            if (resulAluEstaEsta.Count() != 0)
            {
                foreach (var alumnosRes in resulAluEstaEsta)
                {
                    Console.WriteLine($"idAlumno: {alumnosRes.idAlumno}  ->  Nombre: {alumnosRes.Nombre}  ->  Estado: {alumnosRes.Estado_}  ->  Estatus: {alumnosRes.Status}");
                }
            }
            else { Console.WriteLine("No se encontraron alumnos con dichas condiciones "); }; 




            // Calculo ISR
            decimal sueldoQuincenal = 22000 / 2;
            decimal isrTotal = 0;
            var resulISR = from isrRes in tableISR
                           where isrRes.limInf < sueldoQuincenal & isrRes.limSup > sueldoQuincenal
                           select isrRes;

            foreach (var isrRes in resulISR)
            {
                isrTotal = sueldoQuincenal - isrRes.limInf;
                isrTotal = (isrTotal * isrRes.porExced) / 100;
                isrTotal = isrTotal + isrRes.cuotaFija;
                isrTotal = isrTotal - isrRes.subsidio;
            }
            Console.WriteLine( $"\n\n\n\n\nEl total a pagar sobre el sueldo de {sueldoQuincenal} es de :  {isrTotal.ToString("C2")}" );

        }

    }
}
