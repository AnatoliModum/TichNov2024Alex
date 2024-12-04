using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADOWebForms.Entidades
{
    public class EstatusAlumno
    {
        public EstatusAlumno()
        {
        }

        public EstatusAlumno(int id, string nombre, string clave)
        {
            this.id = id;
            this.nombre = nombre;
            this.clave = clave;
        }

        public int id { get; set; }
        public string nombre { get; set; }
        public string clave { get; set; }
    }
}