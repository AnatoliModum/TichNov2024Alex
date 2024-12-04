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
    public partial class Edit : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            int _id = int.Parse(Request.QueryString["id"] ?? "1");
            NAlumno negAlum = new NAlumno();
            Alumno dataAlu = negAlum.Consultar(_id);
            
            dataAlu.telefono = "7731212299" ;   

            negAlum.Actualizar(dataAlu);
        }
    }
}