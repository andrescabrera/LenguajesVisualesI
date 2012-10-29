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
using System.Drawing.Drawing2D;
using System.Globalization;

namespace ControlAsistencia
{
    public partial class ListaPresentismo : Form
    {
        public Empleado Empleado { get; set; }
        private List<Asistencia> asistencias;
        private List<Ausencia> ausencias;

        private ContextMenu cm; //menu contextual
        private DataGridViewHelper helper = new DataGridViewHelper();
        
        public ListaPresentismo(Empleado empleado)
        {
            InitializeComponent();
            this.Empleado = empleado;
            this.asistencias = ServicioAsistencia.GetInstancia().BuscarPorEmpleado(Empleado, dtpFechaDesde.Value.Date, dtpFechaHasta.Value.Date);
            this.ausencias = ServicioAusencia.GetInstancia().BuscarPorEmpleado(Empleado, dtpFechaDesde.Value.Date, dtpFechaHasta.Value.Date);
            Tipo.ValueType = typeof(String);
            Fecha.ValueType = typeof(DateTime);
            HoraEntradaPautada.ValueType = typeof(DateTime);
            HoraSalidaPautada.ValueType = typeof(DateTime);
            HoraEntrada.ValueType = typeof(DateTime);
            HoraSalida.ValueType = typeof(DateTime);

            //creo el menu contextual
            cm = new ContextMenu();

            cm.MenuItems.Add(new MenuItem("Registrar Ingreso", RegistrarIngresoEventHandler));
            cm.MenuItems.Add(new MenuItem("Registrar Egreso", RegistrarEgresoEventHandler));
            cm.MenuItems.Add(new MenuItem("Registrar Ausencia", AgregarAusenciaEventHandler));
            cm.MenuItems.Add(new MenuItem("Eliminar Registro", EliminarRegistroEventHandler));

            helper = new DataGridViewHelper { Grid = dataGridViewPresentismo, ContextMenu = cm };
            helper.AddSortCompareHandler();
            helper.AddContextMenuHandler();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.labelNombreEmpleado.Text = Empleado.Nombre + " " + Empleado.Apellido;
            this.labelLegajo.Text = Empleado.Legajo.ToString();

            CrearGrilla();
        }

        private void CrearGrilla()
        {
            TimeSpan timeSpanTrabajadas = new TimeSpan();
            TimeSpan timeSpanPautadas = new TimeSpan();

            int totalConcurrenciasPautadas = asistencias.Count + ausencias.Count;
            int totalIncumplimientoIngreso = ausencias.Count;
            int totalIncumplimientoEgreso = totalIncumplimientoIngreso; 
            foreach (Asistencia a in asistencias)
            {
                if (a.FechaHasta > a.FechaDesde)
                    timeSpanTrabajadas = timeSpanTrabajadas.Add(a.FechaHasta.TimeOfDay - a.FechaDesde.TimeOfDay);
                if (a.FechaEgresoPautado > a.FechaIngresoPautado)
                    timeSpanPautadas = timeSpanPautadas.Add(a.FechaEgresoPautado.TimeOfDay - a.FechaIngresoPautado.TimeOfDay);
                if (a.FechaDesde.TimeOfDay > a.FechaIngresoPautado.TimeOfDay)
                    totalIncumplimientoIngreso++;
                if (a.FechaHasta != DateTime.Parse("01/01/0001") && a.FechaHasta.TimeOfDay < a.FechaEgresoPautado.TimeOfDay)
                    totalIncumplimientoEgreso++;
                AgregarAsistenciaAGrilla(a);
            }
            foreach (Ausencia a in ausencias)
            {
                if(a.FechaEgresoPautado > a.FechaIngresoPautado)
                    timeSpanPautadas = timeSpanPautadas.Add(a.FechaEgresoPautado - a.FechaIngresoPautado);
                AgregarAusenciaAGrilla(a);
            }
            
            double porcentajeCumplimiento = 0;
            double vecesQueLlegoBien = totalConcurrenciasPautadas - totalIncumplimientoIngreso;
            
            porcentajeCumplimiento = (vecesQueLlegoBien / totalConcurrenciasPautadas) * 100;
            double totalHorasTrabajadas = timeSpanTrabajadas.TotalHours;
            double totalHorasPautadas = timeSpanPautadas.TotalHours;
            cantHorasTrabajadas.Text = totalHorasTrabajadas.ToString("0.00");
            cantHorasPautadas.Text = totalHorasPautadas.ToString("0.00");
            cumpHorario.Text = porcentajeCumplimiento.ToString("0.00") + "%";
            if ((totalHorasTrabajadas - totalHorasPautadas) > 0)
                horasExtras.Text = (totalHorasTrabajadas - totalHorasPautadas).ToString();
            else
                horasExtras.Text = "-";
            impIngreso.Text = totalIncumplimientoIngreso.ToString();
            impEgreso.Text = totalIncumplimientoEgreso.ToString();
        }

