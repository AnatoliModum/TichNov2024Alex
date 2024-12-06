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

        protected void btnCalcularIMMS_Click(object sender, EventArgs e)
        {

            //Alumno alumno = new Alumno();
            NAlumno dataNeg = new NAlumno();
            AportacionesIMSS dataIMMS = dataNeg.CalcularIMSS(int.Parse(Request.QueryString["id"] ?? "1"));

            lblmEnfMat.Text = dataIMMS.enfermedadMaternidad.ToString("C2");
            lblmInvVid.Text = dataIMMS.invalidezVida.ToString("C2");
            lblmRet.Text = dataIMMS.retiro.ToString("C2");
            lblmCes.Text = dataIMMS.cesantia.ToString("C2");
            lblmInfo.Text = dataIMMS.infonavit.ToString("C2");

            string script = @"<script type='text/javascript'> $(function() { $('#ModalIMSS').modal('show'); }); </script>";
            ScriptManager.RegisterStartupScript(this,GetType(),"MuestraModal",script,false);

            //String lblDataString = $"" +
            //    $"Enfermedad Maternidad: {dataIMMS.enfermedadMaternidad.ToString("C2")} |\n" +
            //    $"Invalidez Vida: {dataIMMS.invalidezVida.ToString("C2")} |\n" +
            //    $"Retiro: {dataIMMS.retiro.ToString("C2")} |\n" +
            //    $"Cesantia: {dataIMMS.cesantia.ToString("C2")} |\n" +
            //    $"Infonavit: {dataIMMS.infonavit.ToString("C2")}";

        }

        protected void btnCalcularISR_Click(object sender, EventArgs e)
        {
            //lblData.Visible = true;
            //btnHide.Visible = true;

            //Alumno alumno = new Alumno();
            //NAlumno dataNeg = new NAlumno();
            //ItemTablaISR dataIsr = dataNeg.CalcularIsr(int.Parse(Request.QueryString["id"] ?? "1"));  // <---  Resolver salario 

            //String lblDataString = $"" +
            //    $"Limite Inferior: {dataIsr.limiteInferior.ToString("C2")} |\n" +
            //    $"Limite Superior: {dataIsr.limiteSuperior.ToString("C2")} |\n" +
            //    $"Cuota Fija: {dataIsr.cuotaFija.ToString("C2")} |\n" +
            //    $"Excedente: {dataIsr.excedente.ToString("C2")} |\n" +
            //    $"Subsidio: {dataIsr.subsidio.ToString("C2")} |\"" +
            //    $"ISR: {dataIsr.ISR.ToString("C2")}";

            //lblData.Text = lblDataString;

        }

        //protected void btnHide_Click(object sender, EventArgs e)
        //{
        //    lblData.Visible = false;
        //    btnHide.Visible = false;
        //}
    }
}