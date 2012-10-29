using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ControlAsistencia.Clases;

namespace ControlAsistencia.Clases
{
    public class Asistencia
    {
        public long Id { get; set; }
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }
        public DateTime FechaIngresoPautado { get; set; }
        public DateTime FechaEgresoPautado { get; set; }
        public Empleado Empleado { get; set; }

        public Asistencia() { }

        public Asistencia(Empleado empleado)
        {
            DayOfWeek hoy = DateTime.Now.DayOfWeek;

            FechaDesde = DateTime.Now;

            if (empleado.CargaHoraria != null)
            {
                foreach (Horario unHorario in empleado.CargaHoraria.Horarios)
                {
                    if (unHorario.Dia == hoy)
                    {
                        //TODO Hacemos de cuenta que no se repiten los días de la semana
                        //por CargaHoraria -VALIDAR- y nos quedamos con el ultimo
                        FechaIngresoPautado = DateTime.Now.Date;
                        FechaIngresoPautado = FechaIngresoPautado.AddHours(unHorario.HoraEntrada.Hour);
                        FechaIngresoPautado = FechaIngresoPautado.AddMinutes(unHorario.HoraEntrada.Minute);
                        FechaIngresoPautado = FechaIngresoPautado.AddSeconds(unHorario.HoraEntrada.Second);

                        FechaEgresoPautado = DateTime.Now.Date;
                        FechaEgresoPautado = FechaEgresoPautado.AddHours(unHorario.HoraSalida.Hour);
                        FechaEgresoPautado = FechaEgresoPautado.AddMinutes(unHorario.HoraSalida.Minute);
                        FechaEgresoPautado = FechaEgresoPautado.AddSeconds(unHorario.HoraSalida.Second);
                    }
                }
            }
        }        
    }
}
