using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ControlAsistencia.Clases;
using ControlAsistencia.Data;

namespace ControlAsistencia.Daos
{
    public abstract class EstrategiaPersistenceManager
    {

        public abstract void Dispose();

        public abstract void Begin();

        public abstract void End();

        public abstract IAdministrativoDAO AdministrativoPersistenceManager { get; }
        public abstract IOperarioDAO OperarioPersistenceManager { get; }
        public abstract IVendedorDAO VendedorPersistenceManager { get; }
        public abstract ICargaHorariaDAO CargaHorariaPersistenceManager { get; }
        public abstract IAusenciaDAO AusenciaPersistenceManager { get; }
        public abstract IHorarioDAO HorarioPersistenceManager { get; }
        public abstract IAsistenciaDAO AsistenciaPersistenceManager { get; } 
    }
}
