using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoVenta
{
    internal class Item : ItemBase
    {
        public Item(int _id, string _nombre, decimal _precio, int _cantidad) : base(_id, _nombre, _precio, _cantidad)
        {
           // Imprimir();
        }
        public Item() { //Imprimir();
                        }
        public override void Imprimir()
        {
            Console.WriteLine( $" {id} {nombre} | Precio: {precio} | Cantidad: {cantidad} | Subtotal: {SubTotal()}" +
                $"\nTotal: {Total()}" );
        }
    }
}
