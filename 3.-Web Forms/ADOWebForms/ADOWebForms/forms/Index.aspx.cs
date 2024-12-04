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
    public partial class Index : System.Web.UI.Page
    {
        private ADOEstatusAlumno adoController = new ADOEstatusAlumno();
        protected void Page_Load(object sender, EventArgs e)
        {
            List<EstatusAlumno> dataEstatus = ObtenerEstatus();
            Exception exGlob;

            if (!IsPostBack)
            {
                ddlEstatus.DataSource = dataEstatus;
                ddlEstatus.DataTextField = "nombre";
                ddlEstatus.DataValueField = "id";
                ddlEstatus.DataBind();
            }
        }

        private List<EstatusAlumno> ObtenerEstatus()
        {
            List<EstatusAlumno> dataEsta = new List<EstatusAlumno>();

            try
            {
              dataEsta   = adoController.Consultar();
            }
            catch(Exception ex)
            {
                string script = string.Format("alert('Error: {0} ');", ex.Message);
                ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
            }
            
            return dataEsta;
        }
        protected void btnDetalles_Click(object sender, EventArgs e)
        {
            int id = int.Parse(ddlEstatus.SelectedValue);
            Response.Redirect($"Details.aspx?id={id}");
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(ddlEstatus.SelectedValue);
            Response.Redirect($"Delete.aspx?id={id}");
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect($"Create.aspx");
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(ddlEstatus.SelectedValue);
            Response.Redirect($"Edit.aspx?id={id}");
        }
    }
}