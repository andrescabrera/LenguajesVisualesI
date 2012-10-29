namespace ControlAsistencia
{
    partial class ListaEmpleados
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
            this.dataGridViewEmpleados = new System.Windows.Forms.DataGridView();
            this.Legajo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Apellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Direccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoEmpleado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cumplimientoDeHorario = new System.Windows.Forms.Label();
            this.labelCumplimientoDeHorario = new System.Windows.Forms.Label();
            this.desvioHorasPautadasE = new System.Windows.Forms.Label();
            this.labelDesvio = new System.Windows.Forms.Label();
            this.cantidadDeHorasPautadas = new System.Windows.Forms.Label();
            this.labelCantidadDeHorasPautadas = new System.Windows.Forms.Label();
            this.cantidadDeHorasTrabajadas = new System.Windows.Forms.Label();
            this.labelCantHorasTrabajadas = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.agregarEmpleadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarEmpleadoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarEmpleadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verHorariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verPresentismoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonExportarCSV = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmpleados)).BeginInit();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewEmpleados
            // 
            this.dataGridViewEmpleados.AllowUserToAddRows = false;
            this.dataGridViewEmpleados.AllowUserToDeleteRows = false;
            this.dataGridViewEmpleados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewEmpleados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEmpleados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Legajo,
            this.Nombre,
            this.Apellido,
            this.Direccion,
            this.Telefono,
            this.Comision,
            this.TipoEmpleado});
            this.dataGridViewEmpleados.Location = new System.Drawing.Point(12, 27);
            this.dataGridViewEmpleados.MultiSelect = false;
            this.dataGridViewEmpleados.Name = "dataGridViewEmpleados";
            this.dataGridViewEmpleados.ReadOnly = true;
            this.dataGridViewEmpleados.RowHeadersVisible = false;
            this.dataGridViewEmpleados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewEmpleados.Size = new System.Drawing.Size(672, 515);
            this.dataGridViewEmpleados.TabIndex = 10;
            this.dataGridViewEmpleados.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewEmpleados_CellMouseDoubleClick);
            this.dataGridViewEmpleados.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridViewEmpleados_KeyDown);
            // 
            // Legajo
            // 
            this.Legajo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Legajo.HeaderText = "Legajo";
            this.Legajo.MinimumWidth = 30;
            this.Legajo.Name = "Legajo";
            this.Legajo.ReadOnly = true;
            this.Legajo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Legajo.Width = 50;
            // 
            // Nombre
            // 
            this.Nombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.MinimumWidth = 100;
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // Apellido
            // 
            this.Apellido.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Apellido.HeaderText = "Apellido";
            this.Apellido.MinimumWidth = 100;
            this.Apellido.Name = "Apellido";
            this.Apellido.ReadOnly = true;
            // 
            // Direccion
            // 
            this.Direccion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Direccion.HeaderText = "Direccion";
            this.Direccion.MinimumWidth = 80;
            this.Direccion.Name = "Direccion";
            this.Direccion.ReadOnly = true;
            // 
            // Telefono
            // 
            this.Telefono.HeaderText = "Telefono";
            this.Telefono.Name = "Telefono";
            this.Telefono.ReadOnly = true;
            this.Telefono.Width = 74;
            // 
            // Comision
            // 
            this.Comision.HeaderText = "Comision";
            this.Comision.Name = "Comision";
            this.Comision.ReadOnly = true;
            this.Comision.Width = 74;
            // 
            // TipoEmpleado
            // 
            this.TipoEmpleado.HeaderText = "Tipo";
            this.TipoEmpleado.Name = "TipoEmpleado";
            this.TipoEmpleado.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.buttonExportarCSV);
            this.panel1.Controls.Add(this.cumplimientoDeHorario);
            this.panel1.Controls.Add(this.labelCumplimientoDeHorario);
            this.panel1.Controls.Add(this.desvioHorasPautadasE);
            this.panel1.Controls.Add(this.labelDesvio);
            this.panel1.Controls.Add(this.cantidadDeHorasPautadas);
            this.panel1.Controls.Add(this.labelCantidadDeHorasPautadas);
            this.panel1.Controls.Add(this.cantidadDeHorasTrabajadas);
            this.panel1.Controls.Add(this.labelCantHorasTrabajadas);
            this.panel1.Location = new System.Drawing.Point(12, 391);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(672, 55);
            this.panel1.TabIndex = 6;
            // 
            // cumplimientoDeHorario
            // 
            this.cumplimientoDeHorario.AutoSize = true;
            this.cumplimientoDeHorario.Location = new System.Drawing.Point(153, 28);
            this.cumplimientoDeHorario.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.cumplimientoDeHorario.Name = "cumplimientoDeHorario";
            this.cumplimientoDeHorario.Size = new System.Drawing.Size(13, 13);
            this.cumplimientoDeHorario.TabIndex = 15;
            this.cumplimientoDeHorario.Text = "0";
            // 
            // labelCumplimientoDeHorario
            // 
            this.labelCumplimientoDeHorario.AutoSize = true;
            this.labelCumplimientoDeHorario.Location = new System.Drawing.Point(10, 28);
            this.labelCumplimientoDeHorario.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCumplimientoDeHorario.Name = "labelCumplimientoDeHorario";
            this.labelCumplimientoDeHorario.Size = new System.Drawing.Size(124, 13);
            this.labelCumplimientoDeHorario.TabIndex = 14;
            this.labelCumplimientoDeHorario.Text = "Cumplimiento de Horario:";
            // 
            // desvioHorasPautadasE
            // 
            this.desvioHorasPautadasE.AutoSize = true;
            this.desvioHorasPautadasE.Location = new System.Drawing.Point(429, 6);
            this.desvioHorasPautadasE.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.desvioHorasPautadasE.Name = "desvioHorasPautadasE";
            this.desvioHorasPautadasE.Size = new System.Drawing.Size(13, 13);
            this.desvioHorasPautadasE.TabIndex = 13;
            this.desvioHorasPautadasE.Text = "0";
            // 
            // labelDesvio
            // 
            this.labelDesvio.AutoSize = true;
            this.labelDesvio.Location = new System.Drawing.Point(373, 6);
            this.labelDesvio.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelDesvio.Name = "labelDesvio";
            this.labelDesvio.Size = new System.Drawing.Size(43, 13);
            this.labelDesvio.TabIndex = 12;
            this.labelDesvio.Text = "Desvio:";
            // 
            // cantidadDeHorasPautadas
            // 
            this.cantidadDeHorasPautadas.AutoSize = true;
            this.cantidadDeHorasPautadas.Location = new System.Drawing.Point(334, 6);
            this.cantidadDeHorasPautadas.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.cantidadDeHorasPautadas.Name = "cantidadDeHorasPautadas";
            this.cantidadDeHorasPautadas.Size = new System.Drawing.Size(13, 13);
            this.cantidadDeHorasPautadas.TabIndex = 5;
            this.cantidadDeHorasPautadas.Text = "0";
            // 
            // labelCantidadDeHorasPautadas
            // 
            this.labelCantidadDeHorasPautadas.AutoSize = true;
            this.labelCantidadDeHorasPautadas.Location = new System.Drawing.Point(199, 6);
            this.labelCantidadDeHorasPautadas.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCantidadDeHorasPautadas.Name = "labelCantidadDeHorasPautadas";
            this.labelCantidadDeHorasPautadas.Size = new System.Drawing.Size(131, 13);
            this.labelCantidadDeHorasPautadas.TabIndex = 4;
            this.labelCantidadDeHorasPautadas.Text = "Cantidad Horas Pautadas:";
            // 
            // cantidadDeHorasTrabajadas
            // 
            this.cantidadDeHorasTrabajadas.AutoSize = true;
            this.cantidadDeHorasTrabajadas.Location = new System.Drawing.Point(153, 6);
            this.cantidadDeHorasTrabajadas.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.cantidadDeHorasTrabajadas.Name = "cantidadDeHorasTrabajadas";
            this.cantidadDeHorasTrabajadas.Size = new System.Drawing.Size(13, 13);
            this.cantidadDeHorasTrabajadas.TabIndex = 1;
            this.cantidadDeHorasTrabajadas.Text = "0";
            // 
            // labelCantHorasTrabajadas
            // 
            this.labelCantHorasTrabajadas.AutoSize = true;
            this.labelCantHorasTrabajadas.Location = new System.Drawing.Point(10, 6);
            this.labelCantHorasTrabajadas.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCantHorasTrabajadas.Name = "labelCantHorasTrabajadas";
            this.labelCantHorasTrabajadas.Size = new System.Drawing.Size(139, 13);
            this.labelCantHorasTrabajadas.TabIndex = 0;
            this.labelCantHorasTrabajadas.Text = "Cantidad Horas Trabajadas:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarEmpleadoToolStripMenuItem,
            this.agregarEmpleadoToolStripMenuItem1,
            this.eliminarEmpleadoToolStripMenuItem,
            this.verHorariosToolStripMenuItem,
            this.verPresentismoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(696, 24);
            this.menuStrip1.TabIndex = 15;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // agregarEmpleadoToolStripMenuItem
            // 
            this.agregarEmpleadoToolStripMenuItem.AccessibleName = "Agregar Empleado";
            this.agregarEmpleadoToolStripMenuItem.Name = "agregarEmpleadoToolStripMenuItem";
            this.agregarEmpleadoToolStripMenuItem.Size = new System.Drawing.Size(117, 20);
            this.agregarEmpleadoToolStripMenuItem.Text = "&Agregar Empleado";
            this.agregarEmpleadoToolStripMenuItem.Click += new System.EventHandler(this.agregarEmpleadoToolStripMenuItem_Click);
            // 
            // agregarEmpleadoToolStripMenuItem1
            // 
            this.agregarEmpleadoToolStripMenuItem1.Name = "agregarEmpleadoToolStripMenuItem1";
            this.agregarEmpleadoToolStripMenuItem1.Size = new System.Drawing.Size(105, 20);
            this.agregarEmpleadoToolStripMenuItem1.Text = "&Editar Empleado";
            this.agregarEmpleadoToolStripMenuItem1.Click += new System.EventHandler(this.editarEmpleadoToolStripMenuItem1_Click);
            // 
            // eliminarEmpleadoToolStripMenuItem
            // 
            this.eliminarEmpleadoToolStripMenuItem.Name = "eliminarEmpleadoToolStripMenuItem";
            this.eliminarEmpleadoToolStripMenuItem.Size = new System.Drawing.Size(118, 20);
            this.eliminarEmpleadoToolStripMenuItem.Text = "Elimina&r Empleado";
            this.eliminarEmpleadoToolStripMenuItem.Click += new System.EventHandler(this.eliminarEmpleadoToolStripMenuItem_Click);
            // 
            // verHorariosToolStripMenuItem
            // 
            this.verHorariosToolStripMenuItem.Name = "verHorariosToolStripMenuItem";
            this.verHorariosToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.verHorariosToolStripMenuItem.Text = "Ver &Horarios";
            this.verHorariosToolStripMenuItem.Click += new System.EventHandler(this.verHorariosToolStripMenuItem_Click);
            // 
            // verPresentismoToolStripMenuItem
            // 
            this.verPresentismoToolStripMenuItem.Name = "verPresentismoToolStripMenuItem";
            this.verPresentismoToolStripMenuItem.Size = new System.Drawing.Size(104, 20);
            this.verPresentismoToolStripMenuItem.Text = "Ver &Presentismo";
            this.verPresentismoToolStripMenuItem.Click += new System.EventHandler(this.verPresentismoToolStripMenuItem_Click);
            // 
            // buttonExportarCSV
            // 
            this.buttonExportarCSV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExportarCSV.Location = new System.Drawing.Point(537, 6);
            this.buttonExportarCSV.Name = "buttonExportarCSV";
            this.buttonExportarCSV.Size = new System.Drawing.Size(117, 39);
            this.buttonExportarCSV.TabIndex = 16;
            this.buttonExportarCSV.Text = "Exportar a CSV";
            this.buttonExportarCSV.UseVisualStyleBackColor = true;
            // 
            // ListaEmpleados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 442);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridViewEmpleados);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(712, 480);
            this.Name = "ListaEmpleados";
            this.Text = "Sistema de Gestión de Presentismo | Lista de Empleados";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmpleados)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewEmpleados;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label desvioHorasPautadasE;
        private System.Windows.Forms.Label labelDesvio;
        private System.Windows.Forms.Label cantidadDeHorasPautadas;
        private System.Windows.Forms.Label labelCantidadDeHorasPautadas;
        private System.Windows.Forms.Label cantidadDeHorasTrabajadas;
        private System.Windows.Forms.Label labelCantHorasTrabajadas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Legajo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Apellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn Direccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comision;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoEmpleado;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem agregarEmpleadoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agregarEmpleadoToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem eliminarEmpleadoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verHorariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verPresentismoToolStripMenuItem;
        private System.Windows.Forms.Label cumplimientoDeHorario;
        private System.Windows.Forms.Label labelCumplimientoDeHorario;
        private System.Windows.Forms.Button buttonExportarCSV;
    }
}