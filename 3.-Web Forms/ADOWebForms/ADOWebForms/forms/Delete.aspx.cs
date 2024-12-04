using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADOWebForms.ADO;
using ADOWebForms.Entidades;

namespace ADOWebForms.forms
{
    public partial class Delete : System.Web.UI.Page
    {
        private ADOEstatusAlumno adoController = new ADOEstatusAlumno();
        private static int _idEstatus = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            int id = int.Parse(Request.QueryString["id"] ?? "1");
            List<EstatusAlumno> estaData = ObtenerEstatus();

            EstatusAlumno esta = estaData.First(est => est.id == id);
            lblId.Text = esta.id.ToString();
            lblNombre.Text = esta.nombre;
            lblClave.Text = esta.clave;

            _idEstatus = esta.id;
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            adoController.Eliminar(_idEstatus);
            Response.Redirect($"Index.aspx");
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