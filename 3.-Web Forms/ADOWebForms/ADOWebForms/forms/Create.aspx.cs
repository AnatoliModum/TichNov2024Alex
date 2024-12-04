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
    public partial class Create : System.Web.UI.Page
    {
        private ADOEstatusAlumno adoController = new ADOEstatusAlumno();

        protected void Page_Load(object sender, EventArgs e)
        {
            boxId.Enabled = false;
            boxId.Text = "Asignado Automaticamente";
        }
        private void AgregarEstatus()
        {
            EstatusAlumno estaNew = new EstatusAlumno();
            int newId = 0;

            estaNew.id = 0;
            estaNew.nombre = boxNombre.Text;
            estaNew.clave = boxClave.Text;

            try
            {
                newId = adoController.Agregar(estaNew);
                lblIdNuevo.Text = $"El nuevo id de su estatus es: {newId}";
            }
            catch
            {

            }

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            if (boxNombre.Text.Trim().Equals("") && boxClave.Text.Trim().Equals(""))
            {
                lblIdNuevo.Text = "Valide que lleno todos los campos";
            }
            else
            {
                AgregarEstatus();
            }
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect($"Index.aspx");
        }
    }
}