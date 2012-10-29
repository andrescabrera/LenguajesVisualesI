using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ControlAsistencia.Clases;

namespace ControlAsistencia.Data
{
    public interface IAsistenciaDAO
    {
        long Alta(Asistencia asistencia);
        void Eliminar(Asistencia asistencia);
        void Modificar(Asistencia asistencia);
        List<Asistencia> ListarTodos();
        Asistencia ObtenerPorId(long id);
        List<Asistencia> ListarPorIdOperario(long id);
        List<Asistencia> ListarPorIdAdministrativo(long id);
        List<Asistencia> ListarPorIdVendedor(long p);
    }
}
