using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ControlAsistencia.Clases;

namespace ControlAsistencia.Data
{
    public interface IAdministrativoDAO
    {
        long Alta(Administrativo administrativo);
        void Eliminar(Administrativo administrativo);
        void Modificar(Administrativo administrativo);
        List<Administrativo> ListarTodos();
        Administrativo ObtenerPorId(long id);
    }
}
