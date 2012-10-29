using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ControlAsistencia.Clases;

namespace ControlAsistencia.Data
{
    public interface IHorarioDAO
    {
        long Alta(Horario horario);
        void Eliminar(Horario horario);
        void Modificar(Horario horario);
        List<Horario> ListarTodos();
        List<Horario> ListarPorIdDeCargaHoraria(long idCargaHoraria);
        Horario ObtenerPorId(long id);
    }
}
