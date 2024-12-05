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
            FillDDLById(alu.idEstatus, alu.idEstadoOrigen);
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
            try
            {
                if (Page.IsValid)
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


                    negAlumno.Actualizar(alu);
                }
            }
            catch (Exception ex)
            {
                lblEx.Text = "Error al Actualizar: " + ex;
            }
        }

        protected void cvCurp_ServerValidate(object source, ServerValidateEventArgs args)
        {
            String curpForm = args.Value.ToString();
            String dayCurp = curpForm.Substring(8, 2);
            String monthCurp = curpForm.Substring(6, 2);
            String yearCurp = curpForm.Substring(4, 2);
            String fechaCurp = yearCurp + "-" + monthCurp + "-" + dayCurp;
            String fechaNacimiento = txtFNaci.Text.Substring(2, 8);

            args.IsValid = curpForm.Length == 18 ? true : false;
            args.IsValid = fechaCurp.Equals(fechaNacimiento) ? true : false;
        }

        protected void cv2Curp_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string completeCurp = args.Value;
            string nameCurp = completeCurp.Substring(0,4);
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
                    if (!sexoCurp.Any(char.IsDigit)){
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