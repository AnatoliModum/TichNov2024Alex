namespace ADOWinForms
{
    partial class frmEstatusAlumnos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cboxEstatus = new System.Windows.Forms.ComboBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.bntActualizar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.dtagEstatus = new System.Windows.Forms.DataGridView();
            this.pnlData = new System.Windows.Forms.Panel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAccion = new System.Windows.Forms.Button();
            this.txtbClave = new System.Windows.Forms.TextBox();
            this.txtbNombre = new System.Windows.Forms.TextBox();
            this.lblClave = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtagEstatus)).BeginInit();
            this.pnlData.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboxEstatus
            // 
            this.cboxEstatus.FormattingEnabled = true;
            this.cboxEstatus.Location = new System.Drawing.Point(50, 26);
            this.cboxEstatus.Name = "cboxEstatus";
            this.cboxEstatus.Size = new System.Drawing.Size(121, 21);
            this.cboxEstatus.TabIndex = 0;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(231, 26);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 1;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // bntActualizar
            // 
            this.bntActualizar.Location = new System.Drawing.Point(362, 26);
            this.bntActualizar.Name = "bntActualizar";
            this.bntActualizar.Size = new System.Drawing.Size(75, 23);
            this.bntActualizar.TabIndex = 2;
            this.bntActualizar.Text = "Actualizar";
            this.bntActualizar.UseVisualStyleBackColor = true;
            this.bntActualizar.Click += new System.EventHandler(this.bntActualizar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(486, 26);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 3;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // dtagEstatus
            // 
            this.dtagEstatus.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtagEstatus.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dtagEstatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtagEstatus.Location = new System.Drawing.Point(50, 90);
            this.dtagEstatus.Name = "dtagEstatus";
            this.dtagEstatus.Size = new System.Drawing.Size(694, 127);
            this.dtagEstatus.TabIndex = 4;
            // 
            // pnlData
            // 
            this.pnlData.Controls.Add(this.btnCancelar);
            this.pnlData.Controls.Add(this.btnAccion);
            this.pnlData.Controls.Add(this.txtbClave);
            this.pnlData.Controls.Add(this.txtbNombre);
            this.pnlData.Controls.Add(this.lblClave);
            this.pnlData.Controls.Add(this.lblNombre);
            this.pnlData.Location = new System.Drawing.Point(50, 263);
            this.pnlData.Name = "pnlData";
            this.pnlData.Size = new System.Drawing.Size(694, 143);
            this.pnlData.TabIndex = 5;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(211, 95);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAccion
            // 
            this.btnAccion.Location = new System.Drawing.Point(81, 95);
            this.btnAccion.Name = "btnAccion";
            this.btnAccion.Size = new System.Drawing.Size(75, 23);
            this.btnAccion.TabIndex = 4;
            this.btnAccion.Text = "button1";
            this.btnAccion.UseVisualStyleBackColor = true;
            this.btnAccion.Click += new System.EventHandler(this.btnAccion_Click);
            // 
            // txtbClave
            // 
            this.txtbClave.Location = new System.Drawing.Point(388, 22);
            this.txtbClave.Name = "txtbClave";
            this.txtbClave.Size = new System.Drawing.Size(196, 20);
            this.txtbClave.TabIndex = 3;
            // 
            // txtbNombre
            // 
            this.txtbNombre.Location = new System.Drawing.Point(81, 22);
            this.txtbNombre.Name = "txtbNombre";
            this.txtbNombre.Size = new System.Drawing.Size(158, 20);
            this.txtbNombre.TabIndex = 2;
            // 
            // lblClave
            // 
            this.lblClave.AutoSize = true;
            this.lblClave.Location = new System.Drawing.Point(327, 25);
            this.lblClave.Name = "lblClave";
            this.lblClave.Size = new System.Drawing.Size(34, 13);
            this.lblClave.TabIndex = 1;
            this.lblClave.Text = "Clave";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(20, 25);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(44, 13);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre";
            // 
            // frmEstatusAlumnos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlData);
            this.Controls.Add(this.dtagEstatus);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.bntActualizar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.cboxEstatus);
            this.Name = "frmEstatusAlumnos";
            this.Text = "frmEstatusAlumnos";
            this.Load += new System.EventHandler(this.frmEstatusAlumnos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtagEstatus)).EndInit();
            this.pnlData.ResumeLayout(false);
            this.pnlData.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cboxEstatus;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button bntActualizar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.DataGridView dtagEstatus;
        private System.Windows.Forms.Panel pnlData;
        private System.Windows.Forms.TextBox txtbClave;
        private System.Windows.Forms.TextBox txtbNombre;
        private System.Windows.Forms.Label lblClave;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAccion;
    }
}