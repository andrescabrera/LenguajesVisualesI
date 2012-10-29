using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ControlAsistencia.Clases;

namespace ControlAsistencia.Data
{
    public interface IAusenciaDAO
    {
        long Alta(Ausencia ausencia);
        void Eliminar(Ausencia ausencia);
        void Modificar(Ausencia ausencia);
        List<Ausencia> ListarTodos();
        Ausencia ObtenerPorId(long id);

        List<Ausencia> ListarPorIdVendedor(long p);

        List<Ausencia> ListarPorIdOperario(long p);

        List<Ausencia> ListarPorIdAdministrativo(long p);
    }
}
