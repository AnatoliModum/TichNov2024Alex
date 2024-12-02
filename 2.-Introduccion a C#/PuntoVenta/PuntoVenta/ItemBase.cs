using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoVenta
{
    internal abstract class ItemBase
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public decimal precio { get; set; }
        public int cantidad { get; set; }

        public ItemBase(int _id, String _nombre, decimal _precio, int _cantidad)
        {
            this.id = _id;
            this.nombre = _nombre;
            this.precio = _precio;
            this.cantidad = _cantidad;
        }
        public ItemBase() { }
        public virtual decimal SubTotal()
        {
            return precio * cantidad;
        }
        public virtual decimal Total()
        {
            return precio * cantidad;
        }
        public abstract void Imprimir();
    }
}
