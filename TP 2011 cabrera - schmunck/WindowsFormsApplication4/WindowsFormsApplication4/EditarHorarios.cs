using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ControlAsistencia.Clases;

namespace ControlAsistencia
{
    public partial class EditarHorarios : Form
    {
        private List<Horario> horarios;
        private Horario horario;

        public List<Horario> GetHorarios()
        {
            return horarios;
        }

        public Horario GetHorario()
        {
            return horario;
        }

        public EditarHorarios(List<Horario> horarios)
        {
            //Estoy dando de alta horarios
            this.horarios = horarios;
            InitializeComponent();
            DesactivarDiasCargados();
        }

        private void DesactivarDiasCargados()
        {
            if (horarios.Count == 0)
            {
                checkBoxLunes.Checked = true;
                checkBoxMartes.Checked = true;
                checkBoxMiercoles.Checked = true;
                checkBoxJueves.Checked = true;
                checkBoxViernes.Checked = true;
            }
            foreach(Horario unHorario in horarios)
            {
                if (unHorario.Dia == DayOfWeek.Monday)
                    checkBoxLunes.Enabled = false;
                if(unHorario.Dia == DayOfWeek.Tuesday)
                    checkBoxMartes.Enabled = false;
                if (unHorario.Dia == DayOfWeek.Wednesday)
                    checkBoxMiercoles.Enabled = false;
                if (unHorario.Dia == DayOfWeek.Thursday)
                    checkBoxJueves.Enabled = false;
                if (unHorario.Dia == DayOfWeek.Friday)
                    checkBoxViernes.Enabled = false;
                if (unHorario.Dia == DayOfWeek.Saturday)
                    checkBoxSabado.Enabled = false;
                if (unHorario.Dia == DayOfWeek.Sunday)
                    checkBoxDomingo.Enabled = false;
            }
        }

        public EditarHorarios(Horario horario)
        {
            //Estoy modificando un horario
            this.horario = horario;
            InitializeComponent();
            SetDatosEnControlesModificar();
        }
        
        private void SetDatosEnControlesModificar()
        {
            checkBoxLunes.Enabled = false;
            checkBoxMartes.Enabled = false;
            checkBoxMiercoles.Enabled = false;
            checkBoxJueves.Enabled = false;
            checkBoxViernes.Enabled = false;
            checkBoxSabado.Enabled = false;
            checkBoxDomingo.Enabled = false;

            if (horario.Dia == DayOfWeek.Monday)
            {
                checkBoxLunes.Checked = true;
            }
            else if (horario.Dia == DayOfWeek.Tuesday)
            {
                checkBoxMartes.Checked = true;
            }
            else if (horario.Dia == DayOfWeek.Wednesday)
            {
                checkBoxMiercoles.Checked = true;
            }
            else if (horario.Dia == DayOfWeek.Thursday)
            {
                checkBoxJueves.Checked = true;
            }
            else if (horario.Dia == DayOfWeek.Friday)
            {
                checkBoxViernes.Checked = true;
            }
            else if (horario.Dia == DayOfWeek.Saturday)
            {
                checkBoxSabado.Checked = true;
            }
            else
            {
                checkBoxDomingo.Checked = true;
            }

            dtpHorarioIngreso.Value = horario.HoraEntrada;
            dtpHorarioIngreso.Value = horario.HoraSalida;
        }

        private void buttonAceptarClick(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (horario == null)
                {
                    //Estoy creando una lista de horarios
                    horarios = new List<Horario>();
                    Horario unHorario;
                    unHorario = new Horario();
                    if (checkBoxLunes.Checked)
                    {
                        horarios.Add(new Horario(DayOfWeek.Monday, dtpHorarioIngreso.Value, dtpHorarioEgreso.Value));
                    }
                    if (checkBoxMartes.Checked)
                    {
                        horarios.Add(new Horario(DayOfWeek.Tuesday, dtpHorarioIngreso.Value, dtpHorarioEgreso.Value));
                    }
                    if (checkBoxMiercoles.Checked)
                    {
                        horarios.Add(new Horario(DayOfWeek.Wednesday, dtpHorarioIngreso.Value, dtpHorarioEgreso.Value));
                    }
                    if (checkBoxJueves.Checked)
                    {
                        horarios.Add(new Horario(DayOfWeek.Thursday, dtpHorarioIngreso.Value, dtpHorarioEgreso.Value));
                    }
                    if (checkBoxViernes.Checked)
                    {
                        horarios.Add(new Horario(DayOfWeek.Friday, dtpHorarioIngreso.Value, dtpHorarioEgreso.Value));
                    }
                    if (checkBoxSabado.Checked)
                    {
                        horarios.Add(new Horario(DayOfWeek.Saturday, dtpHorarioIngreso.Value, dtpHorarioEgreso.Value));
                    }
                    if (checkBoxDomingo.Checked)
                    {
                        horarios.Add(new Horario(DayOfWeek.Sunday, dtpHorarioIngreso.Value, dtpHorarioEgreso.Value));
                    }

                    if (horarios.Count() == 0)
                    {
                        errorProvider1.SetError(labelDiaLaboral, "Debe elegir al menos un día laboral.");
                    }
                    else
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                else
                {
                    //Estoy modificando un horario
                    if (checkBoxLunes.Checked)
                        horario.Dia = DayOfWeek.Monday;
                    else if (checkBoxMartes.Checked)
                        horario.Dia = DayOfWeek.Tuesday;
                    else if (checkBoxMiercoles.Checked)
                        horario.Dia = DayOfWeek.Wednesday;
                    else if (checkBoxJueves.Checked)
                        horario.Dia = DayOfWeek.Thursday;
                    else if (checkBoxViernes.Checked)
                        horario.Dia = DayOfWeek.Friday;
                    else if (checkBoxSabado.Checked)
                        horario.Dia = DayOfWeek.Saturday;
                    else
                        horario.Dia = DayOfWeek.Sunday;

                    horario.HoraEntrada = dtpHorarioIngreso.Value;
                    horario.HoraSalida = dtpHorarioEgreso.Value;

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private bool ValidarDatos() 
        {
            bool valid = true;
            errorProvider1.Clear();
            
            //Valido los horarios
            if (dtpHorarioEgreso.Value <= dtpHorarioIngreso.Value)
            {
                valid = false;
                errorProvider1.SetError(dtpHorarioIngreso, "El horario de entrada es igual ó mayor al horario de salida.");
            }

            return valid;
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void EditarHorariosLoad(object sender, EventArgs e)
        {
            dtpHorarioIngreso.Format = DateTimePickerFormat.Time;
            dtpHorarioIngreso.ShowUpDown = true;

            dtpHorarioEgreso.Format = DateTimePickerFormat.Time;
            dtpHorarioEgreso.ShowUpDown = true;
            
        }

        private void EditarHorarios_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