        private void AgregarAusenciaAGrilla(Ausencia a)
        {
            if (a.FechaIngresoPautado.Date >= dtpFechaDesde.Value.Date && a.FechaIngresoPautado.Date <= dtpFechaHasta.Value.Date)
            {
                String[] textoFila = new String[] { FechaAsString(a.FechaIngresoPautado), a.FechaIngresoPautado.ToString("HH: mm"), a.FechaEgresoPautado.ToString("HH: mm"), null, null, a.GetType().Name };
                AgregarAGrilla<Ausencia>(textoFila, a);
            }
        }

        private void AgregarAsistenciaAGrilla(Asistencia a)
        {
            if (a.FechaIngresoPautado.Date >= dtpFechaDesde.Value.Date && a.FechaIngresoPautado.Date <= dtpFechaHasta.Value.Date)
            {
                String[] textoFila = new String[] { FechaAsString(a.FechaIngresoPautado), a.FechaIngresoPautado.ToString("HH: mm"), a.FechaEgresoPautado.ToString("HH: mm"), a.FechaDesde.ToString("HH: mm"), a.FechaHasta.ToString("HH: mm"), a.GetType().Name };
                AgregarAGrilla<Asistencia>(textoFila, a);
            }
        }

        #region Eventos
        
        private void buttonEliminarClick(object sender, EventArgs e)
        {
            Eliminar();
        }

        private void AgregarAusenciaEventHandler(object sender, EventArgs e)
        {
            RegistrarAusencia();
        }

        private void EliminarRegistroEventHandler(object sender, EventArgs e)
        {
            Eliminar();
        }

        #endregion

        #region Funcionalidad ABM

        // modifica asistencia o ausencia
        private void Modificar()
        {
            if (dataGridViewPresentismo.SelectedRows.Count == 0)
                return;

            DataGridViewRow row = dataGridViewPresentismo.SelectedRows[0];

            EditAusencia form = new EditAusencia(Empleado);
            Ausencia ausencia = null;

            if (row.Tag is Ausencia)
            {
                ausencia = (Ausencia)row.Tag;
                ausencias.Remove(ausencia);
                form.SetAusencia(ausencia);

                if (DialogResult.Yes == form.ShowDialog(this))
                {
                    if (ausencia != null)
                    {
                        ServicioAusencia.GetInstancia().Modificar(form.GetAusencia());
                        ausencias.Add(form.GetAusencia());
                        dataGridViewPresentismo.Rows.Clear();
                        CrearGrilla();
                        //ActualizarFila(ausencia);
                    }
                }
            }
        }

        private void Eliminar()
        {
            if (dataGridViewPresentismo.Rows.Count > 0)
            {
                DataGridViewRow row = dataGridViewPresentismo.SelectedRows[0];
                if (row.Tag is Ausencia)
                {
                    ausencias.Remove((Ausencia)row.Tag);
                    //EliminarDeEstadisticas((Ausencia)row.Tag);                    
                    ServicioAusencia.GetInstancia().Eliminar((Ausencia)row.Tag);
                }
                else if (row.Tag is Asistencia)
                {
                    asistencias.Remove((Asistencia)row.Tag);
                    //EliminarDeEstadisticas((Asistencia)row.Tag);                    
                    ServicioAsistencia.GetInstancia().Eliminar((Asistencia)row.Tag);
                }

                dataGridViewPresentismo.Rows.Clear();
                CrearGrilla();

                //QuitarFilaDeGrilla(row);
                
                //if (datagridviewpresentismo.rowcount > 0)
                //    datagridviewpresentismo.rows[0].selected = true;
            }
        }

