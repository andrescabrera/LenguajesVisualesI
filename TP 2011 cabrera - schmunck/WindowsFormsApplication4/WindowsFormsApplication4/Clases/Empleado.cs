using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControlAsistencia.Clases
{
    public abstract class Empleado
    {
        public long Id { get; set; }
        public long Legajo { get; set; }
        public String Nombre { get; set; }
        public String Apellido { get; set; }
        public String Telefono { get; set; }
        public String Direccion { get; set; }
        public CargaHoraria CargaHoraria { get; set; }
    }
}
