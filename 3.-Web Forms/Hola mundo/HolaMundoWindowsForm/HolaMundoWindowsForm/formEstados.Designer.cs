namespace HolaMundoWindowsForm
{
    partial class formEstados
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
            this.lblEstados = new System.Windows.Forms.Label();
            this.cbxEstados = new System.Windows.Forms.ComboBox();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.dgridEstados = new System.Windows.Forms.DataGridView();
            this.pnlDetalles = new System.Windows.Forms.Panel();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.txtbId = new System.Windows.Forms.TextBox();
            this.txtbNombre = new System.Windows.Forms.TextBox();
            this.chkbDetalles = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgridEstados)).BeginInit();
            this.pnlDetalles.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblEstados
            // 
            this.lblEstados.AutoSize = true;
            this.lblEstados.Location = new System.Drawing.Point(42, 34);
            this.lblEstados.Name = "lblEstados";
            this.lblEstados.Size = new System.Drawing.Size(45, 13);
            this.lblEstados.TabIndex = 0;
            this.lblEstados.Text = "Estados";
            // 
            // cbxEstados
            // 
            this.cbxEstados.FormattingEnabled = true;
            this.cbxEstados.Location = new System.Drawing.Point(93, 31);
            this.cbxEstados.Name = "cbxEstados";
            this.cbxEstados.Size = new System.Drawing.Size(121, 21);
            this.cbxEstados.TabIndex = 1;
            // 
            // btnConsultar
            // 
            this.btnConsultar.Location = new System.Drawing.Point(375, 395);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(75, 23);
            this.btnConsultar.TabIndex = 2;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // dgridEstados
            // 
            this.dgridEstados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgridEstados.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgridEstados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgridEstados.Location = new System.Drawing.Point(93, 103);
            this.dgridEstados.Name = "dgridEstados";
            this.dgridEstados.Size = new System.Drawing.Size(617, 152);
            this.dgridEstados.TabIndex = 3;
            // 
            // pnlDetalles
            // 
            this.pnlDetalles.Controls.Add(this.txtbNombre);
            this.pnlDetalles.Controls.Add(this.txtbId);
            this.pnlDetalles.Controls.Add(this.lblId);
            this.pnlDetalles.Controls.Add(this.lblNombre);
            this.pnlDetalles.Location = new System.Drawing.Point(93, 272);
            this.pnlDetalles.Name = "pnlDetalles";
            this.pnlDetalles.Size = new System.Drawing.Size(617, 64);
            this.pnlDetalles.TabIndex = 4;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(16, 25);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(44, 13);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre";
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(327, 24);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(16, 13);
            this.lblId.TabIndex = 1;
            this.lblId.Text = "Id";
            this.lblId.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtbId
            // 
            this.txtbId.Location = new System.Drawing.Point(363, 18);
            this.txtbId.Name = "txtbId";
            this.txtbId.Size = new System.Drawing.Size(100, 20);
            this.txtbId.TabIndex = 2;
            // 
            // txtbNombre
            // 
            this.txtbNombre.Location = new System.Drawing.Point(75, 21);
            this.txtbNombre.Name = "txtbNombre";
            this.txtbNombre.Size = new System.Drawing.Size(100, 20);
            this.txtbNombre.TabIndex = 3;
            // 
            // chkbDetalles
            // 
            this.chkbDetalles.AutoSize = true;
            this.chkbDetalles.Location = new System.Drawing.Point(423, 35);
            this.chkbDetalles.Name = "chkbDetalles";
            this.chkbDetalles.Size = new System.Drawing.Size(64, 17);
            this.chkbDetalles.TabIndex = 5;
            this.chkbDetalles.Text = "Detalles";
            this.chkbDetalles.UseVisualStyleBackColor = true;
            this.chkbDetalles.CheckedChanged += new System.EventHandler(this.chkbDetalles_CheckedChanged);
            // 
            // formEstados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.chkbDetalles);
            this.Controls.Add(this.pnlDetalles);
            this.Controls.Add(this.dgridEstados);
            this.Controls.Add(this.btnConsultar);
            this.Controls.Add(this.cbxEstados);
            this.Controls.Add(this.lblEstados);
            this.Name = "formEstados";
            this.Text = "formEstados";
            this.Load += new System.EventHandler(this.formEstados_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgridEstados)).EndInit();
            this.pnlDetalles.ResumeLayout(false);
            this.pnlDetalles.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblEstados;
        private System.Windows.Forms.ComboBox cbxEstados;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.DataGridView dgridEstados;
        private System.Windows.Forms.Panel pnlDetalles;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtbNombre;
        private System.Windows.Forms.TextBox txtbId;
        private System.Windows.Forms.CheckBox chkbDetalles;
    }
}