        #endregion

        private void dataGridViewPresentismo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Modificar();
        }

        public void RegistrarIngresoEventHandler(object sender, EventArgs e)
        {
            RegistrarIngreso();
        }

        public void RegistrarEgresoEventHandler(object sender, EventArgs e)
        {
            RegistrarSalida();
        }

        private void buttonRegistrarIngreso_Click(object sender, EventArgs e)
        {
            RegistrarIngreso();
        }

        private void RegistrarIngreso()
        {
            if(ValidarAsistencias())
                CrearAsistencia();
            
        }

        private bool ValidarAsistencias()
        {
            bool valid = false;
            if (Empleado.CargaHoraria != null)
            {
                if (ServicioHorario.GetInstancia().BuscarHorarioPorEmpleadoYFecha(Empleado, DateTime.Now) != null)
                {
                    if (ServicioAsistencia.GetInstancia().BuscarPrimerAsistenciaSinHoraSalida(Empleado) == null)
                    {
                        valid = true;
                    }
                    else
                    {
                        MessageBox.Show(this, "El empleado no registro su salida.", "Error al crear asistencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show(this, "No es un día laboral para el empleado.", "Error al crear asistencia", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                }
            }
            else
            {
                MessageBox.Show(this, "El empleado no tiene horarios asignados.", "Error al crear asistencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return valid;
        }

        private void CrearAsistencia()
        {
            Asistencia asistencia = new Asistencia(Empleado);
            asistencia.Empleado = Empleado;
            ServicioAsistencia.GetInstancia().Crear(asistencia);
            asistencias.Add(asistencia);
            dataGridViewPresentismo.Rows.Clear();
            CrearGrilla();
            MessageBox.Show("Registro Correcto");
        }

        private void buttonRegistrarSalida_Click(object sender, EventArgs e)
        {
            RegistrarSalida();
        }

        private void buttonRegistrarAusencia_Click(object sender, EventArgs e)
        {
            RegistrarAusencia();
        }

        private void RegistrarAusencia()
        {
            EditAusencia form = new EditAusencia(Empleado);

            if (DialogResult.Yes == form.ShowDialog(this))
            {
                ServicioAusencia.GetInstancia().Crear(form.GetAusencia());
                ausencias.Add(form.GetAusencia());
                dataGridViewPresentismo.Rows.Clear();
                CrearGrilla();
                //AgregarAusenciaAGrilla(form.GetAusencia());
            }
        }

        private void RegistrarSalida()
        {
            Asistencia asistenciaActual;
            asistenciaActual = ServicioAsistencia.GetInstancia().BuscarPrimerAsistenciaSinHoraSalida(Empleado);
            if (asistenciaActual == null)
            {
                MessageBox.Show(this, "No se encontró ninguna asistencia sin registro de salida para " + Empleado.Nombre + " " + Empleado.Apellido + ".", "Registrar Egreso", MessageBoxButtons.OK);
            }
            else if (MessageBox.Show(this, "Desea registrar el egreso del empleado " + Empleado.Nombre + " ?", "Registrar Egreso", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                asistenciaActual.FechaHasta = DateTime.Now;
                ServicioAsistencia.GetInstancia().Modificar(asistenciaActual);
                //Deberia recalcular las estadisticas...
                asistencias = ServicioAsistencia.GetInstancia().BuscarPorEmpleado(Empleado, dtpFechaDesde.Value.Date, dtpFechaHasta.Value.Date);
                ausencias = ServicioAusencia.GetInstancia().BuscarPorEmpleado(Empleado, dtpFechaDesde.Value.Date, dtpFechaHasta.Value.Date);
                dataGridViewPresentismo.Rows.Clear();
                CrearGrilla();
                //ActualizarFila(asistenciaActual);
            }
        }        

        private void dataGridViewPresentismo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                Eliminar();
            else if (e.KeyCode == Keys.Enter)
                Modificar();
        }

        private void registrarEntradaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistrarIngreso();
        }

        private void registrarSalidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistrarSalida();
        }

        private void registrarAusenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistrarAusencia();
        }

        #region Funcionalidad de la Grilla
        public void ActualizarEnGrilla<T>(DataGridViewRow row, String[] rowContent, T t)
        {
            int indice = row.Index;
            QuitarFilaDeGrilla(row);
            DataGridViewRow newRow = ConstruirRow(rowContent, t);
            dataGridViewPresentismo.Rows.Insert(indice, newRow);
        }

        public void QuitarFilaDeGrilla(DataGridViewRow row)
        {
            dataGridViewPresentismo.Rows.Remove(row);
        }

        public void AgregarAGrilla<T>(String[] rowContent, T t)
        {
            DataGridViewRow row = ConstruirRow<T>(rowContent, t);
            dataGridViewPresentismo.Rows.Add(row);
            if (row.Tag is Asistencia)
                row.DefaultCellStyle.BackColor = System.Drawing.Color.Beige;
            else if (row.Tag is Ausencia)
                row.DefaultCellStyle.BackColor = System.Drawing.Color.DeepPink;
        }

        private DataGridViewRow ConstruirRow<T>(String[] rowContent, T t)
        {
            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(dataGridViewPresentismo, rowContent);
            row.Tag = t;
            return row;
        }

        private String FechaAsString(DateTime fecha)
        {
            if (fecha.Date != DateTime.Parse("01/01/0001"))
                return fecha.ToString("dd/MM/yyyy");
            else return "";
        }

        private void ActualizarFila(Ausencia ausencia)
        {
            for (int i = 0; i < dataGridViewPresentismo.Rows.Count; i += 1)
            {
                if (dataGridViewPresentismo.Rows[i].Tag is Ausencia)
                {
                    Ausencia rowTag = (Ausencia)dataGridViewPresentismo.Rows[i].Tag;
                    if (rowTag.Id == ausencia.Id)
                    {
                        QuitarFilaDeGrilla(dataGridViewPresentismo.Rows[i]);
                        AgregarAusenciaAGrilla(ausencia);
                    }
                }
            }
        }

        private void ActualizarFila(Asistencia asistencia)
        {
            for (int i = 0; i < dataGridViewPresentismo.Rows.Count; i += 1)
            {
                if (dataGridViewPresentismo.Rows[i].Tag is Asistencia)
                {
                    Asistencia rowTag = (Asistencia)dataGridViewPresentismo.Rows[i].Tag;
                    if (rowTag.Id == asistencia.Id)
                    {
                        QuitarFilaDeGrilla(dataGridViewPresentismo.Rows[i]);
                        AgregarAsistenciaAGrilla(asistencia);
                    }
                }
            }
        }

        #endregion

        private void dataGridViewPresentismo_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Modificar();
        }

        private void dtpFechaDesde_ValueChanged(object sender, EventArgs e)
        {
            CambioFechasFiltros();
        }

        private void dtpFechaHasta_ValueChanged(object sender, EventArgs e)
        {
            CambioFechasFiltros();
        }

        private void CambioFechasFiltros()
        {
            if (ValidarFiltros())
            {
                this.asistencias = ServicioAsistencia.GetInstancia().BuscarPorEmpleado(Empleado, dtpFechaDesde.Value.Date, dtpFechaHasta.Value.Date);
                this.ausencias = ServicioAusencia.GetInstancia().BuscarPorEmpleado(Empleado, dtpFechaDesde.Value.Date, dtpFechaHasta.Value.Date);
                dataGridViewPresentismo.Rows.Clear();
                CrearGrilla();
            }
        }

        private bool ValidarFiltros()
        {
            bool valid = true;
            errorProvider1.Clear();
            if (dtpFechaDesde.Value.Date > dtpFechaHasta.Value.Date)
            {
                valid = false;
                errorProvider1.SetError(dtpFechaDesde, "Fecha desde no puede ser mayor a la fecha hasta");
                errorProvider1.SetError(dtpFechaHasta, "Fecha hasta no puede ser menor a la fecha desde");
            }
            return valid;
        }

        private void ListaPresentismo_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
