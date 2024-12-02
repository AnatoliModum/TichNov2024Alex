using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoVenta
{
    internal class ItemDescuento : ItemBase
    {
        private decimal impDescuento { 
            get { return (SubTotal() * descuento) / 100;  } 
        }
        public decimal descuento { get; set; }

        public ItemDescuento()
        {
           // Imprimir();
        }

        public ItemDescuento(int _id, string _nombre, decimal _precio, int _cantidad, decimal descuento) : base(_id, _nombre, _precio, _cantidad)
        {
            this.descuento = descuento;
            //Imprimir();
        }

        public override void Imprimir()
        {
            decimal totalImp = Total();
            Console.WriteLine($" {id} {nombre} | Precio: {precio} | Cantidad: {cantidad} | Subtotal: {SubTotal()}" +
                $"\n Descuento: {impDescuento} ( {descuento} %)"+
                $"\nTotal: {totalImp}");
        }

        public override decimal Total()
        {
            return SubTotal()-impDescuento;
        }

    }
}
