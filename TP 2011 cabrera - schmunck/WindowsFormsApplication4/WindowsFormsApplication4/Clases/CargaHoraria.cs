using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControlAsistencia.Clases
{
    public class CargaHoraria
    {
        public long Id { get; set; }
        public List<Horario> Horarios { get; set; }
        public Empleado Empleado { get; set; }

        public CargaHoraria()
        {
            Horarios = new List<Horario>();
        }
    }
}
