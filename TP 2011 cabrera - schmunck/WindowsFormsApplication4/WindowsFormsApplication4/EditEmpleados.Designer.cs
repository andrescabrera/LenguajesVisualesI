namespace ControlAsistencia
{
    partial class EditEmpleados
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
            this.labelLegajo = new System.Windows.Forms.Label();
            this.labelNombre = new System.Windows.Forms.Label();
            this.labelApellido = new System.Windows.Forms.Label();
            this.labelTelefono = new System.Windows.Forms.Label();
            this.labelDireccion = new System.Windows.Forms.Label();
            this.textBoxLegajo = new System.Windows.Forms.TextBox();
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.textBoxApellido = new System.Windows.Forms.TextBox();
            this.textBoxTelefono = new System.Windows.Forms.TextBox();
            this.textBoxDireccion = new System.Windows.Forms.TextBox();
            this.buttonAceptar = new System.Windows.Forms.Button();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.labelComision = new System.Windows.Forms.Label();
            this.textBoxComision = new System.Windows.Forms.TextBox();
            this.comboBoxTiposDeEmpleado = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelLegajo
            // 
            this.labelLegajo.AutoSize = true;
            this.labelLegajo.Location = new System.Drawing.Point(85, 87);
            this.labelLegajo.Name = "labelLegajo";
            this.labelLegajo.Size = new System.Drawing.Size(39, 13);
            this.labelLegajo.TabIndex = 0;
            this.labelLegajo.Text = "Legajo";
            // 
            // labelNombre
            // 
            this.labelNombre.AutoSize = true;
            this.labelNombre.Location = new System.Drawing.Point(85, 118);
            this.labelNombre.Name = "labelNombre";
            this.labelNombre.Size = new System.Drawing.Size(44, 13);
            this.labelNombre.TabIndex = 1;
            this.labelNombre.Text = "Nombre";
            // 
            // labelApellido
            // 
            this.labelApellido.AutoSize = true;
            this.labelApellido.Location = new System.Drawing.Point(85, 147);
            this.labelApellido.Name = "labelApellido";
            this.labelApellido.Size = new System.Drawing.Size(44, 13);
            this.labelApellido.TabIndex = 2;
            this.labelApellido.Text = "Apellido";
            // 
            // labelTelefono
            // 
            this.labelTelefono.AutoSize = true;
            this.labelTelefono.Location = new System.Drawing.Point(85, 180);
            this.labelTelefono.Name = "labelTelefono";
            this.labelTelefono.Size = new System.Drawing.Size(49, 13);
            this.labelTelefono.TabIndex = 3;
            this.labelTelefono.Text = "Telefono";
            // 
            // labelDireccion
            // 
            this.labelDireccion.AutoSize = true;
            this.labelDireccion.Location = new System.Drawing.Point(85, 215);
            this.labelDireccion.Name = "labelDireccion";
            this.labelDireccion.Size = new System.Drawing.Size(52, 13);
            this.labelDireccion.TabIndex = 4;
            this.labelDireccion.Text = "Direccion";
            // 
            // textBoxLegajo
            // 
            this.textBoxLegajo.Location = new System.Drawing.Point(209, 87);
            this.textBoxLegajo.Name = "textBoxLegajo";
            this.textBoxLegajo.Size = new System.Drawing.Size(154, 20);
            this.textBoxLegajo.TabIndex = 5;
            this.textBoxLegajo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EditEmpleados_KeyDown);
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Location = new System.Drawing.Point(209, 118);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(154, 20);
            this.textBoxNombre.TabIndex = 6;
            this.textBoxNombre.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EditEmpleados_KeyDown);
            // 
            // textBoxApellido
            // 
            this.textBoxApellido.Location = new System.Drawing.Point(209, 147);
            this.textBoxApellido.Name = "textBoxApellido";
            this.textBoxApellido.Size = new System.Drawing.Size(154, 20);
            this.textBoxApellido.TabIndex = 7;
            this.textBoxApellido.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EditEmpleados_KeyDown);
            // 
            // textBoxTelefono
            // 
            this.textBoxTelefono.Location = new System.Drawing.Point(209, 180);
            this.textBoxTelefono.Name = "textBoxTelefono";
            this.textBoxTelefono.Size = new System.Drawing.Size(154, 20);
            this.textBoxTelefono.TabIndex = 8;
            this.textBoxTelefono.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EditEmpleados_KeyDown);
            // 
            // textBoxDireccion
            // 
            this.textBoxDireccion.Location = new System.Drawing.Point(209, 215);
            this.textBoxDireccion.Name = "textBoxDireccion";
            this.textBoxDireccion.Size = new System.Drawing.Size(154, 20);
            this.textBoxDireccion.TabIndex = 9;
            this.textBoxDireccion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EditEmpleados_KeyDown);
            // 
            // buttonAceptar
            // 
            this.buttonAceptar.Location = new System.Drawing.Point(209, 296);
            this.buttonAceptar.Name = "buttonAceptar";
            this.buttonAceptar.Size = new System.Drawing.Size(75, 23);
            this.buttonAceptar.TabIndex = 11;
            this.buttonAceptar.Text = "Aceptar";
            this.buttonAceptar.UseVisualStyleBackColor = true;
            this.buttonAceptar.Click += new System.EventHandler(this.buttonAceptar_Click);
            this.buttonAceptar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EditEmpleados_KeyDown);
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Location = new System.Drawing.Point(303, 296);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(75, 23);
            this.buttonCancelar.TabIndex = 12;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            this.buttonCancelar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EditEmpleados_KeyDown);
            // 
            // labelComision
            // 
            this.labelComision.AutoSize = true;
            this.labelComision.Location = new System.Drawing.Point(88, 250);
            this.labelComision.Name = "labelComision";
            this.labelComision.Size = new System.Drawing.Size(49, 13);
            this.labelComision.TabIndex = 12;
            this.labelComision.Text = "Comision";
            // 
            // textBoxComision
            // 
            this.textBoxComision.Location = new System.Drawing.Point(209, 247);
            this.textBoxComision.Name = "textBoxComision";
            this.textBoxComision.Size = new System.Drawing.Size(154, 20);
            this.textBoxComision.TabIndex = 10;
            this.textBoxComision.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EditEmpleados_KeyDown);
            // 
            // comboBoxTiposDeEmpleado
            // 
            this.comboBoxTiposDeEmpleado.FormattingEnabled = true;
            this.comboBoxTiposDeEmpleado.Location = new System.Drawing.Point(209, 26);
            this.comboBoxTiposDeEmpleado.Name = "comboBoxTiposDeEmpleado";
            this.comboBoxTiposDeEmpleado.Size = new System.Drawing.Size(154, 21);
            this.comboBoxTiposDeEmpleado.TabIndex = 14;
            this.comboBoxTiposDeEmpleado.SelectedIndexChanged += new System.EventHandler(this.comboBoxTiposDeEmpleado_SelectedIndexChanged);
            this.comboBoxTiposDeEmpleado.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EditEmpleados_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(85, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Tipo de Empleado";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // EditEmpleados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 371);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxTiposDeEmpleado);
            this.Controls.Add(this.textBoxComision);
            this.Controls.Add(this.labelComision);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonAceptar);
            this.Controls.Add(this.textBoxDireccion);
            this.Controls.Add(this.textBoxTelefono);
            this.Controls.Add(this.textBoxApellido);
            this.Controls.Add(this.textBoxNombre);
            this.Controls.Add(this.textBoxLegajo);
            this.Controls.Add(this.labelDireccion);
            this.Controls.Add(this.labelTelefono);
            this.Controls.Add(this.labelApellido);
            this.Controls.Add(this.labelNombre);
            this.Controls.Add(this.labelLegajo);
            this.Name = "EditEmpleados";
            this.Text = "Alta de Empleado";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EmpleadoEditFormFormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EditEmpleados_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelLegajo;
        private System.Windows.Forms.Label labelNombre;
        private System.Windows.Forms.Label labelApellido;
        private System.Windows.Forms.Label labelTelefono;
        private System.Windows.Forms.Label labelDireccion;
        private System.Windows.Forms.TextBox textBoxLegajo;
        private System.Windows.Forms.TextBox textBoxNombre;
        private System.Windows.Forms.TextBox textBoxApellido;
        private System.Windows.Forms.TextBox textBoxTelefono;
        private System.Windows.Forms.TextBox textBoxDireccion;
        private System.Windows.Forms.Button buttonAceptar;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Label labelComision;
        private System.Windows.Forms.TextBox textBoxComision;
        private System.Windows.Forms.ComboBox comboBoxTiposDeEmpleado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}