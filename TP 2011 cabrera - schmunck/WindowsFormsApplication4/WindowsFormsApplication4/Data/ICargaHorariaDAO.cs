using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ControlAsistencia.Clases;

namespace ControlAsistencia.Data
{
    public interface ICargaHorariaDAO
    {
        long Alta(CargaHoraria cargaHoraria);
        void Eliminar(CargaHoraria cargaHoraria);
        void Modificar(CargaHoraria cargaHoraria);
        List<CargaHoraria> ListarTodos();
        CargaHoraria ObtenerPorId(long id);
    }
}
