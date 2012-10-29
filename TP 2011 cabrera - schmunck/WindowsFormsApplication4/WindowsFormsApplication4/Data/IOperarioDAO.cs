using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ControlAsistencia.Clases;

namespace ControlAsistencia.Data
{
    public interface IOperarioDAO
    {
        long Alta(Operario operario);
        void Eliminar(Operario operario);
        void Modificar(Operario operario);
        List<Operario> ListarTodos();
        Operario ObtenerPorId(long id);
    }
}
