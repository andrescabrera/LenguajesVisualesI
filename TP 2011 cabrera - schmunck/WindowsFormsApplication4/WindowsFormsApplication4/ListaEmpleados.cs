using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ControlAsistencia.Servicios;
using ControlAsistencia.Clases;
using ControlAsistencia.Helpers;

namespace ControlAsistencia
{
    public partial class ListaEmpleados : Form
    {
        //menu contextual
        private ContextMenu cm;
        private DataGridViewHelper gridHelper;

        public ListaEmpleados()
        {
            InitializeComponent();

            Legajo.ValueType = typeof(long);
            Nombre.ValueType = typeof(String);
            Apellido.ValueType = typeof(String);
            Direccion.ValueType = typeof(String);
            Telefono.ValueType = typeof(String);
            Comision.ValueType = typeof(decimal);
            TipoEmpleado.ValueType = typeof(String);

            //creo el menu contextual
            cm = new ContextMenu();

            cm.MenuItems.Add(new MenuItem("Agregar Empleado", AgregarEmpleadoEventHandler));
            cm.MenuItems.Add(new MenuItem("Modificar Empleado", ModificarEmpleadoEventHandler));
            cm.MenuItems.Add(new MenuItem("Eliminar Empleado", EliminarEmpleadoEventHandler));
            cm.MenuItems.Add(new MenuItem("Ver Carga Horaria", VerCargaHorariaEventHandler));

            gridHelper = new DataGridViewHelper { Grid = dataGridViewEmpleados, ContextMenu = cm };
            gridHelper.AddSortCompareHandler();
            gridHelper.AddContextMenuHandler();
        }      

        public void CalcularEstadisticas()
        {
            List<Asistencia> asistenciasDelEmpleado;
            List<Ausencia> ausenciasDelEmpleado;
            double cantidadHorasTrabajadas = 0;
            double cantidadHorasPautadas = 0;
            int cantidadConcurrenciasPautadas = 0;
            int totalIncumplimiento = 0;
            double desvioHorasPautadas = 0;
            decimal porcentajeCumplimiento = 0;
            foreach (DataGridViewRow row in dataGridViewEmpleados.Rows)
            {
                asistenciasDelEmpleado = ServicioAsistencia.GetInstancia().BuscarPorEmpleado((Empleado)row.Tag);
                ausenciasDelEmpleado = ServicioAusencia.GetInstancia().BuscarPorEmpleado((Empleado)row.Tag);
                totalIncumplimiento += ausenciasDelEmpleado.Count(); //Cuento las veces que falto
                cantidadConcurrenciasPautadas += ausenciasDelEmpleado.Count + asistenciasDelEmpleado.Count;
                foreach(Asistencia a in asistenciasDelEmpleado)
                {
                    if (a.FechaHasta != DateTime.Parse("01/01/0001"))
                    {
                        TimeSpan timeSpanTrabajadas = (a.FechaHasta.TimeOfDay - a.FechaDesde.TimeOfDay);
                        cantidadHorasTrabajadas += timeSpanTrabajadas.TotalHours;
                    }
                    TimeSpan timeSpanPautadas = (a.FechaEgresoPautado.TimeOfDay - a.FechaIngresoPautado.TimeOfDay);
                    cantidadHorasPautadas += timeSpanPautadas.TotalHours;
                    if (a.FechaDesde > a.FechaIngresoPautado)
                        totalIncumplimiento++; //Sumo las que llegó tarde
                    //Si se fue temprano no la cuento ;)
                }
                foreach(Ausencia a in ausenciasDelEmpleado)
                {
                    TimeSpan timeSpanPautadas = (a.FechaEgresoPautado.TimeOfDay - a.FechaIngresoPautado.TimeOfDay);
                    cantidadHorasPautadas += timeSpanPautadas.TotalHours;
                }
            }
            cantidadDeHorasTrabajadas.Text = cantidadHorasTrabajadas.ToString("0.00");
            cantidadDeHorasPautadas.Text = cantidadHorasPautadas.ToString("0.00");
            if (cantidadHorasPautadas > 0)
            {
                desvioHorasPautadas = (cantidadHorasTrabajadas / cantidadHorasPautadas) * 100;
                desvioHorasPautadasE.Text = desvioHorasPautadas.ToString("0.00") + "%";
            }
            else
            {
                desvioHorasPautadasE.Text = "0.00 %";
            }
            int asistenciasPerfectas = cantidadConcurrenciasPautadas - totalIncumplimiento;
            
            if (cantidadConcurrenciasPautadas > 0)
            {
                porcentajeCumplimiento = ((decimal)(asistenciasPerfectas) / cantidadConcurrenciasPautadas) *100;
                cumplimientoDeHorario.Text = porcentajeCumplimiento.ToString("0.00") + "%";
            }
            else
            {
                cumplimientoDeHorario.Text = "-";
            }

        }

        
        #region Eventos

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            foreach (Empleado empleado in FachadaServiciosEmpleado.GetInstancia().BuscarTodos())
            {
                AgregarEmpleadoAGrilla(empleado);
            }
            CalcularEstadisticas();
        }

