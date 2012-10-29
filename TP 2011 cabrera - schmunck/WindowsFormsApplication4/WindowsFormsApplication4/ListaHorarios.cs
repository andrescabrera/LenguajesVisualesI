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
using System.Globalization;

namespace ControlAsistencia
{
    public partial class ListaHorarios : Form
    {
        //menu contextual
        private CargaHoraria cargaHorariaEmpleado;
        private Form formPadre;
        private ContextMenu cm;
        private DataGridViewHelper gridHelper;

        public CargaHoraria GetCargaHoraria()
        {
            return cargaHorariaEmpleado;
        }

        public void SetCargaHorariaEmpleado(CargaHoraria cargaHorariaEmpleado)
        {
            this.cargaHorariaEmpleado = cargaHorariaEmpleado;
        }

        public ListaHorarios(CargaHoraria cargaHorariaEmpleado, Form formPadre)
        {
            this.formPadre = formPadre;
            this.cargaHorariaEmpleado = cargaHorariaEmpleado;
            InitializeComponent();

            //creo el menu contextual
            cm = new ContextMenu();

            cm.MenuItems.Add(new MenuItem("Agregar Horario", AgregarHorarioEventHandler));
            cm.MenuItems.Add(new MenuItem("Modificar Horario", ModificarHorarioEventHandler));
            cm.MenuItems.Add(new MenuItem("Eliminar Horario", EliminarHorarioEventHandler));

            gridHelper = new DataGridViewHelper { Grid = dataGridViewHorarios, ContextMenu = cm };
            gridHelper.AddSortCompareHandler();
            gridHelper.AddContextMenuHandler();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (cargaHorariaEmpleado == null)
            {
                cargaHorariaEmpleado = new CargaHoraria();
                ServicioCargaHoraria.GetInstancia().Crear(cargaHorariaEmpleado);
            }
            else
            {
                foreach (Horario horario in cargaHorariaEmpleado.Horarios)
                    AgregarHorarioAGrilla(horario);
            }
        }

        #region Eventos

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

        private void AgregarHorarioEventHandler(object sender, EventArgs e)
        {
            Agregar();
        }

        private void EliminarHorarioEventHandler(object sender, EventArgs e)
        {
            Eliminar();
        }

        private void ModificarHorarioEventHandler(object sender, EventArgs e)
        {
            Modificar();
        }

        #endregion

        #region Funcionalidad ABM
        //Agrega un horario
        private void Agregar()
        {
            EditarHorarios form = new EditarHorarios(cargaHorariaEmpleado.Horarios);
            if (DialogResult.OK == form.ShowDialog(this))
            {
                List<Horario> horarios = form.GetHorarios();
                cargaHorariaEmpleado.Horarios.AddRange(horarios);
                foreach(Horario unHorario in horarios)
                {
                    unHorario.CargaHoraria = cargaHorariaEmpleado;
                    ServicioHorario.GetInstancia().Crear(unHorario);
                    AgregarHorarioAGrilla(unHorario);
                }                
            }
        }

        // modifica horario
        private void Modificar()
        {
            if (dataGridViewHorarios.SelectedRows.Count == 0)
                return;

            DataGridViewRow row = dataGridViewHorarios.SelectedRows[0];
            Horario horario = (Horario)row.Tag;

            EditarHorarios form = new EditarHorarios(horario);
            if (DialogResult.OK == form.ShowDialog(this))
            {
                horario = form.GetHorario();
                ServicioHorario.GetInstancia().Modificar(horario);
                ActualizarHorarioEnGrilla(row, horario);
            }
        }

        private void Eliminar()
        {            
            if (dataGridViewHorarios.SelectedRows.Count == 0)
                return;

            DataGridViewRow row = dataGridViewHorarios.SelectedRows[0];
            Horario horario = (Horario)row.Tag;
            cargaHorariaEmpleado.Horarios.Remove(horario);
            ServicioHorario.GetInstancia().Eliminar(horario);
            QuitarHorarioDeGrilla(row);
        }
        #endregion

        #region Funcionalidad de la Grilla
        // actualiza fila en grilla
        private void ActualizarHorarioEnGrilla(DataGridViewRow row, Horario horario)
        {
            int indice = row.Index;
            QuitarHorarioDeGrilla(row);
            DataGridViewRow newRow = ConstruirRow(horario);
            dataGridViewHorarios.Rows.Insert(indice, newRow);
        }

        // quita la fila de la grilla
        private void QuitarHorarioDeGrilla(DataGridViewRow row)
        {
            dataGridViewHorarios.Rows.Remove(row);
        }

        // agrega fila a la grilla
        private void AgregarHorarioAGrilla(Horario horario)
        {
            // crea una fila
            DataGridViewRow row = ConstruirRow(horario);
            // agrega la fila a la grilla
            dataGridViewHorarios.Rows.Add(row);
        }

        // construye la fila en base a un objeto de tipo horario
        private DataGridViewRow ConstruirRow(Horario horario)
        {
            // crea la fila
            DataGridViewRow row = new DataGridViewRow();
            CultureInfo castellano = new CultureInfo("es-AR");
            //Creamos las celdas de fila para el tipo vendedor (con comision)
            row.CreateCells(dataGridViewHorarios, new string[] { castellano.DateTimeFormat.DayNames[(int)horario.Dia], horario.HoraEntrada.TimeOfDay.ToString(), horario.HoraSalida.TimeOfDay.ToString() });
            
            // relaciona el objeto de tipo Horario con la fila
            row.Tag = horario;

            // retorna la fila creada
            return row;
        }

        #endregion

        private void ListaHorarios_FormClosing(object sender, FormClosingEventArgs e)
        {
            formPadre.Visible = true;
            formPadre.Show();
        }

        private void dataGridViewHorarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Modificar();
        }

        private void dataGridViewHorarios_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
            else if (e.KeyCode == Keys.Delete)
                Eliminar();
        }

        private void modificarHorarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Modificar();
        }

        private void eliminarHorarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Eliminar();
        }

        private void agregarHorarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Agregar();
        }
    }
}
