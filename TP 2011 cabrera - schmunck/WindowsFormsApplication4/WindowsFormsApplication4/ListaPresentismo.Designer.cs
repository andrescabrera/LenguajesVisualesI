namespace ControlAsistencia
{
    partial class ListaPresentismo
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
            this.components = new System.ComponentModel.Container();
            this.dataGridViewPresentismo = new System.Windows.Forms.DataGridView();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoraEntradaPautada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoraSalidaPautada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoraEntrada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoraSalida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelEstadisticas = new System.Windows.Forms.Panel();
            this.buttonExportarCSV = new System.Windows.Forms.Button();
            this.impEgreso = new System.Windows.Forms.Label();
            this.labelImpEgreso = new System.Windows.Forms.Label();
            this.impIngreso = new System.Windows.Forms.Label();
            this.labelImpIngreso = new System.Windows.Forms.Label();
            this.cumpHorario = new System.Windows.Forms.Label();
            this.labelCumpHorario = new System.Windows.Forms.Label();
            this.horasExtras = new System.Windows.Forms.Label();
            this.labelHorasExtras = new System.Windows.Forms.Label();
            this.cantHorasPautadas = new System.Windows.Forms.Label();
            this.labelHorasPautadas = new System.Windows.Forms.Label();
            this.cantHorasTrabajadas = new System.Windows.Forms.Label();
            this.labelHorasTrabajadas = new System.Windows.Forms.Label();
            this.labelNombreEmpleado = new System.Windows.Forms.Label();
            this.labelLegajo = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.registrarEntradaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registrarSalidaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registrarAusenciaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dtpFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.labelFiltrar = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPresentismo)).BeginInit();
            this.panelEstadisticas.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewPresentismo
            // 
            this.dataGridViewPresentismo.AllowUserToAddRows = false;
            this.dataGridViewPresentismo.AllowUserToDeleteRows = false;
            this.dataGridViewPresentismo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewPresentismo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPresentismo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Fecha,
            this.HoraEntradaPautada,
            this.HoraSalidaPautada,
            this.HoraEntrada,
            this.HoraSalida,
            this.Tipo});
            this.dataGridViewPresentismo.Location = new System.Drawing.Point(12, 72);
            this.dataGridViewPresentismo.MultiSelect = false;
            this.dataGridViewPresentismo.Name = "dataGridViewPresentismo";
            this.dataGridViewPresentismo.ReadOnly = true;
            this.dataGridViewPresentismo.RowHeadersVisible = false;
            this.dataGridViewPresentismo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewPresentismo.Size = new System.Drawing.Size(741, 317);
            this.dataGridViewPresentismo.TabIndex = 0;
            this.dataGridViewPresentismo.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewPresentismo_CellMouseDoubleClick);
            this.dataGridViewPresentismo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridViewPresentismo_KeyDown);
            // 
            // Fecha
            // 
            this.Fecha.Frozen = true;
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.MinimumWidth = 40;
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            // 
            // HoraEntradaPautada
            // 
            this.HoraEntradaPautada.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.HoraEntradaPautada.HeaderText = "Entrada Pautada";
            this.HoraEntradaPautada.MinimumWidth = 120;
            this.HoraEntradaPautada.Name = "HoraEntradaPautada";
            this.HoraEntradaPautada.ReadOnly = true;
            this.HoraEntradaPautada.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.HoraEntradaPautada.Width = 120;
            // 
            // HoraSalidaPautada
            // 
            this.HoraSalidaPautada.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.HoraSalidaPautada.HeaderText = "Salida Pautada";
            this.HoraSalidaPautada.MinimumWidth = 100;
            this.HoraSalidaPautada.Name = "HoraSalidaPautada";
            this.HoraSalidaPautada.ReadOnly = true;
            // 
            // HoraEntrada
            // 
            this.HoraEntrada.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.HoraEntrada.HeaderText = "Entrada";
            this.HoraEntrada.MinimumWidth = 80;
            this.HoraEntrada.Name = "HoraEntrada";
            this.HoraEntrada.ReadOnly = true;
            // 
            // HoraSalida
            // 
            this.HoraSalida.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.HoraSalida.HeaderText = "Salida";
            this.HoraSalida.MinimumWidth = 80;
            this.HoraSalida.Name = "HoraSalida";
            this.HoraSalida.ReadOnly = true;
            // 
            // Tipo
            // 
            this.Tipo.HeaderText = "Tipo";
            this.Tipo.MinimumWidth = 80;
            this.Tipo.Name = "Tipo";
            this.Tipo.ReadOnly = true;
            this.Tipo.Width = 80;
            // 
            // panelEstadisticas
            // 
            this.panelEstadisticas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelEstadisticas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panelEstadisticas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelEstadisticas.Controls.Add(this.buttonExportarCSV);
            this.panelEstadisticas.Controls.Add(this.impEgreso);
            this.panelEstadisticas.Controls.Add(this.labelImpEgreso);
            this.panelEstadisticas.Controls.Add(this.impIngreso);
            this.panelEstadisticas.Controls.Add(this.labelImpIngreso);
            this.panelEstadisticas.Controls.Add(this.cumpHorario);
            this.panelEstadisticas.Controls.Add(this.labelCumpHorario);
            this.panelEstadisticas.Controls.Add(this.horasExtras);
            this.panelEstadisticas.Controls.Add(this.labelHorasExtras);
            this.panelEstadisticas.Controls.Add(this.cantHorasPautadas);
            this.panelEstadisticas.Controls.Add(this.labelHorasPautadas);
            this.panelEstadisticas.Controls.Add(this.cantHorasTrabajadas);
            this.panelEstadisticas.Controls.Add(this.labelHorasTrabajadas);
            this.panelEstadisticas.Location = new System.Drawing.Point(12, 384);
            this.panelEstadisticas.Margin = new System.Windows.Forms.Padding(2);
            this.panelEstadisticas.Name = "panelEstadisticas";
            this.panelEstadisticas.Size = new System.Drawing.Size(741, 70);
            this.panelEstadisticas.TabIndex = 6;
            // 
            // buttonExportarCSV
            // 
            this.buttonExportarCSV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExportarCSV.Location = new System.Drawing.Point(565, 15);
            this.buttonExportarCSV.Name = "buttonExportarCSV";
            this.buttonExportarCSV.Size = new System.Drawing.Size(117, 39);
            this.buttonExportarCSV.TabIndex = 12;
            this.buttonExportarCSV.Text = "Exportar a CSV";
            this.buttonExportarCSV.UseVisualStyleBackColor = true;
            // 
            // impEgreso
            // 
            this.impEgreso.AutoSize = true;
            this.impEgreso.Location = new System.Drawing.Point(480, 40);
            this.impEgreso.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.impEgreso.Name = "impEgreso";
            this.impEgreso.Size = new System.Drawing.Size(13, 13);
            this.impEgreso.TabIndex = 11;
            this.impEgreso.Text = "0";
            // 
            // labelImpEgreso
            // 
            this.labelImpEgreso.AutoSize = true;
            this.labelImpEgreso.Location = new System.Drawing.Point(333, 40);
            this.labelImpEgreso.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelImpEgreso.Name = "labelImpEgreso";
            this.labelImpEgreso.Size = new System.Drawing.Size(123, 13);
            this.labelImpEgreso.TabIndex = 10;
            this.labelImpEgreso.Text = "Impuntualidades Egreso:";
            // 
            // impIngreso
            // 
            this.impIngreso.AutoSize = true;
            this.impIngreso.Location = new System.Drawing.Point(480, 15);
            this.impIngreso.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.impIngreso.Name = "impIngreso";
            this.impIngreso.Size = new System.Drawing.Size(13, 13);
            this.impIngreso.TabIndex = 9;
            this.impIngreso.Text = "0";
            // 
            // labelImpIngreso
            // 
            this.labelImpIngreso.AutoSize = true;
            this.labelImpIngreso.Location = new System.Drawing.Point(333, 15);
            this.labelImpIngreso.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelImpIngreso.Name = "labelImpIngreso";
            this.labelImpIngreso.Size = new System.Drawing.Size(140, 13);
            this.labelImpIngreso.TabIndex = 8;
            this.labelImpIngreso.Text = "Impuntualidades en Ingreso:";
            // 
            // cumpHorario
            // 
            this.cumpHorario.AutoSize = true;
            this.cumpHorario.Location = new System.Drawing.Point(272, 40);
            this.cumpHorario.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.cumpHorario.Name = "cumpHorario";
            this.cumpHorario.Size = new System.Drawing.Size(13, 13);
            this.cumpHorario.TabIndex = 7;
            this.cumpHorario.Text = "0";
            // 
            // labelCumpHorario
            // 
            this.labelCumpHorario.AutoSize = true;
            this.labelCumpHorario.Location = new System.Drawing.Point(159, 40);
            this.labelCumpHorario.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCumpHorario.Name = "labelCumpHorario";
            this.labelCumpHorario.Size = new System.Drawing.Size(109, 13);
            this.labelCumpHorario.TabIndex = 6;
            this.labelCumpHorario.Text = "Cumplimiento Horario:";
            // 
            // horasExtras
            // 
            this.horasExtras.AutoSize = true;
            this.horasExtras.Location = new System.Drawing.Point(272, 15);
            this.horasExtras.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.horasExtras.Name = "horasExtras";
            this.horasExtras.Size = new System.Drawing.Size(13, 13);
            this.horasExtras.TabIndex = 5;
            this.horasExtras.Text = "0";
            // 
            // labelHorasExtras
            // 
            this.labelHorasExtras.AutoSize = true;
            this.labelHorasExtras.Location = new System.Drawing.Point(159, 15);
            this.labelHorasExtras.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelHorasExtras.Name = "labelHorasExtras";
            this.labelHorasExtras.Size = new System.Drawing.Size(70, 13);
            this.labelHorasExtras.TabIndex = 4;
            this.labelHorasExtras.Text = "Horas Extras:";
            // 
            // cantHorasPautadas
            // 
            this.cantHorasPautadas.AutoSize = true;
            this.cantHorasPautadas.Location = new System.Drawing.Point(104, 40);
            this.cantHorasPautadas.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.cantHorasPautadas.Name = "cantHorasPautadas";
            this.cantHorasPautadas.Size = new System.Drawing.Size(13, 13);
            this.cantHorasPautadas.TabIndex = 3;
            this.cantHorasPautadas.Text = "0";
            // 
            // labelHorasPautadas
            // 
            this.labelHorasPautadas.AutoSize = true;
            this.labelHorasPautadas.Location = new System.Drawing.Point(10, 40);
            this.labelHorasPautadas.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelHorasPautadas.Name = "labelHorasPautadas";
            this.labelHorasPautadas.Size = new System.Drawing.Size(86, 13);
            this.labelHorasPautadas.TabIndex = 2;
            this.labelHorasPautadas.Text = "Horas Pautadas:";
            // 
            // cantHorasTrabajadas
            // 
            this.cantHorasTrabajadas.AutoSize = true;
            this.cantHorasTrabajadas.Location = new System.Drawing.Point(104, 15);
            this.cantHorasTrabajadas.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.cantHorasTrabajadas.Name = "cantHorasTrabajadas";
            this.cantHorasTrabajadas.Size = new System.Drawing.Size(13, 13);
            this.cantHorasTrabajadas.TabIndex = 1;
            this.cantHorasTrabajadas.Text = "0";
            // 
            // labelHorasTrabajadas
            // 
            this.labelHorasTrabajadas.AutoSize = true;
            this.labelHorasTrabajadas.Location = new System.Drawing.Point(10, 15);
            this.labelHorasTrabajadas.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelHorasTrabajadas.Name = "labelHorasTrabajadas";
            this.labelHorasTrabajadas.Size = new System.Drawing.Size(94, 13);
            this.labelHorasTrabajadas.TabIndex = 0;
            this.labelHorasTrabajadas.Text = "Horas Trabajadas:";
            // 
            // labelNombreEmpleado
            // 
            this.labelNombreEmpleado.AutoSize = true;
            this.labelNombreEmpleado.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNombreEmpleado.ForeColor = System.Drawing.SystemColors.GrayText;
            this.labelNombreEmpleado.Location = new System.Drawing.Point(154, 35);
            this.labelNombreEmpleado.Name = "labelNombreEmpleado";
            this.labelNombreEmpleado.Size = new System.Drawing.Size(205, 31);
            this.labelNombreEmpleado.TabIndex = 9;
            this.labelNombreEmpleado.Text = "Andrés Cabrera";
            // 
            // labelLegajo
            // 
            this.labelLegajo.AutoSize = true;
            this.labelLegajo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLegajo.ForeColor = System.Drawing.SystemColors.GrayText;
            this.labelLegajo.Location = new System.Drawing.Point(12, 35);
            this.labelLegajo.Name = "labelLegajo";
            this.labelLegajo.Size = new System.Drawing.Size(89, 31);
            this.labelLegajo.TabIndex = 10;
            this.labelLegajo.Text = "53231";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registrarEntradaToolStripMenuItem,
            this.registrarSalidaToolStripMenuItem,
            this.registrarAusenciaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(765, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // registrarEntradaToolStripMenuItem
            // 
            this.registrarEntradaToolStripMenuItem.Name = "registrarEntradaToolStripMenuItem";
            this.registrarEntradaToolStripMenuItem.Size = new System.Drawing.Size(108, 20);
            this.registrarEntradaToolStripMenuItem.Text = "Registrar &Entrada";
            this.registrarEntradaToolStripMenuItem.Click += new System.EventHandler(this.registrarEntradaToolStripMenuItem_Click);
            // 
            // registrarSalidaToolStripMenuItem
            // 
            this.registrarSalidaToolStripMenuItem.Name = "registrarSalidaToolStripMenuItem";
            this.registrarSalidaToolStripMenuItem.Size = new System.Drawing.Size(99, 20);
            this.registrarSalidaToolStripMenuItem.Text = "Registrar &Salida";
            this.registrarSalidaToolStripMenuItem.Click += new System.EventHandler(this.registrarSalidaToolStripMenuItem_Click);
            // 
            // registrarAusenciaToolStripMenuItem
            // 
            this.registrarAusenciaToolStripMenuItem.Name = "registrarAusenciaToolStripMenuItem";
            this.registrarAusenciaToolStripMenuItem.Size = new System.Drawing.Size(116, 20);
            this.registrarAusenciaToolStripMenuItem.Text = "Registrar &Ausencia";
            this.registrarAusenciaToolStripMenuItem.Click += new System.EventHandler(this.registrarAusenciaToolStripMenuItem_Click);
            // 
            // dtpFechaDesde
            // 
            this.dtpFechaDesde.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaDesde.Location = new System.Drawing.Point(513, 48);
            this.dtpFechaDesde.Name = "dtpFechaDesde";
            this.dtpFechaDesde.Size = new System.Drawing.Size(100, 20);
            this.dtpFechaDesde.TabIndex = 12;
            this.dtpFechaDesde.ValueChanged += new System.EventHandler(this.dtpFechaDesde_ValueChanged);
            // 
            // dtpFechaHasta
            // 
            this.dtpFechaHasta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaHasta.Location = new System.Drawing.Point(644, 48);
            this.dtpFechaHasta.Name = "dtpFechaHasta";
            this.dtpFechaHasta.Size = new System.Drawing.Size(98, 20);
            this.dtpFechaHasta.TabIndex = 13;
            this.dtpFechaHasta.ValueChanged += new System.EventHandler(this.dtpFechaHasta_ValueChanged);
            // 
            // labelFiltrar
            // 
            this.labelFiltrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelFiltrar.AutoSize = true;
            this.labelFiltrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFiltrar.Location = new System.Drawing.Point(510, 29);
            this.labelFiltrar.Name = "labelFiltrar";
            this.labelFiltrar.Size = new System.Drawing.Size(86, 16);
            this.labelFiltrar.TabIndex = 14;
            this.labelFiltrar.Text = "Mostrar entre";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(628, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(10, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "-";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ListaPresentismo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 448);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelFiltrar);
            this.Controls.Add(this.dtpFechaHasta);
            this.Controls.Add(this.dtpFechaDesde);
            this.Controls.Add(this.dataGridViewPresentismo);
            this.Controls.Add(this.labelLegajo);
            this.Controls.Add(this.labelNombreEmpleado);
            this.Controls.Add(this.panelEstadisticas);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(712, 480);
            this.Name = "ListaPresentismo";
            this.Text = "Presentismo por Empleado";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ListaPresentismo_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPresentismo)).EndInit();
            this.panelEstadisticas.ResumeLayout(false);
            this.panelEstadisticas.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewPresentismo;
        private System.Windows.Forms.Panel panelEstadisticas;
        private System.Windows.Forms.Label cantHorasPautadas;
        private System.Windows.Forms.Label labelHorasPautadas;
        private System.Windows.Forms.Label cantHorasTrabajadas;
        private System.Windows.Forms.Label labelHorasTrabajadas;
        private System.Windows.Forms.Label labelNombreEmpleado;
        private System.Windows.Forms.Label labelLegajo;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem registrarEntradaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registrarSalidaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registrarAusenciaToolStripMenuItem;
        private System.Windows.Forms.Label cumpHorario;
        private System.Windows.Forms.Label labelCumpHorario;
        private System.Windows.Forms.Label horasExtras;
        private System.Windows.Forms.Label labelHorasExtras;
        private System.Windows.Forms.Button buttonExportarCSV;
        private System.Windows.Forms.Label impEgreso;
        private System.Windows.Forms.Label labelImpEgreso;
        private System.Windows.Forms.Label impIngreso;
        private System.Windows.Forms.Label labelImpIngreso;
        private System.Windows.Forms.DateTimePicker dtpFechaDesde;
        private System.Windows.Forms.DateTimePicker dtpFechaHasta;
        private System.Windows.Forms.Label labelFiltrar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoraEntradaPautada;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoraSalidaPautada;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoraEntrada;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoraSalida;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
    }
}