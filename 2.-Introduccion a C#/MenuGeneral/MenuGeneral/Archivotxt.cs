using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuGeneral
{
    internal class Archivotxt
    {

        public static void MostrarTxt()
        {
            string lineaLectura;

            try
            {
                StreamReader archivo = new StreamReader(@"" + ElegirArchivo());
                lineaLectura = archivo.ReadToEnd();

                Console.WriteLine(lineaLectura);
            }
            catch
            {
                Console.WriteLine("Archivo no encontrado");
            }

        }
        public static void MostrarCSV()
        {
            string lineaLectura;
            string[] datos;

            try
            {
                StreamReader archivo = new StreamReader(@"" + ElegirArchivo());
                lineaLectura = archivo.ReadToEnd();

                datos = lineaLectura.Split(',');

                foreach (var word in datos)
                {
                    Console.WriteLine("\n" + word + "\n");
                }


            }
            catch
            {
                Console.WriteLine("Archivo no encontrado \n");
            }

        }
        public static string[] ObtenerDatos(String Path)
        {
            string lineaLectura;
            string[] datos = new string[1];

            try
            {
                StreamReader archivo = new StreamReader(@""+Path);
                lineaLectura = archivo.ReadToEnd();

                datos = lineaLectura.Split(',');

                return datos;
            }
            catch
            {
                Console.WriteLine("Archivo no encontrado \n");
            }
            return datos;
        }
        public static string ElegirPath()
        {
            string path = "";

            try
            {

                Console.WriteLine("Ingresa la direccion y nombre de tu archivo: \n");
                path = Console.ReadLine();

                return path;
            }
            catch
            {
                Console.WriteLine("Archivo no encontrado");
            }

            return path;

        }
        public static string ElegirArchivo()
        {
            string path = "";

            try
            {

                Console.WriteLine("Ingresa el nombre de tu archivo: \n");
                path = @"C:\Users\Tichs\Documents\PracticasNov\Semana2_Net\Practica_1\MenuGeneral\MenuGeneral\" + Console.ReadLine();

                return path;
            }
            catch
            {
                Console.WriteLine("Archivo no encontrado");
            }

            return path;

        }
        public static void Presentacion()
        {
            int operacion;
            bool continuar = true;

            while (continuar)
            {
                Console.WriteLine("Solicite una operacion: \n" +
                "1.- Mostrar un Txt \n" +
                "2.- Mostrar un CSV \n" +
                "3.- EscribirTxt \n" +
                "4.- Regresar \n");
                operacion = int.Parse(Console.ReadLine());

                switch (operacion)
                {
                    case 1:
                        Archivotxt.MostrarTxt();
                        break;
                    case 2:
                        Archivotxt.MostrarCSV();
                        break;
                    case 3:
                        Archivotxt.ValidacionArchivo();
                        break;
                    case 4:
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("Ingrese una opcion valida \n");
                        break;
                }
            }
        }
        public static void EscribirTxt(string namePath, bool nuevo, string encoding)
            {
            try
            {
                Encoding codificacion;
                switch (encoding.ToUpper())
                {
                    case "UTF7":
                        codificacion = Encoding.UTF7;
                        break;
                    case "UTF8":
                        codificacion = Encoding.UTF8;
                        break;
                    case "UNICODE":
                        codificacion = Encoding.Unicode;
                        break;
                    case "UTF32":
                        codificacion = Encoding.UTF32;
                        break;
                    case "ASCII":
                        codificacion = Encoding.ASCII;
                        break;
                    default:
                        throw new ArgumentException("Codificación no soportada.");
                }


                using (StreamWriter archivo = new StreamWriter(namePath, nuevo, codificacion))
                {
                    bool agregarOtro = true;

                    while (agregarOtro)
                    {

                        Console.WriteLine("Ingrese el nombre del alumno:");
                        string nombre = Console.ReadLine();
                        Console.WriteLine("Ingrese el primer apellido del alumno:");
                        string primerApellido = Console.ReadLine();
                        Console.WriteLine("Ingrese el segundo apellido del alumno:");
                        string segundoApellido = Console.ReadLine();
                        Console.WriteLine("Ingrese la edad del alumno:");
                        string edad = Console.ReadLine();
                        Console.WriteLine("Ingrese el estado del alumno:");
                        string estado = Console.ReadLine();


                        archivo.WriteLine($"{nombre},{primerApellido},{segundoApellido},{edad},{estado}");


                        Console.WriteLine("¿Desea agregar otro alumno? (s/n):");
                        string respuesta = Console.ReadLine();
                        agregarOtro = respuesta.ToLower() == "s";
                    }
                }
            }
            catch
            {
                Console.WriteLine("Error al crear");
            } 


                
                }
        public static void ModificarTxt(string namePath, bool nuevo, string encoding)
        {
            try
            {
                Encoding codificacion;
                switch (encoding.ToUpper())
                {
                    case "UTF7":
                        codificacion = Encoding.UTF7;
                        break;
                    case "UTF8":
                        codificacion = Encoding.UTF8;
                        break;
                    case "UNICODE":
                        codificacion = Encoding.Unicode;
                        break;
                    case "UTF32":
                        codificacion = Encoding.UTF32;
                        break;
                    case "ASCII":
                        codificacion = Encoding.ASCII;
                        break;
                    default:
                        throw new ArgumentException("Codificación no soportada.");
                }


                using (StreamWriter archivo = new StreamWriter(namePath, !nuevo, codificacion))
                {
                    bool agregarOtro = true;
                    string[] datos = ObtenerDatos(@""+namePath);

                    foreach (var registo in datos)
                    {
                        archivo.WriteLine($"{registo}");
                    }


                    while (agregarOtro)
                    {

                        Console.WriteLine("Ingrese el nombre del alumno:");
                        string nombre = Console.ReadLine();
                        Console.WriteLine("Ingrese el primer apellido del alumno:");
                        string primerApellido = Console.ReadLine();
                        Console.WriteLine("Ingrese el segundo apellido del alumno:");
                        string segundoApellido = Console.ReadLine();
                        Console.WriteLine("Ingrese la edad del alumno:");
                        string edad = Console.ReadLine();
                        Console.WriteLine("Ingrese el estado del alumno:");
                        string estado = Console.ReadLine();


                        archivo.WriteLine($"{nombre},{primerApellido},{segundoApellido},{edad},{estado}");


                        Console.WriteLine("¿Desea agregar otro alumno? (s/n):");
                        string respuesta = Console.ReadLine();
                        agregarOtro = respuesta.ToLower() == "s";
                    }
                }
            }
            catch
            {
                Console.WriteLine("Error al crear");
            }



        }
        public static void ValidacionArchivo()
        {
            bool nuevo = false;
            string fileName = "";
            string respuesta = "";
            bool comprobador = true;
            int codec;
            string codecString = "";
            string pathDir = "";
            string direcCom = "";

            while (comprobador)
            {
                Console.WriteLine("Desea crear un nuevo archivo? \n (Y/N) : ");
                respuesta = Console.ReadLine();
                if (respuesta.ToUpper() == "Y" || respuesta.ToUpper() == "N") { if (respuesta.ToUpper() == "Y") { nuevo = true; comprobador = false; } else { nuevo = false; comprobador = false; } } else { Console.WriteLine("Opcion no valida"); }
            }

            Console.WriteLine("\nIngrese el nombre de su archivo : \n");
            fileName = Console.ReadLine();

            Console.WriteLine("\nIngrese el directorio de su archivo : \n");
            pathDir = Console.ReadLine();

            direcCom = @"" + pathDir + "\\" + fileName;

            Console.WriteLine("\nSeleccione un encoding : \n" +
                "1.- UTF7\n" +
                "2.- UTF8\n" +
                "3.- UNICODE\n" +
                "4.- UTF32\n" +
                "5.- ASCII\n");
            codec = int.Parse(Console.ReadLine());

            switch (codec)
            {
                case 1:
                    codecString = "UTF7";
                    break;
                case 2:
                    codecString = "UTF8";
                    break;
                case 3:
                    codecString = "UNICODE";
                    break;
                case 4:
                    codecString = "UTF32";
                    break;
                case 5:
                    codecString = "ASCII";
                    break;
                default:
                    throw new ArgumentException("Codificación no soportada.");
            }

            if (nuevo)
            {
                Archivotxt.EscribirTxt(direcCom, nuevo, codecString);
            }
            else
            {
                Archivotxt.ModificarTxt(direcCom, nuevo, codecString);
            }
            

        }
    }
}
  