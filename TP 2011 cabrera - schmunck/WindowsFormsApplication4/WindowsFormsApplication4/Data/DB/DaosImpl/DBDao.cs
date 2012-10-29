using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ControlAsistencia.Daos;

namespace ControlAsistencia.Data.DB.DaosImpl
{
    public abstract class DBDao
    {
        protected IDBManager dbManager;
        protected DBEstrategiaPersistenceManager estrategia;

        public DBDao(DBEstrategiaPersistenceManager estrategia)
        {
            this.dbManager = estrategia.DBManager;
            this.estrategia = estrategia;
        }
    }
}
