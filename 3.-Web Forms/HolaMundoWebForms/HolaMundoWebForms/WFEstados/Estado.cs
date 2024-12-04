using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HolaMundoWebForms.WFEstados
{
    public class Estado
    {
        public Estado()
        {
        }

        public Estado(int id, string nombre)
        {
            this.id = id;
            Nombre = nombre;
        }

        public int id { get; set; }
        public string Nombre { get; set; }
    }
}