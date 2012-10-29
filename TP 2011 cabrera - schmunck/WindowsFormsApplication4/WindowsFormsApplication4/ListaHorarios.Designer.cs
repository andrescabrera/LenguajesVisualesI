namespace ControlAsistencia
{
    partial class ListaHorarios
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
            this.dataGridViewHorarios = new System.Windows.Forms.DataGridView();
            this.Día = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.horaDeSalida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblComisionMinima = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.agregarHorarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarHorarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarHorarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHorarios)).BeginInit();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewHorarios
            // 
            this.dataGridViewHorarios.AllowUserToAddRows = false;
            this.dataGridViewHorarios.AllowUserToDeleteRows = false;
            this.dataGridViewHorarios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewHorarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewHorarios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Día,
            this.Nombre,
            this.horaDeSalida});
            this.dataGridViewHorarios.Location = new System.Drawing.Point(12, 27);
            this.dataGridViewHorarios.MultiSelect = false;
            this.dataGridViewHorarios.Name = "dataGridViewHorarios";
            this.dataGridViewHorarios.ReadOnly = true;
            this.dataGridViewHorarios.RowHeadersVisible = false;
            this.dataGridViewHorarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewHorarios.Size = new System.Drawing.Size(672, 515);
            this.dataGridViewHorarios.TabIndex = 0;
            this.dataGridViewHorarios.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewHorarios_CellDoubleClick);
            this.dataGridViewHorarios.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridViewHorarios_KeyDown);
            // 
            // Día
            // 
            this.Día.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Día.Frozen = true;
            this.Día.HeaderText = "Día";
            this.Día.MinimumWidth = 40;
            this.Día.Name = "Día";
            this.Día.ReadOnly = true;
            this.Día.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Día.Width = 80;
            // 
            // Nombre
            // 
            this.Nombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Nombre.HeaderText = "Horario de Entrada";
            this.Nombre.MinimumWidth = 100;
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // horaDeSalida
            // 
            this.horaDeSalida.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.horaDeSalida.HeaderText = "Horario de Salida";
            this.horaDeSalida.Name = "horaDeSalida";
            this.horaDeSalida.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblComisionMinima);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lblCantidad);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 388);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(673, 55);
            this.panel1.TabIndex = 6;
            // 
            // lblComisionMinima
            // 
            this.lblComisionMinima.AutoSize = true;
            this.lblComisionMinima.Location = new System.Drawing.Point(104, 31);
            this.lblComisionMinima.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblComisionMinima.Name = "lblComisionMinima";
            this.lblComisionMinima.Size = new System.Drawing.Size(13, 13);
            this.lblComisionMinima.TabIndex = 3;
            this.lblComisionMinima.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 31);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Horas Pautadas.:";
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Location = new System.Drawing.Point(104, 6);
            this.lblCantidad.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(13, 13);
            this.lblCantidad.TabIndex = 1;
            this.lblCantidad.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Días Estipulados:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarHorarioToolStripMenuItem,
            this.modificarHorarioToolStripMenuItem,
            this.eliminarHorarioToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(696, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // agregarHorarioToolStripMenuItem
            // 
            this.agregarHorarioToolStripMenuItem.Name = "agregarHorarioToolStripMenuItem";
            this.agregarHorarioToolStripMenuItem.Size = new System.Drawing.Size(104, 20);
            this.agregarHorarioToolStripMenuItem.Text = "&Agregar Horario";
            this.agregarHorarioToolStripMenuItem.Click += new System.EventHandler(this.agregarHorarioToolStripMenuItem_Click);
            // 
            // modificarHorarioToolStripMenuItem
            // 
            this.modificarHorarioToolStripMenuItem.Name = "modificarHorarioToolStripMenuItem";
            this.modificarHorarioToolStripMenuItem.Size = new System.Drawing.Size(113, 20);
            this.modificarHorarioToolStripMenuItem.Text = "&Modificar Horario";
            this.modificarHorarioToolStripMenuItem.Click += new System.EventHandler(this.modificarHorarioToolStripMenuItem_Click);
            // 
            // eliminarHorarioToolStripMenuItem
            // 
            this.eliminarHorarioToolStripMenuItem.Name = "eliminarHorarioToolStripMenuItem";
            this.eliminarHorarioToolStripMenuItem.Size = new System.Drawing.Size(105, 20);
            this.eliminarHorarioToolStripMenuItem.Text = "&Eliminar Horario";
            this.eliminarHorarioToolStripMenuItem.Click += new System.EventHandler(this.eliminarHorarioToolStripMenuItem_Click);
            // 
            // ListaHorarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 442);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridViewHorarios);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(712, 480);
            this.Name = "ListaHorarios";
            this.Text = "Horarios del Empleado";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ListaHorarios_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridViewHorarios_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHorarios)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewHorarios;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblComisionMinima;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Día;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn horaDeSalida;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem agregarHorarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarHorarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarHorarioToolStripMenuItem;
    }
}