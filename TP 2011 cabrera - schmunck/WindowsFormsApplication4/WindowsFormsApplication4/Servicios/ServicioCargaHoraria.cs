using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ControlAsistencia.Clases;
using ControlAsistencia.Daos;

namespace ControlAsistencia.Servicios
{
    public class ServicioCargaHoraria : Servicio<CargaHoraria>
    {
        private static ServicioCargaHoraria instancia;
        
        private ServicioCargaHoraria () 
        { }

        public static ServicioCargaHoraria GetInstancia ()
        {
            if(instancia == null)
                instancia = new ServicioCargaHoraria();

            return instancia;
        }

        public override void Crear(CargaHoraria cargaHoraria)
        {
            using (PersistenceManager pm = GetPersistenceManager())
            {
                pm.Begin();

                pm.CargaHorariaPersistenceManager.Alta(cargaHoraria);

                pm.End();
            }    
        }

        public override void Modificar(CargaHoraria cargaHoraria)
        {
            using (PersistenceManager pm = GetPersistenceManager())
            {
                pm.Begin();

                pm.CargaHorariaPersistenceManager.Modificar(cargaHoraria);

                pm.End();
            }
        }

        public override void Eliminar(CargaHoraria cargaHoraria)
        {
            using (PersistenceManager pm = GetPersistenceManager())
            {
                pm.Begin();

                pm.CargaHorariaPersistenceManager.Eliminar(cargaHoraria);

                pm.End();
            }
        }

        public override List<CargaHoraria> BuscarTodos()
        {
            List<CargaHoraria> cargasHorarias;
            using (PersistenceManager pm = GetPersistenceManager())
            {
                pm.Begin();

                cargasHorarias = pm.CargaHorariaPersistenceManager.ListarTodos();

                pm.End();
            }

            return cargasHorarias;
        }

        public CargaHoraria ObtenerPorId(long id)
        {
            CargaHoraria carga;
            using (PersistenceManager pm = GetPersistenceManager())
            {
                pm.Begin();
                
                carga = pm.CargaHorariaPersistenceManager.ObtenerPorId(id);

                pm.End();
            }
            
            return carga;
        }
    }
}
