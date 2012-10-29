using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControlAsistencia.Servicios
{
    public interface IServicio<T>
    {
        void Crear(T t);
        void Modificar(T t);
        void Eliminar(T t);
        List<T> BuscarTodos();
    }
}
