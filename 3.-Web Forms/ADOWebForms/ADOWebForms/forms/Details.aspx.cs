using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADOWebForms.Entidades;
using ADOWebForms.ADO;

namespace ADOWebForms.forms
{
    public partial class Details : System.Web.UI.Page
    {
        private ADOEstatusAlumno adoController = new ADOEstatusAlumno();

        protected void Page_Load(object sender, EventArgs e)
        {
            int id = int.Parse(Request.QueryString["id"] ?? "1");
            List<EstatusAlumno> estaData = ObtenerEstatus();

            EstatusAlumno esta = estaData.First(est => est.id == id);
            lblId.Text = esta.id.ToString();
            lblNombre.Text = esta.nombre;
            lblClave.Text = esta.clave;

        }
        private List<EstatusAlumno> ObtenerEstatus()
        {
            List<EstatusAlumno> dataEsta = new List<EstatusAlumno>();

            try
            {
                dataEsta = adoController.Consultar();
            }
            catch (Exception ex)
            {
                string script = string.Format("alert('Error: {0} ');", ex.Message);
                ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
            }

            return dataEsta;
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect($"Index.aspx");
        }
    }
}