using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ControlAsistencia.Clases;
using System.Globalization;

namespace ControlAsistencia
{
    public partial class EditEmpleados : Form
    {
        private Empleado empleado;

        public Empleado GetEmpleado()
        {
            return empleado;
        }

        public void SetEmpleado(Empleado empleado)
        {
            this.empleado = empleado;
        }

        public EditEmpleados()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            textBoxComision.Enabled = false;
            labelComision.Enabled = false;
            if (empleado != null) //Editar empleado
            {
                SetDatosEnControles();
            }
            else
            { //Alta
                IEnumerable<Type> listaTiposEmpleado = FindSubClassesOf<Empleado>();
                foreach (Type tipo in listaTiposEmpleado)
                {
                    ComboBoxItemTipo item = new ComboBoxItemTipo();
                    item.Tipo = tipo;
                    comboBoxTiposDeEmpleado.Items.Add(item);
                }
                comboBoxTiposDeEmpleado.SelectedItem = comboBoxTiposDeEmpleado.Items[0];
            }
        }

        public IEnumerable<Type> FindSubClassesOf<TBaseType>()
        {
            var baseType = typeof(TBaseType);
            var assembly = baseType.Assembly;

            return assembly.GetTypes().Where(t => t.IsSubclassOf(baseType));
        }

        public void SetDatosEnControles()
        {
            ComboBoxItemTipo item = new ComboBoxItemTipo();
            item.Tipo = empleado.GetType();

            comboBoxTiposDeEmpleado.Items.Add(item);
            
            comboBoxTiposDeEmpleado.SelectedIndex = 0; //TODO ver que estoy haciendo acá
            comboBoxTiposDeEmpleado.Enabled = false;

            textBoxLegajo.Text = empleado.Legajo.ToString();
            if (empleado is Vendedor)
            {
                textBoxComision.Enabled = true;
                labelComision.Enabled = true;
                textBoxComision.Text = ((Vendedor)empleado).Comision.ToString("0.00", CultureInfo.CurrentCulture);
            }
            else
            {
                textBoxComision.Enabled = false;
                labelComision.Enabled = false;
            }
            textBoxNombre.Text = empleado.Nombre;
            textBoxApellido.Text = empleado.Apellido;
            textBoxDireccion.Text = empleado.Direccion;
            textBoxTelefono.Text = empleado.Telefono;
        }

        private void buttonAceptar_Click(object sender, EventArgs e)
        {
            Aceptar();
        }

        private void Aceptar()
        {
            if (ValidarDatos())
            {
                if (empleado == null)
                {
                    ComboBoxItemTipo itemSeleccionado = (ComboBoxItemTipo)comboBoxTiposDeEmpleado.SelectedItem;
                    Type tipoSeleccionado = itemSeleccionado.Tipo;
                    empleado = (Empleado)Activator.CreateInstance(tipoSeleccionado);
                }

                empleado.Legajo = long.Parse(textBoxLegajo.Text);
                empleado.Nombre = textBoxNombre.Text;
                empleado.Apellido = textBoxApellido.Text;
                empleado.Direccion = textBoxDireccion.Text;
                empleado.Telefono = textBoxTelefono.Text;

                if ((empleado is Vendedor) && (textBoxComision.Text.Length != 0))
                    ((Vendedor)empleado).Comision = decimal.Parse(textBoxComision.Text, CultureInfo.CurrentCulture);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            Cancelar();
        }

        private void Cancelar()
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void comboBoxTiposDeEmpleado_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxItemTipo itemSeleccionado = (ComboBoxItemTipo)comboBoxTiposDeEmpleado.SelectedItem;
            System.Type tipoSeleccionado = itemSeleccionado.Tipo;
            if (tipoSeleccionado == typeof(Vendedor))
            {
                textBoxComision.Enabled = true;
                labelComision.Enabled = true;
            }
            else
            {
                textBoxComision.Text = "";
                textBoxComision.Enabled = false;
                labelComision.Enabled = false;
            }
        }

        private bool ValidarDatos()
        {
            bool valid = true;
            errorProvider1.Clear();
            
            // ** Validación del legajo **
            // Si no es válido el legajo (no se puede convertir a un int), notifico al usuario
            int codigo = 0;
            if (textBoxLegajo.Text == null || textBoxLegajo.Text.Trim().Length == 0)
            {
                valid = false;
                errorProvider1.SetError(textBoxLegajo, "El legajo no puede estar en blanco");
            }
            if (!int.TryParse(textBoxLegajo.Text, out codigo))
            {
                valid = false;
                errorProvider1.SetError(textBoxLegajo, "El legajo no es un número entero");
            }
            else if (codigo <= 0)
            {
                valid = false;
                errorProvider1.SetError(textBoxLegajo, "El legajo debe ser un número entero positivo");
            }
            // ** Validación de nombre **
            if (textBoxNombre.Text == null || textBoxNombre.Text.Trim().Length == 0)
            {
                valid = false;
                errorProvider1.SetError(textBoxNombre, "Debe indicar un nombre");
            }
            // ** Validación de apellido **
            if (textBoxApellido.Text == null || textBoxApellido.Text.Trim().Length == 0)
            {
                valid = false;
                errorProvider1.SetError(textBoxApellido, "Debe indicar un apellido");
            }

            // Validacion del tipo de empleado
            ComboBoxItemTipo itemSeleccionado = (ComboBoxItemTipo)comboBoxTiposDeEmpleado.SelectedItem;
            try
            {
                // ** Validación de comisión porcentual solo si es vendedor**
                // Si no es válido la comisión porcentual (no se puede convertir a un decimal), notifico al usuario
                decimal comisionPorcentual = 0;

                if (itemSeleccionado.Tipo == typeof(Vendedor))
                {
                    if (textBoxComision.Text == null || textBoxComision.Text.Trim().Length == 0)
                    {
                        valid = false;
                        errorProvider1.SetError(textBoxComision, "Debe ingresar una comision");
                    }
                    if (!decimal.TryParse(textBoxComision.Text, out comisionPorcentual))
                    {
                        valid = false;
                        errorProvider1.SetError(textBoxComision, "La comisión porcentual no es un número decimal");
                    }
                    else if (comisionPorcentual < 0 || comisionPorcentual > 100)
                    {
                        valid = false;
                        errorProvider1.SetError(textBoxComision, "La comisión porcentual es un número entre 0 y 100");
                    }
                }
            } catch (NullReferenceException){
                    valid = false;
                    errorProvider1.SetError(comboBoxTiposDeEmpleado, "Tiene que elegir el tipo de empleado");
            }
            
            return valid;
        }

        private void EmpleadoEditFormFormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult != DialogResult.OK)
            {
                if (DialogResult.Yes != MessageBox.Show(this, "¿Está seguro que desea cerrar la ventana?", "Confirmación de cierre de ventana", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    e.Cancel = true;
                }
            }            
        }

        private void EditEmpleados_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
            else if (e.KeyCode == Keys.Enter)
                Aceptar();
        }
    }
}
