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
    public partial class Edit : System.Web.UI.Page
    {
        private ADOEstatusAlumno adoController = new ADOEstatusAlumno();
        private int _id;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id;
                if (int.TryParse(Request.QueryString["id"], out id))
                {
                    fillBox(id);
                }
                else
                {
                    Response.Redirect("Index.aspx");
                }
            }
        }

        private EstatusAlumno ObtenerEstatus(int id)
        {
            EstatusAlumno dataEsta = null;
            try
            {
                dataEsta = adoController.Consultar(id);
            }
            catch (Exception ex)
            {
                string script = string.Format("alert('Error: {0} ');", ex.Message);
                ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
            }
            return dataEsta;
        }

        private void fillBox(int id)
        {
            EstatusAlumno estaData = new EstatusAlumno();

            estaData = ObtenerEstatus(id);
            if (estaData != null)
            {
                boxId.Text = estaData.id.ToString();
                boxNombre.Text = estaData.nombre;
                boxClave.Text = estaData.clave;
            }
            else
            {
                Response.Redirect("Index.aspx");
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            EstatusAlumno estaData = new EstatusAlumno();
            estaData.id = int.Parse(Request.QueryString["id"] ?? "1");

            try
            {
                estaData.clave = boxClave.Text;
                estaData.nombre = boxNombre.Text;

                adoController.Actualizar(estaData);
                Response.Redirect("Index.aspx");
            }
            catch (Exception ex)
            {
                string script = string.Format("alert('Error: {0} ');", ex.Message);
                ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
            }
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }
    }
}

