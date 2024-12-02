using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoVenta
{
    internal class ItemTA : ItemBase
    {
        public String telefono { get; set; }
        public String compañia { get; set; }
        public decimal comision { get; set; }

        public ItemTA()
        {
           // Imprimir();
        }

        public ItemTA(int _id, string _nombre, decimal _precio, int _cantidad, String _telefono, string _compañia, decimal _comision) : base(_id, _nombre, _precio, _cantidad)
        {
            telefono = _telefono;
            compañia = _compañia;
            comision = _comision;
            //Imprimir();
        }

        public override void Imprimir()
        {
            decimal impTotal = Total();
            Console.WriteLine($" {id} {nombre} | Precio: {precio} | Cantidad: {cantidad} | Subtotal: {SubTotal()}" +
                $"\nTelefono: {telefono} | Compañia: {compañia} | Comision: {comision} " +
                $"\nTotal: {impTotal}");
        }

        public override decimal Total()
        {
            return SubTotal() + comision;
        }
    }
}
