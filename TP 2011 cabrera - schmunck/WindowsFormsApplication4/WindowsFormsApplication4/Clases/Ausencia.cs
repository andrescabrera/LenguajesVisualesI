using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ControlAsistencia.Servicios;

namespace ControlAsistencia.Clases
{
    public class Ausencia
    {
        public long Id { get; set; }
        public String Motivo { get; set; }
        public DateTime FechaIngresoPautado { get; set; }
        public DateTime FechaEgresoPautado { get; set; }
        public Empleado Empleado { get; set; }

        
    }
}
