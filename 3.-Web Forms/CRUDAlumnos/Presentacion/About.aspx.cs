using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocio;

namespace Presentacion
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NAlumno negAlu = new NAlumno();

            lblTest.Text = negAlu.CalcularIMSS(1).infonavit.ToString();
        }

        
    }
}