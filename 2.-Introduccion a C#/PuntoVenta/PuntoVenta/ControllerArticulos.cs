using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PuntoVenta
{
    internal class ControllerArticulos
    {
        public static List<ItemBase> articulosBase = new List<ItemBase>();

        public static List<EntidadArticulo> CargarListArticulos()
        {
            string path = @"C:\Users\Tichs\Documents\PracticasNov\Semana2_Net\Practica_1\PuntoVenta\PuntoVenta\Articulos.json";
            List<EntidadArticulo> articulos = new List<EntidadArticulo>();

            try
            {
                using (StreamReader archivito = File.OpenText(path))
                {
                    var json = archivito.ReadToEnd();
                    articulos = JsonConvert.DeserializeObject<List<EntidadArticulo>>(json);
                }
            }
            catch
            {
                Console.WriteLine("Error al obtener lista de alumnos");
            }



            return articulos;

        }

        public void IniciarVenta()
        {
            bool continuarVenta = true;
            EntidadArticulo articuloType = new EntidadArticulo();
            string val = "";
            int id = 0;
            int cantidad = 0;


            while (continuarVenta)
            {
                id = 0;
                cantidad = 0;

                Console.WriteLine("Ingrese el Id del Articulo y cantidad del artículo, para Terminar la venta TV.");
                val = Console.ReadLine().ToUpper();
                continuarVenta = ContinuarVenta(val);
                if (continuarVenta & validarDatos(val))
                {
                    id = EsplitearDatos(val)[0];
                    cantidad = EsplitearDatos(val)[1];
                    articuloType = buscarArticulo(id);
                    AgregarArticulo(articuloType, cantidad);
                }
            }

            TicketFinal();
        }
        public static void AgregarArticulo(EntidadArticulo arti, int cantidad)
        {
            String telefono = "";
            String compañia = "";
            decimal comision = 0;
            decimal descuento = 0;

            switch (arti.tipo)
            {
                case 1:
                    Item artiNorm = new Item(arti.id, arti.nombre, arti.precio, cantidad);
                    articulosBase.Add(artiNorm);
                    artiNorm.Imprimir();
                        break;
                case 2:
                    Console.WriteLine( "Ingrese el decuento :" );
                    descuento = decimal.Parse(Console.ReadLine());
                    ItemDescuento artiDes = new ItemDescuento(arti.id, arti.nombre, arti.precio, cantidad, descuento);
                    articulosBase.Add(artiDes);
                    artiDes.Imprimir();
                    break;
                case 3:
                    Console.WriteLine("Proporcione el Teléfono: \n");
                    telefono = Console.ReadLine();
                    Console.WriteLine("Proporcione la compañía: \n");
                    compañia = Console.ReadLine();
                    Console.WriteLine("Proporcione la comisión: \n");
                    comision = decimal.Parse(Console.ReadLine());
                    ItemTA artiTA = new ItemTA(arti.id, arti.nombre, arti.precio, cantidad, telefono, compañia, comision );
                    articulosBase.Add(artiTA);
                    artiTA.Imprimir();
                    break;
            }
        }
        public static int[] EsplitearDatos(String articulo)
        {
            int[] datos = new int[2];
            string[] partes = articulo.Split(' ');

            datos[0] = int.Parse(partes[0]);
            datos[1] = int.Parse(partes[1]);

            return datos;
        }
        public static bool validarDatos(String venta)
        {
            venta = venta.Trim();

            if (venta.Equals("TV")) { return false; }

            string[] partes = venta.Split(' ');

            if (partes.Length == 2)
            {
                if (int.TryParse(partes[0], out int id) && int.TryParse(partes[1], out int cantidad))
                {
                    return true;
                }
            }
            else { return false; }

            return false;

        }
        public static bool ContinuarVenta(String venta)
        {
            venta = venta.Trim();

            if (venta.Equals("TV")) { return false; }

            string[] partes = venta.Split(' ');

            if (partes.Length == 2)
            {
                if (int.TryParse(partes[0], out int id) && int.TryParse(partes[1], out int cantidad))
                {
                    return true;
                }
            } else { Console.WriteLine( "Ingrese una entrada valida" ); Console.ReadKey(); }
            
            return true;

        } 
        public static EntidadArticulo buscarArticulo(int id)
        {
            List<EntidadArticulo> articuloFinder = CargarListArticulos();
            EntidadArticulo findQuery = (from art in articuloFinder
                            where art.id == id
                            select art).ToList()[0];
            return findQuery;
        }
        public static void TicketFinal()
        {
            decimal totalPagar = 0;
            decimal descuento = 0;

            Console.Clear();
            

            foreach (var articulosTotales in articulosBase)
            {
                articulosTotales.Imprimir();
            }

            Console.WriteLine( $"\n\n\n\n Total a pagar: {articulosBase.Sum(x => x.Total()).ToString("C2")}" );

        }

    }
}
