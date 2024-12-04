using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HolaMundoWindowsForm
{
    public partial class formEstados : Form
    {
        public formEstados()
        {
            InitializeComponent();
        }

        private void formEstados_Load(object sender, EventArgs e)
        {
            CRUDEstados controlEstados = new CRUDEstados();
            List<Estado> dataEstado = controlEstados.consultarEstados();

            cbxEstados.DataSource = dataEstado;
            cbxEstados.ValueMember = "id";
            cbxEstados.DisplayMember = "nombre";

            pnlDetalles.Visible = false;

            dgridEstados.DataSource = dataEstado;
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            //Estado est = (Estado)cbxEstados.SelectedItem;

            //MessageBox.Show($"Id: {est.id}  |  Nombre: {est.nombre}");

            Estado est = (Estado)cbxEstados.SelectedItem;

            txtbId.Text = est.id.ToString();
            txtbNombre.Text = est.nombre;
        }

        private void chkbDetalles_CheckedChanged(object sender, EventArgs e)
        {
            pnlDetalles.Visible = chkbDetalles.Checked;
        }
    }
}
