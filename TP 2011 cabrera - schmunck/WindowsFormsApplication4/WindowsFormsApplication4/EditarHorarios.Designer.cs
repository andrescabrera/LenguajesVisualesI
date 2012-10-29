namespace ControlAsistencia
{
    partial class EditarHorarios
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
            this.checkBoxLunes = new System.Windows.Forms.CheckBox();
            this.checkBoxViernes = new System.Windows.Forms.CheckBox();
            this.checkBoxJueves = new System.Windows.Forms.CheckBox();
            this.checkBoxMiercoles = new System.Windows.Forms.CheckBox();
            this.checkBoxMartes = new System.Windows.Forms.CheckBox();
            this.checkBoxSabado = new System.Windows.Forms.CheckBox();
            this.checkBoxDomingo = new System.Windows.Forms.CheckBox();
            this.labelDiaLaboral = new System.Windows.Forms.Label();
            this.dtpHorarioIngreso = new System.Windows.Forms.DateTimePicker();
            this.dtpHorarioEgreso = new System.Windows.Forms.DateTimePicker();
            this.labelHorarioDeEntrada = new System.Windows.Forms.Label();
            this.labelHorarioDeSalida = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonAceptar
            // 
            this.buttonAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAceptar.Location = new System.Drawing.Point(110, 236);
            this.buttonAceptar.Name = "buttonAceptar";
            this.buttonAceptar.Size = new System.Drawing.Size(87, 23);
            this.buttonAceptar.TabIndex = 9;
            this.buttonAceptar.Text = "&Aceptar";
            this.buttonAceptar.UseVisualStyleBackColor = true;
            this.buttonAceptar.Click += new System.EventHandler(this.buttonAceptarClick);
            this.buttonAceptar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EditarHorarios_KeyDown);
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancelar.Location = new System.Drawing.Point(249, 236);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(87, 23);
            this.buttonCancelar.TabIndex = 10;
            this.buttonCancelar.Text = "&Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            this.buttonCancelar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EditarHorarios_KeyDown);
            // 
            // checkBoxLunes
            // 
            this.checkBoxLunes.AutoSize = true;
            this.checkBoxLunes.Location = new System.Drawing.Point(68, 45);
            this.checkBoxLunes.Name = "checkBoxLunes";
            this.checkBoxLunes.Size = new System.Drawing.Size(55, 17);
            this.checkBoxLunes.TabIndex = 0;
            this.checkBoxLunes.Text = "Lunes";
            this.checkBoxLunes.UseVisualStyleBackColor = true;
            this.checkBoxLunes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EditarHorarios_KeyDown);
            // 
            // checkBoxViernes
            // 
            this.checkBoxViernes.AutoSize = true;
            this.checkBoxViernes.Location = new System.Drawing.Point(68, 137);
            this.checkBoxViernes.Name = "checkBoxViernes";
            this.checkBoxViernes.Size = new System.Drawing.Size(61, 17);
            this.checkBoxViernes.TabIndex = 4;
            this.checkBoxViernes.Text = "Viernes";
            this.checkBoxViernes.UseVisualStyleBackColor = true;
            this.checkBoxViernes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EditarHorarios_KeyDown);
            // 
            // checkBoxJueves
            // 
            this.checkBoxJueves.AutoSize = true;
            this.checkBoxJueves.Location = new System.Drawing.Point(68, 114);
            this.checkBoxJueves.Name = "checkBoxJueves";
            this.checkBoxJueves.Size = new System.Drawing.Size(60, 17);
            this.checkBoxJueves.TabIndex = 3;
            this.checkBoxJueves.Text = "Jueves";
            this.checkBoxJueves.UseVisualStyleBackColor = true;
            this.checkBoxJueves.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EditarHorarios_KeyDown);
            // 
            // checkBoxMiercoles
            // 
            this.checkBoxMiercoles.AutoSize = true;
            this.checkBoxMiercoles.Location = new System.Drawing.Point(68, 91);
            this.checkBoxMiercoles.Name = "checkBoxMiercoles";
            this.checkBoxMiercoles.Size = new System.Drawing.Size(71, 17);
            this.checkBoxMiercoles.TabIndex = 2;
            this.checkBoxMiercoles.Text = "Miercoles";
            this.checkBoxMiercoles.UseVisualStyleBackColor = true;
            this.checkBoxMiercoles.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EditarHorarios_KeyDown);
            // 
            // checkBoxMartes
            // 
            this.checkBoxMartes.AutoSize = true;
            this.checkBoxMartes.Location = new System.Drawing.Point(68, 68);
            this.checkBoxMartes.Name = "checkBoxMartes";
            this.checkBoxMartes.Size = new System.Drawing.Size(58, 17);
            this.checkBoxMartes.TabIndex = 1;
            this.checkBoxMartes.Text = "Martes";
            this.checkBoxMartes.UseVisualStyleBackColor = true;
            this.checkBoxMartes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EditarHorarios_KeyDown);
            // 
            // checkBoxSabado
            // 
            this.checkBoxSabado.AutoSize = true;
            this.checkBoxSabado.Location = new System.Drawing.Point(68, 160);
            this.checkBoxSabado.Name = "checkBoxSabado";
            this.checkBoxSabado.Size = new System.Drawing.Size(63, 17);
            this.checkBoxSabado.TabIndex = 5;
            this.checkBoxSabado.Text = "Sabado";
            this.checkBoxSabado.UseVisualStyleBackColor = true;
            this.checkBoxSabado.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EditarHorarios_KeyDown);
            // 
            // checkBoxDomingo
            // 
            this.checkBoxDomingo.AutoSize = true;
            this.checkBoxDomingo.Location = new System.Drawing.Point(68, 183);
            this.checkBoxDomingo.Name = "checkBoxDomingo";
            this.checkBoxDomingo.Size = new System.Drawing.Size(68, 17);
            this.checkBoxDomingo.TabIndex = 6;
            this.checkBoxDomingo.Text = "Domingo";
            this.checkBoxDomingo.UseVisualStyleBackColor = true;
            this.checkBoxDomingo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EditarHorarios_KeyDown);
            // 
            // labelDiaLaboral
            // 
            this.labelDiaLaboral.AutoSize = true;
            this.labelDiaLaboral.Location = new System.Drawing.Point(65, 19);
            this.labelDiaLaboral.Name = "labelDiaLaboral";
            this.labelDiaLaboral.Size = new System.Drawing.Size(72, 13);
            this.labelDiaLaboral.TabIndex = 9;
            this.labelDiaLaboral.Text = "Para los días:";
            // 
            // dtpHorarioIngreso
            // 
            this.dtpHorarioIngreso.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpHorarioIngreso.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHorarioIngreso.Location = new System.Drawing.Point(284, 52);
            this.dtpHorarioIngreso.Name = "dtpHorarioIngreso";
            this.dtpHorarioIngreso.Size = new System.Drawing.Size(110, 20);
            this.dtpHorarioIngreso.TabIndex = 7;
            this.dtpHorarioIngreso.Value = new System.DateTime(2012, 1, 1, 9, 0, 0, 0);
            this.dtpHorarioIngreso.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EditarHorarios_KeyDown);
            // 
            // dtpHorarioEgreso
            // 
            this.dtpHorarioEgreso.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpHorarioEgreso.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHorarioEgreso.Location = new System.Drawing.Point(284, 137);
            this.dtpHorarioEgreso.Name = "dtpHorarioEgreso";
            this.dtpHorarioEgreso.Size = new System.Drawing.Size(110, 20);
            this.dtpHorarioEgreso.TabIndex = 8;
            this.dtpHorarioEgreso.Value = new System.DateTime(2012, 1, 1, 18, 0, 0, 0);
            this.dtpHorarioEgreso.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EditarHorarios_KeyDown);
            // 
            // labelHorarioDeEntrada
            // 
            this.labelHorarioDeEntrada.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelHorarioDeEntrada.AutoSize = true;
            this.labelHorarioDeEntrada.Location = new System.Drawing.Point(228, 19);
            this.labelHorarioDeEntrada.Name = "labelHorarioDeEntrada";
            this.labelHorarioDeEntrada.Size = new System.Drawing.Size(96, 13);
            this.labelHorarioDeEntrada.TabIndex = 12;
            this.labelHorarioDeEntrada.Text = "Horario de Entrada";
            // 
            // labelHorarioDeSalida
            // 
            this.labelHorarioDeSalida.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelHorarioDeSalida.AutoSize = true;
            this.labelHorarioDeSalida.Location = new System.Drawing.Point(228, 104);
            this.labelHorarioDeSalida.Name = "labelHorarioDeSalida";
            this.labelHorarioDeSalida.Size = new System.Drawing.Size(88, 13);
            this.labelHorarioDeSalida.TabIndex = 13;
            this.labelHorarioDeSalida.Text = "Horario de Salida";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // EditarHorarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 271);
            this.Controls.Add(this.labelHorarioDeSalida);
            this.Controls.Add(this.labelHorarioDeEntrada);
            this.Controls.Add(this.dtpHorarioEgreso);
            this.Controls.Add(this.dtpHorarioIngreso);
            this.Controls.Add(this.labelDiaLaboral);
            this.Controls.Add(this.checkBoxDomingo);
            this.Controls.Add(this.checkBoxSabado);
            this.Controls.Add(this.checkBoxMartes);
            this.Controls.Add(this.checkBoxMiercoles);
            this.Controls.Add(this.checkBoxJueves);
            this.Controls.Add(this.checkBoxViernes);
            this.Controls.Add(this.checkBoxLunes);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonAceptar);
            this.MaximumSize = new System.Drawing.Size(640, 480);
            this.MinimumSize = new System.Drawing.Size(450, 309);
            this.Name = "EditarHorarios";
            this.Text = "Editar Horarios";
            this.Load += new System.EventHandler(this.EditarHorariosLoad);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EditarHorarios_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAceptar;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.CheckBox checkBoxLunes;
        private System.Windows.Forms.CheckBox checkBoxViernes;
        private System.Windows.Forms.CheckBox checkBoxJueves;
        private System.Windows.Forms.CheckBox checkBoxMiercoles;
        private System.Windows.Forms.CheckBox checkBoxMartes;
        private System.Windows.Forms.CheckBox checkBoxSabado;
        private System.Windows.Forms.CheckBox checkBoxDomingo;
        private System.Windows.Forms.Label labelDiaLaboral;
        private System.Windows.Forms.DateTimePicker dtpHorarioIngreso;
        private System.Windows.Forms.DateTimePicker dtpHorarioEgreso;
        private System.Windows.Forms.Label labelHorarioDeEntrada;
        private System.Windows.Forms.Label labelHorarioDeSalida;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}