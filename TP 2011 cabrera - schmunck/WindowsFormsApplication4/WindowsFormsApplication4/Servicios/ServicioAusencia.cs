using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ControlAsistencia.Clases;
using ControlAsistencia.Daos;

namespace ControlAsistencia.Servicios
{
    public class ServicioAusencia : Servicio<Ausencia>
    {
        private static ServicioAusencia instancia;

        private ServicioAusencia()
        { }

        public static ServicioAusencia GetInstancia()
        {
            if (instancia == null)
                instancia = new ServicioAusencia();

            return instancia;
        }

        public override void Crear(Ausencia ausencia)
        {
            using (PersistenceManager pm = GetPersistenceManager())
            {
                pm.Begin();

                pm.AusenciaPersistenceManager.Alta(ausencia);

                pm.End();
            }
        }

        public override void Modificar(Ausencia ausencia)
        {
            using (PersistenceManager pm = GetPersistenceManager())
            {
                pm.Begin();

                pm.AusenciaPersistenceManager.Modificar(ausencia);

                pm.End();
            }
        }

        public override void Eliminar(Ausencia ausencia)
        {
            using (PersistenceManager pm = GetPersistenceManager())
            {
                pm.Begin();

                pm.AusenciaPersistenceManager.Eliminar(ausencia);

                pm.End();
            }
        }


        public override List<Ausencia> BuscarTodos()
        {
            using (PersistenceManager pm = GetPersistenceManager())
            {
                pm.Begin();

                List<Ausencia> ausencias = pm.AusenciaPersistenceManager.ListarTodos();

                pm.End();

                return ausencias;
            }
        }

        public List<Ausencia> BuscarPorEmpleado(Empleado empleado, DateTime fechaDesde, DateTime fechaHasta)
        {
            List<Ausencia> totalAusencias = BuscarPorEmpleado(empleado);
            List<Ausencia> totalPorFecha = new List<Ausencia>();
            foreach (Ausencia a in totalAusencias)
            {
                if (a.FechaIngresoPautado.Date >= fechaDesde.Date && a.FechaIngresoPautado.Date <= fechaHasta.Date)
                {
                    totalPorFecha.Add(a);
                }
            }

            return totalPorFecha;
        }


        public List<Ausencia> BuscarPorEmpleado(Empleado empleado)
        {
            List<Ausencia> ausencias;
            using (PersistenceManager pm = GetPersistenceManager())
            {
                pm.Begin();

                if (empleado is Vendedor)
                {
                    ausencias = pm.AusenciaPersistenceManager.ListarPorIdVendedor(empleado.Id);
                }
                else if (empleado is Operario)
                {
                    ausencias = pm.AusenciaPersistenceManager.ListarPorIdOperario(empleado.Id);
                }
                else
                {
                    ausencias = pm.AusenciaPersistenceManager.ListarPorIdAdministrativo(empleado.Id);
                }

                pm.End();

                return ausencias;
            }
        }
    }
}