using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ADOWinForms.ADO;
using ADOWinForms.Entidades;

namespace ADOWinForms
{
    public partial class frmEstatusAlumnos : Form
    {
        string _acciones = "";

        public frmEstatusAlumnos()
        {
            InitializeComponent();
        }
        private void frmEstatusAlumnos_Load(object sender, EventArgs e)
        {
            cargarData();
        }
        private void cargarData()
        {
            btnAgregar.Enabled = true;
            btnEliminar.Enabled = true;
            bntActualizar.Enabled = true;

            ADOEstatusAlumno adoEsta = new ADOEstatusAlumno();

            cboxEstatus.DataSource = adoEsta.Consultar();
            cboxEstatus.ValueMember = "id";
            cboxEstatus.DisplayMember = "nombre";

            pnlData.Visible = false;

            dtagEstatus.DataSource = adoEsta.Consultar();
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            _acciones = "AGREGAR";

            btnAgregar.Enabled = false;
            btnEliminar.Enabled = false;
            bntActualizar.Enabled = false;

            txtbClave.Enabled = true;
            txtbNombre.Enabled = true;
            txtbClave.Text = "";
            txtbNombre.Text = "";

            btnAccion.Text = "Agregar";
            pnlData.Visible = true;
        }
        private void Acciones(string accion)
        {
            EstatusAlumno estaData = new EstatusAlumno();
            ADOEstatusAlumno _adoEsta = new ADOEstatusAlumno();

            switch (accion)
            {
                case "AGREGAR":
                    estaData.clave = txtbClave.Text;
                    estaData.nombre = txtbNombre.Text;
                    estaData.id = 0;
                    _adoEsta.Agregar(estaData);
                    cargarData();
                    break;
                case "ACTUALIZAR":
                    estaData = (EstatusAlumno)cboxEstatus.SelectedItem;
                    estaData.clave = txtbClave.Text;
                    estaData.nombre = txtbNombre.Text;
                    _adoEsta.Actualizar(estaData);
                    cargarData();
                    break;
                case "ELIMINAR":
                    estaData = (EstatusAlumno)cboxEstatus.SelectedItem;
                    _adoEsta.Eliminar(estaData.id);
                    cargarData();
                    break;
            }
        }
        private void btnAccion_Click(object sender, EventArgs e)
        {
            Acciones(_acciones);
        }
        private void bntActualizar_Click(object sender, EventArgs e)
        {
            EstatusAlumno estaData = (EstatusAlumno)cboxEstatus.SelectedItem;
            _acciones = "ACTUALIZAR";

            btnAgregar.Enabled = false;
            btnEliminar.Enabled = false;
            bntActualizar.Enabled = false;

            txtbNombre.Text = estaData.nombre;
            txtbClave.Text = estaData.clave;

            btnAccion.Text = "Actualizar";
            pnlData.Visible = true;
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cargarData();
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            EstatusAlumno estaData = (EstatusAlumno)cboxEstatus.SelectedItem;
            _acciones = "ELIMINAR";

            btnAgregar.Enabled = false;
            btnEliminar.Enabled = false;
            bntActualizar.Enabled = false;

            txtbNombre.Text = estaData.nombre;
            txtbClave.Text = estaData.clave;
            txtbNombre.Enabled = false;
            txtbClave.Enabled = false;

            btnAccion.Text = "Eliminar";
            pnlData.Visible = true;
        }
    }
}
