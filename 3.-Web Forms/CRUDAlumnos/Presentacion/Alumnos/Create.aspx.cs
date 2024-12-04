using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Entidades;

namespace Presentacion.Alumnos
{
    public partial class Create : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NAlumno negAlumno = new NAlumno();
            Alumno alu = new Alumno();

            alu.nombre = "Pedrito";
            alu.pApellido = "Alcachofas";
            alu.sApellido = "Martinez";
            alu.correo = "Pedrialcachofa@gmail.com";
            alu.telefono = "7731212235";
            alu.fNacimiento = DateTime.Now;
            alu.curp = "CURPSITO123";
            alu.sueldo = (decimal)20356.20;
            alu.idEstadoOrigen = 1;
            alu.idEstatus = 3;
            alu.id = 0;

            negAlumno.Agregar(alu);


        }
    }
}