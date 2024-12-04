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
            if (!IsPostBack)
            {
                FillDataById(int.Parse(Request.QueryString["id"] ?? "1"));
            }
        }

        public void FillDataById(int _id)
        {
            NAlumno negAlumno = new NAlumno();
            Alumno alu = negAlumno.Consultar(_id);

            txtId.Enabled = false;

            txtId.Text = alu.id.ToString();
            txtNombre.Text = alu.nombre;
            txtPApe.Text = alu.pApellido;
            txtSApe.Text = alu.sApellido;
            txtCorreo.Text = alu.correo;
            txtTelefono.Text = alu.telefono;
            txtFNaci.Text = alu.fNacimiento.ToString("yyyy-MM-dd");
            txtCurp.Text = alu.curp;
            txtSueldo.Text = alu.sueldo.ToString("F2");
            FillDDLById(alu.idEstatus , alu.idEstadoOrigen);
        }
        public void FillDDLById(int idEstatus, int idEstado)
        {
            NEstatusAlumno negEstaAlu = new NEstatusAlumno();
            List<EstatusAlumno> estaAluList = negEstaAlu.Consultar();
            estaAluList.Add(new EstatusAlumno() { id = 0, nombre = "Seleccione un estatus", clave = "" });

            ddlEstatus.DataSource = estaAluList;
            ddlEstatus.DataTextField = "nombre";
            ddlEstatus.DataValueField = "id";
            ddlEstatus.DataBind();
            ddlEstatus.SelectedValue = idEstatus.ToString();

            //---------------------------------------------------------------------------------------------------

            NEstado negEsta = new NEstado();
            List<Estado> estaList = negEsta.Consultar();
            estaList.Add(new Estado() { id = 0, nombre = "Seleccione un estatus" });

            ddlEstado.DataSource = estaList;
            ddlEstado.DataTextField = "nombre";
            ddlEstado.DataValueField = "id";
            ddlEstado.DataBind();
            ddlEstado.SelectedValue = idEstado.ToString();

        }
        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            NAlumno negAlumno = new NAlumno();
            Alumno alu = new Alumno();

            alu.id = int.Parse(txtId.Text);
            alu.nombre = txtNombre.Text;
            alu.pApellido = txtPApe.Text;
            alu.sApellido = txtSApe.Text;
            alu.correo = txtCorreo.Text;
            alu.telefono = txtTelefono.Text;
            alu.fNacimiento = DateTime.Parse(txtFNaci.Text);
            alu.curp = txtCurp.Text;
            alu.sueldo = decimal.Parse(txtSueldo.Text);
            alu.idEstadoOrigen = int.Parse(ddlEstado.SelectedValue);
            alu.idEstatus = int.Parse(ddlEstatus.SelectedValue);

            try
            {
                negAlumno.Actualizar(alu);
            }
            catch (Exception ex)
            {
                lblEx.Text = "Error al Actualizar: " + ex;
            }
        }
    }
}