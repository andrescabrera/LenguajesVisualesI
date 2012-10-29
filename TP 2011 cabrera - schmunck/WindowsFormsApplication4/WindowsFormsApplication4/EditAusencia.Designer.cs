namespace ControlAsistencia
{
    partial class EditAusencia
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
            this.buttonAceptar = new System.Windows.Forms.Button();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.textBoxMotivo = new System.Windows.Forms.TextBox();
            this.labelMotivoInformado = new System.Windows.Forms.Label();
            this.dtpDiaAusencia = new System.Windows.Forms.DateTimePicker();
            this.labelDiaAusencia = new System.Windows.Forms.Label();
            this.labelHorarioEntradaPautado = new System.Windows.Forms.Label();
            this.dtpHorarioIngreso = new System.Windows.Forms.DateTimePicker();
            this.dtpHorarioEgreso = new System.Windows.Forms.DateTimePicker();
            this.labelHorarioSalidaPautado = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonAceptar
            // 
            this.buttonAceptar.Location = new System.Drawing.Point(63, 312);
            this.buttonAceptar.Name = "buttonAceptar";
            this.buttonAceptar.Size = new System.Drawing.Size(109, 31);
            this.buttonAceptar.TabIndex = 0;
            this.buttonAceptar.Text = "Aceptar";
            this.buttonAceptar.UseVisualStyleBackColor = true;
            this.buttonAceptar.Click += new System.EventHandler(this.buttonAceptarClick);
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Location = new System.Drawing.Point(214, 312);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(109, 31);
            this.buttonCancelar.TabIndex = 1;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelarClick);
            // 
            // textBoxMotivo
            // 
            this.textBoxMotivo.Location = new System.Drawing.Point(12, 148);
            this.textBoxMotivo.Multiline = true;
            this.textBoxMotivo.Name = "textBoxMotivo";
            this.textBoxMotivo.Size = new System.Drawing.Size(352, 145);
            this.textBoxMotivo.TabIndex = 2;
            // 
            // labelMotivoInformado
            // 
            this.labelMotivoInformado.AutoSize = true;
            this.labelMotivoInformado.Location = new System.Drawing.Point(9, 123);
            this.labelMotivoInformado.Name = "labelMotivoInformado";
            this.labelMotivoInformado.Size = new System.Drawing.Size(89, 13);
            this.labelMotivoInformado.TabIndex = 3;
            this.labelMotivoInformado.Text = "Motivo Informado";
            // 
            // dtpDiaAusencia
            // 
            this.dtpDiaAusencia.Location = new System.Drawing.Point(164, 20);
            this.dtpDiaAusencia.Name = "dtpDiaAusencia";
            this.dtpDiaAusencia.Size = new System.Drawing.Size(200, 20);
            this.dtpDiaAusencia.TabIndex = 4;
            this.dtpDiaAusencia.ValueChanged += new System.EventHandler(this.dtpDiaAusencia_ValueChanged);
            // 
            // labelDiaAusencia
            // 
            this.labelDiaAusencia.AutoSize = true;
            this.labelDiaAusencia.Location = new System.Drawing.Point(9, 20);
            this.labelDiaAusencia.Name = "labelDiaAusencia";
            this.labelDiaAusencia.Size = new System.Drawing.Size(78, 13);
            this.labelDiaAusencia.TabIndex = 5;
            this.labelDiaAusencia.Text = "Ausente el Día";
            // 
            // labelHorarioEntradaPautado
            // 
            this.labelHorarioEntradaPautado.AutoSize = true;
            this.labelHorarioEntradaPautado.Location = new System.Drawing.Point(9, 58);
            this.labelHorarioEntradaPautado.Name = "labelHorarioEntradaPautado";
            this.labelHorarioEntradaPautado.Size = new System.Drawing.Size(137, 13);
            this.labelHorarioEntradaPautado.TabIndex = 6;
            this.labelHorarioEntradaPautado.Text = "Horario de entrada pautado";
            // 
            // dtpHorarioIngreso
            // 
            this.dtpHorarioIngreso.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpHorarioIngreso.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHorarioIngreso.Location = new System.Drawing.Point(254, 58);
            this.dtpHorarioIngreso.Name = "dtpHorarioIngreso";
            this.dtpHorarioIngreso.Size = new System.Drawing.Size(110, 20);
            this.dtpHorarioIngreso.TabIndex = 8;
            this.dtpHorarioIngreso.Value = new System.DateTime(2012, 1, 1, 9, 0, 0, 0);
            // 
            // dtpHorarioEgreso
            // 
            this.dtpHorarioEgreso.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpHorarioEgreso.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHorarioEgreso.Location = new System.Drawing.Point(254, 91);
            this.dtpHorarioEgreso.Name = "dtpHorarioEgreso";
            this.dtpHorarioEgreso.Size = new System.Drawing.Size(110, 20);
            this.dtpHorarioEgreso.TabIndex = 10;
            this.dtpHorarioEgreso.Value = new System.DateTime(2012, 1, 1, 9, 0, 0, 0);
            // 
            // labelHorarioSalidaPautado
            // 
            this.labelHorarioSalidaPautado.AutoSize = true;
            this.labelHorarioSalidaPautado.Location = new System.Drawing.Point(9, 91);
            this.labelHorarioSalidaPautado.Name = "labelHorarioSalidaPautado";
            this.labelHorarioSalidaPautado.Size = new System.Drawing.Size(128, 13);
            this.labelHorarioSalidaPautado.TabIndex = 9;
            this.labelHorarioSalidaPautado.Text = "Horario de salida pautado";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // EditAusencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 365);
            this.Controls.Add(this.dtpHorarioEgreso);
            this.Controls.Add(this.labelHorarioSalidaPautado);
            this.Controls.Add(this.dtpHorarioIngreso);
            this.Controls.Add(this.labelHorarioEntradaPautado);
            this.Controls.Add(this.labelDiaAusencia);
            this.Controls.Add(this.dtpDiaAusencia);
            this.Controls.Add(this.labelMotivoInformado);
            this.Controls.Add(this.textBoxMotivo);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonAceptar);
            this.Name = "EditAusencia";
            this.Text = "Ausencia";
            this.Load += new System.EventHandler(this.FormRegistrarAusencia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAceptar;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.TextBox textBoxMotivo;
        private System.Windows.Forms.Label labelMotivoInformado;
        private System.Windows.Forms.DateTimePicker dtpDiaAusencia;
        private System.Windows.Forms.Label labelDiaAusencia;
        private System.Windows.Forms.Label labelHorarioEntradaPautado;
        private System.Windows.Forms.DateTimePicker dtpHorarioIngreso;
        private System.Windows.Forms.DateTimePicker dtpHorarioEgreso;
        private System.Windows.Forms.Label labelHorarioSalidaPautado;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}