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
    public partial class Delete : System.Web.UI.Page
    {

        NAlumno _dataNeg = new NAlumno();
        protected void Page_Load(object sender, EventArgs e)
        {
            fillData();
        }

        public void fillData()
        {
            Alumno alumno = new Alumno();
            NEstatusAlumno negEstaAlu = new NEstatusAlumno();
            NEstado negEsta = new NEstado();

            alumno = _dataNeg.Consultar(int.Parse(Request.QueryString["id"] ?? "1"));

            lblId.Text = alumno.id.ToString();
            lblNombre.Text = alumno.nombre;
            lblPApe.Text = alumno.pApellido;
            lblSApe.Text = alumno.sApellido;
            lblCorreo.Text = alumno.correo;
            lblTelefono.Text = alumno.telefono;
            lblFNaci.Text = alumno.fNacimiento.ToString("dd/MM/yyyy");
            lblCurp.Text = alumno.curp;
            lblSueldo.Text = alumno.sueldo.ToString("C2");
            lblEstado.Text = negEsta.Consultar(alumno.idEstadoOrigen).nombre;
            lblEstatus.Text = negEstaAlu.Consultar(alumno.idEstatus).nombre;
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(Request.QueryString["id"] ?? "-1");
            NAlumno negAlu = new NAlumno();

            negAlu.Eliminar(id);
        }
    }
}