using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ControlAsistencia.Clases;
using ControlAsistencia.Daos;

namespace ControlAsistencia.Servicios
{
    public class ServicioHorario : Servicio<Horario>
    {
        private static ServicioHorario instancia;
        
        private ServicioHorario () 
        { }

        public static ServicioHorario GetInstancia ()
        {
            if(instancia == null)
                instancia = new ServicioHorario();

            return instancia;
        }

        public override void Crear(Horario horario)
        {
            using (PersistenceManager pm = GetPersistenceManager())
            {
                pm.Begin();

                pm.HorarioPersistenceManager.Alta(horario);

                pm.End();
            }    
        }

        public override void Modificar(Horario horario)
        {
            using (PersistenceManager pm = GetPersistenceManager())
            {
                pm.Begin();

                pm.HorarioPersistenceManager.Modificar(horario);

                pm.End();
            }
        }

        public override void Eliminar(Horario horario)
        {
            using (PersistenceManager pm = GetPersistenceManager())
            {
                pm.Begin();

                pm.HorarioPersistenceManager.Eliminar(horario);

                pm.End();
            }
        }

        public override List<Horario> BuscarTodos()
        {
            List<Horario> horarios;
            using (PersistenceManager pm = GetPersistenceManager())
            {
                pm.Begin();
                
                horarios = pm.HorarioPersistenceManager.ListarTodos();

                pm.End();
            }
            
            return horarios;
        }

        public Horario ObtenerPorId(long id)
        {
            Horario carga;
            using (PersistenceManager pm = GetPersistenceManager())
            {
                pm.Begin();
                
                carga = pm.HorarioPersistenceManager.ObtenerPorId(id);

                pm.End();
            }
            
            return carga;
        }

        public Horario BuscarHorarioPorEmpleadoYFecha(Empleado empleado, DateTime fecha) 
        {
            Horario horario = null;
            if (empleado.CargaHoraria != null)
            {
                CargaHoraria carga = empleado.CargaHoraria;

                DayOfWeek diaSeleccionado = fecha.DayOfWeek;

                foreach (Horario h in carga.Horarios)
                {
                    if (h.Dia == diaSeleccionado)
                    {
                        horario = h;
                    }
                }
            }
            return horario;
        }
    }
}
