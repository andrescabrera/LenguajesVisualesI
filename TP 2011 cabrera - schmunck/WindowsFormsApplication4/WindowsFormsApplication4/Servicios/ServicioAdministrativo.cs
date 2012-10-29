using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ControlAsistencia.Clases;
using ControlAsistencia.Daos;

namespace ControlAsistencia.Servicios
{
    public class ServicioAdministrativo : Servicio<Administrativo>
    {
        private static ServicioAdministrativo instancia;

        private ServicioAdministrativo()
        { }

        public static ServicioAdministrativo GetInstancia()
        {
            if (instancia == null)
                instancia = new ServicioAdministrativo();

            return instancia;
        }

        public override void Crear(Administrativo administrativo)
        {
            using (PersistenceManager pm = GetPersistenceManager())
            {
                pm.Begin();

                pm.AdministrativoPersistenceManager.Alta(administrativo);

                pm.End();
            }
        }

        public override void Modificar(Administrativo administrativo)
        {
            using (PersistenceManager pm = GetPersistenceManager())
            {
                pm.Begin();

                pm.AdministrativoPersistenceManager.Modificar(administrativo);

                pm.End();
            }
        }

        public override void Eliminar(Administrativo administrativo)
        {
            using (PersistenceManager pm = GetPersistenceManager())
            {
                pm.Begin();

                pm.AdministrativoPersistenceManager.Eliminar(administrativo);

                pm.End();
            }
        }


        public override List<Administrativo> BuscarTodos()
        {
            using (PersistenceManager pm = GetPersistenceManager())
            {
                pm.Begin();

                List<Administrativo> administrativos = pm.AdministrativoPersistenceManager.ListarTodos();
                
                pm.End();

                return administrativos;
            }
        }
    }
}
