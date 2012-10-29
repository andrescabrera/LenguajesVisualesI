using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControlAsistencia.Clases
{
    public class ControlLaboral
    {
        public long Id { get; set; }
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }
        List<Asistencia> asistenciasControladas { get; set; }
        List<Ausencia> ausenciaControladas { get; set; }
    }
}
