using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ControlAsistencia.Clases;
using ControlAsistencia.Daos;

namespace ControlAsistencia.Servicios
{
    public class ServicioAsistencia : Servicio<Asistencia>
    {
        private static ServicioAsistencia instancia;

        private ServicioAsistencia()
        { }

        public static ServicioAsistencia GetInstancia()
        {
            if (instancia == null)
                instancia = new ServicioAsistencia();

            return instancia;
        }

        public override void Crear(Asistencia asistencia)
        {
            using (PersistenceManager pm = GetPersistenceManager())
            {
                pm.Begin();
                
                pm.AsistenciaPersistenceManager.Alta(asistencia);

                pm.End();
            }
        }

        public override void Modificar(Asistencia asistencia)
        {
            using (PersistenceManager pm = GetPersistenceManager())
            {
                pm.Begin();

                pm.AsistenciaPersistenceManager.Modificar(asistencia);

                pm.End();
            }
        }

        public override void Eliminar(Asistencia asistencia)
        {
            using (PersistenceManager pm = GetPersistenceManager())
            {
                pm.Begin();

                pm.AsistenciaPersistenceManager.Eliminar(asistencia);

                pm.End();
            }
        }


        public override List<Asistencia> BuscarTodos()
        {
            using (PersistenceManager pm = GetPersistenceManager())
            {
                pm.Begin();

                List<Asistencia> asistencias = pm.AsistenciaPersistenceManager.ListarTodos();
                
                pm.End();

                return asistencias;
            }
        }

        //Reviso en la lista de asistencias del empleado
        //devuelvo la primera que encuentre que no tenga fecha de salida
        public Asistencia BuscarPrimerAsistenciaSinHoraSalida(Empleado empleado)
        {
            List<Asistencia> asistenciasDelEmpleado = BuscarPorEmpleado(empleado);
            return BuscarAsistenciaActual(asistenciasDelEmpleado);
        }

        public bool ComprobarExistenciaPorDia(Empleado empleado, DateTime fecha)
        {
            List<Asistencia> asistenciasDelEmpleado = BuscarPorEmpleado(empleado);
            List<Asistencia> asistenciasDelDia = BuscarEntradasYSalidasPorFecha(asistenciasDelEmpleado, fecha);
            if (asistenciasDelDia != null)
                return true;
            else
                return false;
        }

        public List<Asistencia> BuscarPorEmpleado(Empleado empleado, DateTime fechaDesde, DateTime fechaHasta)
        {
            List<Asistencia> totalAsistencias = BuscarPorEmpleado(empleado);
            List<Asistencia> totalPorFecha = new List<Asistencia>();
            foreach(Asistencia a in totalAsistencias)
            {
                if (a.FechaIngresoPautado.Date >= fechaDesde.Date && a.FechaIngresoPautado.Date <= fechaHasta.Date)
                {
                    totalPorFecha.Add(a);
                }
            }
            return totalPorFecha;
        }

        public List<Asistencia> BuscarPorEmpleado(Empleado empleado)
        {
            List<Asistencia> asistencias;

            using (PersistenceManager pm = GetPersistenceManager())
            {
                pm.Begin();

                if (empleado is Vendedor)
                {
                    asistencias = pm.AsistenciaPersistenceManager.ListarPorIdVendedor(empleado.Id);
                }
                else if (empleado is Operario)
                {
                    asistencias = pm.AsistenciaPersistenceManager.ListarPorIdOperario(empleado.Id);
                }
                else
                {
                    asistencias = pm.AsistenciaPersistenceManager.ListarPorIdAdministrativo(empleado.Id);
                }

                pm.End();
            }
            return asistencias;
        }
        
        private Asistencia BuscarAsistenciaActual(List<Asistencia> asistencias)
        {
            Asistencia asistencia = null;
            if (asistencias != null && asistencias.Count > 0)
            {
                foreach (Asistencia unaAsistencia in asistencias)
                {
                    if (unaAsistencia.FechaHasta.Date == DateTime.Parse("01/01/0001").Date)
                        return asistencia = unaAsistencia;
                }
            }
            
            return asistencia;
        }

        private List<Asistencia> BuscarEntradasYSalidasPorFecha(List<Asistencia> asistencias, DateTime fecha)
        {
            List<Asistencia> asistenciasDeHoy = null;
            if (asistencias != null && asistencias.Count > 0)
            {
                foreach (Asistencia unaAsistencia in asistencias)
                {
                    if (unaAsistencia.FechaDesde.Date == fecha.Date)
                    {
                        if (asistenciasDeHoy == null)
                        {
                            asistenciasDeHoy = new List<Asistencia>();
                        }
                        asistenciasDeHoy.Add(unaAsistencia);
                    }
                }
            }
            return asistenciasDeHoy;
        }
    }
}
