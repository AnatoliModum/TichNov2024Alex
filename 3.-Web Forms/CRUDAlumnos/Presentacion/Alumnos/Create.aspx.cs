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
    public partial class Create : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillDDL();
            }
            
            ////NAlumno negAlumno = new NAlumno();
            ////Alumno alu = new Alumno();

            ////alu.nombre = "Pedrito";
            ////alu.pApellido = "Alcachofas";
            ////alu.sApellido = "Martinez";
            ////alu.correo = "Pedrialcachofa@gmail.com";
            ////alu.telefono = "7731212235";
            ////alu.fNacimiento = DateTime.Now;
            ////alu.curp = "CURPSITO123";
            ////alu.sueldo = (decimal)20356.20;
            ////alu.idEstadoOrigen = 1;
            ////alu.idEstatus = 3;
            ////alu.id = 0;

            ////negAlumno.Agregar(alu);
        }

        public void FillDDL()
        {
            txtId.Text = "Asignado Automaticamente";
            txtId.Enabled = false;

            NEstatusAlumno negEstaAlu = new NEstatusAlumno();
            List<EstatusAlumno> estaAluList = negEstaAlu.Consultar();
            estaAluList.Add(new EstatusAlumno() { id = 0, nombre = "Seleccione un estatus", clave = "" });

            ddlEstatus.DataSource = estaAluList;
            ddlEstatus.DataTextField = "nombre";
            ddlEstatus.DataValueField = "id";
            ddlEstatus.DataBind();
            ddlEstatus.SelectedValue = "0";

            //---------------------------------------------------------------------------------------------------

            NEstado negEsta = new NEstado();
            List<Estado> estaList = negEsta.Consultar();
            estaList.Add(new Estado() { id = 0, nombre = "Seleccione un estatus" });

            ddlEstado.DataSource = estaList;
            ddlEstado.DataTextField = "nombre";
            ddlEstado.DataValueField = "id";
            ddlEstado.DataBind();
            ddlEstado.SelectedValue = "0";

        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                NAlumno negAlumno = new NAlumno();
                Alumno alu = new Alumno();

                alu.id = 0;
                alu.nombre = txtNombre.Text;
                alu.pApellido = txtPApe.Text;
                alu.sApellido = txtSApe.Text;
                alu.correo = txtCorreo.Text;
                alu.telefono = txtTelefono.Text;
                alu.fNacimiento = DateTime.Parse(txtFNaci.Text);
                alu.curp = txtCurp.Text.ToUpper();
                alu.sueldo = decimal.Parse(txtSueldo.Text);
                alu.idEstadoOrigen = int.Parse(ddlEstado.SelectedValue);
                alu.idEstatus = int.Parse(ddlEstatus.SelectedValue);

                try
                {
                    negAlumno.Agregar(alu);
                    //lblEx.Text = "El proceso fallo con exito";
                }
                catch (Exception ex)
                {
                    lblEx.Text = "Error al agregar: " + ex;
                }
            }
            
            
        }

        protected void cv2Curp_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string completeCurp = args.Value;
            string nameCurp = completeCurp.Substring(0, 4);
            string fechaCurp = completeCurp.Substring(4, 6);
            string sexoCurp = completeCurp.Substring(10, 1);
            string entidadCurp = completeCurp.Substring(11, 2);
            string consoCurp = completeCurp.Substring(13, 3);
            string randomNumCurp = completeCurp.Substring(16, 2);
            args.IsValid = false;

            if (!nameCurp.Any(char.IsDigit))
            {
                if (int.TryParse(fechaCurp, out int resu2))
                {
                    if (!sexoCurp.Any(char.IsDigit))
                    {
                        if (!entidadCurp.Any(char.IsDigit))
                        {
                            if (!consoCurp.Any(char.IsDigit))
                            {
                                if (int.TryParse(randomNumCurp, out int resu6))
                                {
                                    args.IsValid = true;
                                }
                            }
                        }
                    }
                }
            }


        }


    }
}