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
    public partial class Index : System.Web.UI.Page
    {
        NAlumno dataNeg = new NAlumno();
        NEstado dataEsta = new NEstado();
        NEstatusAlumno dataEstaAlu = new NEstatusAlumno();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fillGrid();
            }

        }

        protected void grdvAlumnos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "Page")
            {
                return;
            }
            else
            {
                int renglonIndex = Convert.ToInt16(e.CommandArgument);
                GridViewRow row = grdvAlumnos.Rows[renglonIndex];
                TableCell celda = row.Cells[0];
                int id = int.Parse(celda.Text);

                switch (e.CommandName)
                {
                    case "btnDetalles":
                        Response.Redirect($"Details.aspx?id={id}");
                        break;

                    case "btnEditar":
                        Response.Redirect($"Edit.aspx?id={id}");
                        break;

                    case "btnEliminar":
                        Response.Redirect($"Delete.aspx?id={id}");
                        break;
                }
            }
        }

        protected void grdvAlumnos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdvAlumnos.PageIndex = e.NewPageIndex;
            fillGrid();
        }
        private void fillGrid()
        {
            List<Alumno> aluData = dataNeg.Consultar();
            List<Estado> estaData = dataEsta.Consultar();
            List<EstatusAlumno> estaAluData = dataEstaAlu.Consultar();

            var innerJoinQuery =
            from alucno in aluData
            join estadito in estaData on alucno.idEstadoOrigen equals estadito.id
            join estatusito in estaAluData on alucno.idEstatus equals estatusito.id
            select new { id = alucno.id, nombre = alucno.nombre, pApellido = alucno.pApellido, sApellido = alucno.sApellido, correo = alucno.correo, telefono = alucno.telefono, idEstadoOrigen = estadito.nombre, idEstatus = estatusito.nombre };


            grdvAlumnos.DataSource = innerJoinQuery.ToList();
            grdvAlumnos.DataBind();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Create.aspx");
        }
    }
}