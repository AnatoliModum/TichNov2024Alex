using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Alumno
    {
        public Alumno()
        {
        }

        public Alumno(int id, string nombre, string pApellido, string sApellido, string telefono, DateTime fNacimiento, string curp, decimal sueldo, int idEstadoOrigen, int idEstatus, string correo)
        {
            this.id = id;
            this.nombre = nombre;
            this.pApellido = pApellido;
            this.sApellido = sApellido;
            this.telefono = telefono;
            this.fNacimiento = fNacimiento;
            this.curp = curp;
            this.sueldo = sueldo;
            this.idEstadoOrigen = idEstadoOrigen;
            this.idEstatus = idEstatus;
            this.correo = correo;
        }

        public int id { get; set; }
        public string nombre { get; set; }
        public string pApellido { get; set; }
        public string sApellido { get; set; }
        public string telefono { get; set; }
        public DateTime fNacimiento { get; set; }
        public string curp { get; set; }
        public decimal sueldo { get; set; }
        public int idEstadoOrigen { get; set; }
        public int idEstatus { get; set; }
        public string correo { get; set; }
    }
}
