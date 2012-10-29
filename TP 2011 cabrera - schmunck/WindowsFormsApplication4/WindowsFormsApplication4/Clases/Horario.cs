using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControlAsistencia.Clases
{
    public class Horario
    {
        public long Id { get; set; }
        public DayOfWeek Dia { get; set; }
        public DateTime HoraEntrada { get; set; }
        public DateTime HoraSalida { get; set; }
        public CargaHoraria CargaHoraria { get; set; }

        public Horario() { }

        public Horario(DayOfWeek dia, DateTime fechaDesde, DateTime fechaHasta)
        {
            this.Dia = dia;
            this.HoraEntrada = fechaDesde;
            this.HoraSalida = fechaHasta;
        }
    }
}
