using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ControlAsistencia.Clases;

namespace ControlAsistencia.Data
{
    public interface IControlLaboralDAO
    {
        long Alta(ControlLaboral controlLaboral);
        void Eliminar(ControlLaboral controlLaboral);
        void Modificar(ControlLaboral controlLaboral);
        List<ControlLaboral> ListarTodos();
    }
}
