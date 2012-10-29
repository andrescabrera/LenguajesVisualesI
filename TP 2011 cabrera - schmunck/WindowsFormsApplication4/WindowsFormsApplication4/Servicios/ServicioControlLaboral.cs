using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ControlAsistencia.Daos;
using ControlAsistencia.Clases;

namespace ControlAsistencia.Servicios
{
    public class ServicioControlLaboral : Servicio<ControlLaboral>
    {
        private static ServicioControlLaboral instancia;

        private ServicioControlLaboral()
        { }

        public static ServicioControlLaboral GetInstancia()
        {
            if (instancia == null)
                instancia = new ServicioControlLaboral();

            return instancia;
        }

        public override void Crear(ControlLaboral t)
        {
        }

        public override void Modificar(ControlLaboral t)
        {
        }

        public override void Eliminar(ControlLaboral t)
        {
        }

        public override List<ControlLaboral> BuscarTodos()
        {
            return null;
        }
    }
}
