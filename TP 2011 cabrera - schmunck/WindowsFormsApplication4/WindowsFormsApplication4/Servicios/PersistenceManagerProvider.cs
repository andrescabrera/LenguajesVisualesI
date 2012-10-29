using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ControlAsistencia.Daos;

namespace ControlAsistencia.Servicios
{
    public class PersistenceManagerProvider
    {
        private static PersistenceManagerProvider instancia;
        public EstrategiaPersistenceManager Estrategia { get; set; }

        private PersistenceManagerProvider()
        {
            Estrategia = new DBEstrategiaPersistenceManager();
        }

        public static PersistenceManagerProvider GetInstancia()
        {
            if (instancia == null)
            {
                instancia = new PersistenceManagerProvider();
            }

            return instancia;
        }
    }
}