        private void buttonVerPresentismo_Click(object sender, EventArgs e)
        {
            VerPresentismo();
        }

        private void dataGridViewEmpleados_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            VerPresentismo();
        }

        private void buttonVerCargaHoraria_Click(object sender, EventArgs e)
        {
            VerCargaHoraria();
        }

        private void dataGridViewEmpleados_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                Eliminar();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                Modificar();
            }
        }

        private void agregarEmpleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Agregar();
        }

        private void editarEmpleadoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Modificar();
        }

        private void eliminarEmpleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Eliminar();
        }

        private void verHorariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VerCargaHoraria();
        }

        private void verPresentismoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VerPresentismo();
        }

        private void buttonAgregarClick(object sender, EventArgs e)
        {
            Agregar();
        }

        private void buttonModificarClick(object sender, EventArgs e)
        {
            Modificar();
        }

        private void buttonEliminarClick(object sender, EventArgs e)
        {
            Eliminar();
        }

        private void AgregarEmpleadoEventHandler(object sender, EventArgs e)
        {
            Agregar();
        }

        private void EliminarEmpleadoEventHandler(object sender, EventArgs e)
        {
            Eliminar();
        }

        private void ModificarEmpleadoEventHandler(object sender, EventArgs e)
        {
            Modificar();
        }

        private void VerCargaHorariaEventHandler(object sender, EventArgs e)
        {
            VerCargaHoraria();
        }

        #endregion

        #region Funcionalidad ABM

        private void RegistrarSalida()
        {
            if (dataGridViewEmpleados.SelectedRows.Count == 0)
                return;

            DataGridViewRow row = dataGridViewEmpleados.SelectedRows[0];
            Empleado e = (Empleado)row.Tag;
            Asistencia a;
            a = ServicioAsistencia.GetInstancia().BuscarPrimerAsistenciaSinHoraSalida(e);
            if (a == null)
            {
                MessageBox.Show(this, "No se encontró ninguna asistencia sin registro de salida para " + e.Nombre + " " + e.Apellido + ".", "Registrar Egreso", MessageBoxButtons.OK);
            }
            else if (MessageBox.Show(this, "Desea registrar el egreso del empleado " + e.Nombre + " ?", "Registrar Egreso", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                a.FechaHasta = DateTime.Now;
                ServicioAsistencia.GetInstancia().Modificar(a);
            }
        }

        private void VerPresentismo()
        {
            if (dataGridViewEmpleados.SelectedRows.Count == 0)
                return;

            DataGridViewRow row = dataGridViewEmpleados.SelectedRows[0];
            Empleado empleado = (Empleado)row.Tag;

            ListaPresentismo form = new ListaPresentismo(empleado);

            if (DialogResult.OK == form.ShowDialog(this))
            {
                CalcularEstadisticas();
            }
        }

        //Agrega un empleado
        private void Agregar()
        {
            EditEmpleados form = new EditEmpleados();

            if (DialogResult.OK == form.ShowDialog(this))
            {
                Empleado empleado = form.GetEmpleado();
                FachadaServiciosEmpleado.GetInstancia().Crear(empleado);

                AgregarEmpleadoAGrilla(empleado);
                SeleccionarUltimo();
                CalcularEstadisticas();
            }
        }

        private void SeleccionarUltimo()
        {
            dataGridViewEmpleados.ClearSelection();
            dataGridViewEmpleados.Rows[dataGridViewEmpleados.Rows.Count - 1].Selected = true;
        }

        // modifica empleado
        private void Modificar()
        {
            if (dataGridViewEmpleados.SelectedRows.Count == 0)
                return;

            DataGridViewRow row = dataGridViewEmpleados.SelectedRows[0];
            Empleado empleado = (Empleado)row.Tag;

            EditEmpleados form = new EditEmpleados();
            form.SetEmpleado(empleado);
            if (DialogResult.OK == form.ShowDialog(this))
            {
                empleado = form.GetEmpleado();
                FachadaServiciosEmpleado.GetInstancia().Modificar(empleado);
                ActualizarEmpleadoEnGrilla(row, empleado);
            }
        }

        private void VerCargaHoraria()
        {
            if (dataGridViewEmpleados.SelectedRows.Count == 0)
                return;

            DataGridViewRow row = dataGridViewEmpleados.SelectedRows[0];
            Empleado empleado = (Empleado)row.Tag;

            ListaHorarios formListaHorarios = new ListaHorarios(empleado.CargaHoraria, this);
            this.Visible = false;
            formListaHorarios.Show();

            empleado.CargaHoraria = formListaHorarios.GetCargaHoraria();
            ServicioCargaHoraria.GetInstancia().Modificar(empleado.CargaHoraria);
            FachadaServiciosEmpleado.GetInstancia().Modificar(empleado);
        }

        private void Eliminar()
        {
            if (dataGridViewEmpleados.SelectedRows.Count == 0)
                return;

            DataGridViewRow row = dataGridViewEmpleados.SelectedRows[0];
            Empleado empleado = (Empleado)row.Tag;

            if (MessageBox.Show(this, "Está seguro de eliminar el empleado " + empleado.Nombre + " " + empleado.Apellido + "?", "Confirmar Eliminar Empleado", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                FachadaServiciosEmpleado.GetInstancia().Eliminar(empleado);
                QuitarEmpleadoDeGrilla(row);
            }
        }
        #endregion

        #region Funcionalidad de la Grilla
        // actualiza fila en grilla
        private void ActualizarEmpleadoEnGrilla(DataGridViewRow row, Empleado empleado)
        {
            int indice = row.Index;
            QuitarEmpleadoDeGrilla(row);
            DataGridViewRow newRow = ConstruirRow(empleado);
            dataGridViewEmpleados.Rows.Insert(indice, newRow);
        }

        // quita la fila de la grilla
        private void QuitarEmpleadoDeGrilla(DataGridViewRow row)
        {
            CalcularEstadisticas();
            dataGridViewEmpleados.Rows.Remove(row);
        }

        // agrega fila a la grilla
        private void AgregarEmpleadoAGrilla(Empleado empleado)
        {
            DataGridViewRow row = ConstruirRow(empleado);
            dataGridViewEmpleados.Rows.Add(row);
            if (empleado is Vendedor)
                row.DefaultCellStyle.BackColor = System.Drawing.Color.LightYellow;
            else if (empleado is Administrativo)
                row.DefaultCellStyle.BackColor = System.Drawing.Color.LightSeaGreen;    
            else if (empleado is Operario)
                row.DefaultCellStyle.BackColor = System.Drawing.Color.LightBlue;

            row.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.DarkBlue;
        }

        // construye la fila en base a un objeto de tipo empleado
        private DataGridViewRow ConstruirRow(Empleado empleado)
        {
            // crea la fila
            DataGridViewRow row = new DataGridViewRow();
            if (empleado is Vendedor)
            {
                //Creamos las celdas de fila para el tipo vendedor (con comision)
                row.CreateCells(dataGridViewEmpleados, new string[] { empleado.Legajo.ToString(), empleado.Nombre, empleado.Apellido, empleado.Direccion, empleado.Telefono, ((Vendedor)empleado).Comision.ToString("0.00"), empleado.GetType().Name });
            }
            else
            {
                //Creamos las celdas de fila para el tipo empleado (sin comision)
                row.CreateCells(dataGridViewEmpleados, new string[] { empleado.Legajo.ToString(), empleado.Nombre, empleado.Apellido, empleado.Direccion, empleado.Telefono, "0", empleado.GetType().Name });
            }
            // relaciona el objeto de tipo Empleado con la fila
            row.Tag = empleado;

            // retorna la fila creada
            return row;
        }

        #endregion

    }
}
