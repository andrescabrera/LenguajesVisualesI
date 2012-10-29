using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ControlAsistencia.Clases;

namespace ControlAsistencia.Data
{
    public interface IVendedorDAO
    {
        long Alta(Vendedor vendedor);
        void Eliminar(Vendedor vendedor);
        void Modificar(Vendedor vendedor);
        List<Vendedor> ListarTodos();
        Vendedor ObtenerPorId(long id);
    }
}
