using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ControlAsistencia.Clases;
using ControlAsistencia.Servicios;

namespace ControlAsistencia
{
    public partial class EditAusencia : Form
    {
        private Ausencia ausencia;
        private Empleado empleado;

        public Empleado GetEmpleado()
        {
            return empleado;
        }

        public Ausencia GetAusencia()
        {
            return ausencia;
        }

        public void SetAusencia(Ausencia ausencia)
        {
            this.ausencia = ausencia;
        }

        public EditAusencia(Empleado empleado)
        {
            this.empleado = empleado;
            InitializeComponent();
            dtpHorarioIngreso.Enabled = false;
            dtpHorarioEgreso.Enabled = false;
        }

        private void buttonCancelarClick(object sender, EventArgs e)
        {
            Cancelar();
        }

        private void Cancelar()
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void buttonAceptarClick(object sender, EventArgs e)
        {
            Aceptar();
        }

        private void Aceptar()
        {
            if (ValidarDatos())
            {
                if (ausencia == null)
                {
                    ausencia = new Ausencia();
                    ausencia.Empleado = empleado;
                    ausencia.FechaIngresoPautado = dtpDiaAusencia.Value.Date;
                    ausencia.FechaIngresoPautado = ausencia.FechaIngresoPautado.AddHours(dtpHorarioIngreso.Value.Hour);
                    ausencia.FechaIngresoPautado = ausencia.FechaIngresoPautado.AddMinutes(dtpHorarioIngreso.Value.Minute);

                    ausencia.FechaEgresoPautado = dtpDiaAusencia.Value.Date;
                    ausencia.FechaEgresoPautado = ausencia.FechaEgresoPautado.AddHours(dtpHorarioEgreso.Value.Hour);
                    ausencia.FechaEgresoPautado = ausencia.FechaEgresoPautado.AddMinutes(dtpHorarioEgreso.Value.Minute);
                    ausencia.Empleado = empleado;
                }
                
                ausencia.Motivo = textBoxMotivo.Text;

                this.DialogResult = DialogResult.Yes;
                this.Close();
            }
        }
        private bool ValidarDatos()
        {
            bool valid = true;
            errorProvider1.Clear();
            if (ausencia == null)
            {
                //Valido si el empleado tiene asistencias en el día
                if (ServicioAsistencia.GetInstancia().ComprobarExistenciaPorDia(empleado, dtpDiaAusencia.Value))
                {
                    valid = false;
                    errorProvider1.SetError(dtpDiaAusencia, "El empleado tiene asistencias cargadas el día seleccionado.");
                }

                //Valido si se encontró horario de un día programado 
                if (ServicioHorario.GetInstancia().BuscarHorarioPorEmpleadoYFecha(empleado, dtpDiaAusencia.Value) == null)
                {
                    valid = false;
                    errorProvider1.SetError(dtpDiaAusencia, "No se encontró ningún horario en el día seleccionado.");
                }

                //Valido si el dia de la ausencia es mayor o igual que el día de hoy.
                if (dtpDiaAusencia.Value.Date < DateTime.Now.Date)
                {
                    valid = false;
                    errorProvider1.SetError(dtpDiaAusencia, "El día no puede ser menor al actual.");
                }
            }
            return valid;
        }
        
        private void dtpDiaAusencia_ValueChanged(object sender, EventArgs e)
        {
            if (ausencia == null)
            {
                if (ValidarDatos())
                    SetDatosAlta();
            }
            else
            {
                SetDatosModificar();
            }
        }

        private void SetDatosAlta()
        {
            Horario horario = ServicioHorario.GetInstancia().BuscarHorarioPorEmpleadoYFecha(empleado, dtpDiaAusencia.Value);
            dtpHorarioIngreso.Value = horario.HoraEntrada;
            dtpHorarioEgreso.Value = horario.HoraSalida;
        }

        private void SetDatosModificar()
        {
            dtpHorarioIngreso.Value = ausencia.FechaIngresoPautado;
            dtpHorarioEgreso.Value = ausencia.FechaEgresoPautado;

            dtpDiaAusencia.Enabled = false;
            if (ausencia.FechaIngresoPautado.Date != DateTime.Parse("01/01/0001"))
                dtpHorarioIngreso.Value = ausencia.FechaIngresoPautado;
            if (ausencia.FechaEgresoPautado.Date != DateTime.Parse("01/01/0001"))
                dtpHorarioEgreso.Value = ausencia.FechaEgresoPautado;
            textBoxMotivo.Text = ausencia.Motivo;
        }
        private void FormRegistrarAusencia_Load(object sender, EventArgs e)
        {
            if (ausencia == null)
            {
                if (ValidarDatos())
                    SetDatosAlta();
            }
            else
            {
                SetDatosModificar();
            }
        }
    }
}
