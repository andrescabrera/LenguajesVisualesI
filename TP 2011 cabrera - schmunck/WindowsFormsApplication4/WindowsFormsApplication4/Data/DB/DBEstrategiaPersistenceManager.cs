using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ControlAsistencia.Clases;
using ControlAsistencia.Daos;
using ControlAsistencia.Data.DB.DBManagers;
using ControlAsistencia.Data.DB.DaosImpl;
using ControlAsistencia.Data;
using Controlausencia.Data.DB.DaosImpl;

namespace ControlAsistencia.Daos
{
    public class DBEstrategiaPersistenceManager : EstrategiaPersistenceManager
    {
        public IDBManager DBManager { get; set; }

        public DBEstrategiaPersistenceManager()
        {
            DBManager = new MySqlDBManager();
        }

        public override void Dispose()
        {
            DBManager.Dispose();
        }

        public override void Begin()
        {
            DBManager.Begin();
        }

        public override void End()
        {
            DBManager.End();
        }

        public override IAdministrativoDAO AdministrativoPersistenceManager
        {
            get { return new AdministrativoBDDaoImpl(this); }
        }

        public override IOperarioDAO OperarioPersistenceManager
        {
            get { return new OperarioBDDaoImpl(this); }
        }

        public override IVendedorDAO VendedorPersistenceManager
        {
            get { return new VendedorBDDaoImpl(this); }
        }

        public override IHorarioDAO HorarioPersistenceManager
        {
            get { return new HorarioBDDaoImpl(this); }
        }

        public override IAusenciaDAO AusenciaPersistenceManager
        {
            get { return new AusenciaBDDaoImpl(this); }
        }

        public override IAsistenciaDAO AsistenciaPersistenceManager
        {
            get { return new AsistenciaBDDaoImpl(this); }
        }

        public override ICargaHorariaDAO CargaHorariaPersistenceManager
        {
            get { return new CargaHorariaBDDaoImpl(this); }
        }
    }
}
