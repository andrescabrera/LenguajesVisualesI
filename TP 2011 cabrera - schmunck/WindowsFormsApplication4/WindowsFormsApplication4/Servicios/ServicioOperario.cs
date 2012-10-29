using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ControlAsistencia.Clases;
using ControlAsistencia.Daos;

namespace ControlAsistencia.Servicios
{
    public class ServicioOperario : Servicio<Operario>
    {
        private static ServicioOperario instancia;

        private ServicioOperario()
        { }

        public static ServicioOperario GetInstancia()
        {
            if (instancia == null)
                instancia = new ServicioOperario();

            return instancia;
        }

        public override void Crear(Operario operario)
        {
            using (PersistenceManager pm = GetPersistenceManager())
            {
                pm.Begin();

                pm.OperarioPersistenceManager.Alta(operario);

                pm.End();
            }
        }

        public override void Modificar(Operario operario)
        {
            using (PersistenceManager pm = GetPersistenceManager())
            {
                pm.Begin();

                pm.OperarioPersistenceManager.Modificar(operario);

                pm.End();
            }
        }

        public override void Eliminar(Operario operario)
        {
            using (PersistenceManager pm = GetPersistenceManager())
            {
                pm.Begin();

                pm.OperarioPersistenceManager.Eliminar(operario);

                pm.End();
            }
        }


        public override List<Operario> BuscarTodos()
        {
            using (PersistenceManager pm = GetPersistenceManager())
            {
                pm.Begin();

                List<Operario> operarios = pm.OperarioPersistenceManager.ListarTodos(); 

                pm.End();

                return operarios;
            }
        }
    }
}
