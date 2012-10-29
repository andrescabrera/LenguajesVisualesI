using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ControlAsistencia.Clases;
using ControlAsistencia.Data;

namespace ControlAsistencia.Daos
{
    public class PersistenceManager : IDisposable
    {
        public EstrategiaPersistenceManager Estrategia { get; set; }

        public PersistenceManager(EstrategiaPersistenceManager estrategia)
        {
            Estrategia = estrategia;
        }

        public PersistenceManager()
        {
            // TODO: Complete member initialization
        }

        public IAdministrativoDAO AdministrativoPersistenceManager
        {
            get { return Estrategia.AdministrativoPersistenceManager; }
        }

        public IOperarioDAO OperarioPersistenceManager
        {
            get { return Estrategia.OperarioPersistenceManager; }
        }

        public IVendedorDAO VendedorPersistenceManager
        {
            get { return Estrategia.VendedorPersistenceManager; }
        }

        public IAsistenciaDAO AsistenciaPersistenceManager
        {
            get { return Estrategia.AsistenciaPersistenceManager; }
        }

        public IAusenciaDAO AusenciaPersistenceManager
        {
            get { return Estrategia.AusenciaPersistenceManager; }
        }

        public ICargaHorariaDAO CargaHorariaPersistenceManager
        {
            get { return Estrategia.CargaHorariaPersistenceManager; }
        }

        public IHorarioDAO HorarioPersistenceManager
        {
            get { return Estrategia.HorarioPersistenceManager; }
        }

        public void Dispose()
        {
            Estrategia.Dispose();
        }

        public void Begin()
        {
            Estrategia.Begin();
        }

        public void End()
        {
            Estrategia.End();
        }

    }
}
