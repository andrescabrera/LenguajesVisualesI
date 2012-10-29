using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ControlAsistencia.Daos;

namespace ControlAsistencia.Servicios
{
    public abstract class Servicio<T> : IServicio<T>
    {
        protected PersistenceManager GetPersistenceManager()
        {
            return new PersistenceManager(PersistenceManagerProvider.GetInstancia().Estrategia);
        }

        public abstract void Crear(T t);
        public abstract void Modificar(T t);
        public abstract void Eliminar(T t);
        public abstract List<T> BuscarTodos();
    }
}
