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

            fillData();

            //NAlumno dataNeg = new NAlumno();
            //Alumno aluList = new Alumno();

            //aluList = dataNeg.Consultar(int.Parse(Request.QueryString["id"] ?? "1"));

        }

        public void fillData()
        {
            Alumno alumno = new Alumno();
            NAlumno dataNeg = new NAlumno();

            alumno = dataNeg.Consultar(int.Parse(Request.QueryString["id"] ?? "1"));

            lblId.Text = alumno.id.ToString();
            lblNombre.Text = alumno.nombre;
            lblPApe.Text = alumno.pApellido;
            lblSApe.Text = alumno.sApellido;
            lblCorreo.Text = alumno.correo;
            lblTelefono.Text = alumno.telefono;
            lblFNaci.Text = alumno.fNacimiento.ToString("dd/MM/yyyy");
            lblCurp.Text = alumno.curp;
            lblSueldo.Text = alumno.sueldo.ToString("C2");

            FillDDLById(alumno.idEstatus,alumno.idEstadoOrigen);

        }
        public void FillDDLById(int idEstatus, int idEstado)
        {
            NEstatusAlumno negEstaAlu = new NEstatusAlumno();
            List<EstatusAlumno> estaAluList = negEstaAlu.Consultar();
            estaAluList.Add( new EstatusAlumno() { id = 0, nombre = "Seleccione un estatus", clave = ""} ); 

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
    }
}