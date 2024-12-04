using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocio;

namespace Presentacion.Alumnos
{
    public partial class Details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NAlumno dataNeg = new NAlumno();
            Alumno aluList = new Alumno();

            aluList = dataNeg.Consultar(int.Parse(Request.QueryString["id"] ?? "1"));

        }
    }
}