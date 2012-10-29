using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ControlAsistencia.Daos;
using ControlAsistencia.Clases;
using System.Data;

namespace ControlAsistencia.Data.DB.DaosImpl
{
    public class ControlLaboralBDDaoImpl : DBDao, IControlLaboralDAO 
    {
        public ControlLaboralBDDaoImpl(DBEstrategiaPersistenceManager estrategia) : base(estrategia)
        { }

        public long Alta(ControlLaboral controlLaboral)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO ControlLaboral (fecha) VALUES (@fecha)");
            
            //LOOPEAR EN TODOS LAS ASISTENCIAS DEL CONTROL LABORAL
                //UPDATE Asistencia SET id_ControlLaboral = @id_ControlLaboral WHERE id = @idControlLaboral
            //LOOPEAR EN TODOS LAS AUSENCIAS DEL CONTROL LABORAL
                //UPDATE Ausencia SET id_ControlLaboral = @id_ControlLaboral WHERE id = @idControlLaboral
            
            string cmdText = sb.ToString(); //TODO

            List<IDbDataParameter> pars = new List<IDbDataParameter>();
            pars.Add(dbManager.CrearParametro("@fecha", controlLaboral.Fecha)); 

            dbManager.ExecuteNonQuery(CommandType.Text, cmdText, pars);

            controlLaboral.Id = dbManager.GetIdentity();
            return controlLaboral.Id;
        }

        public void Eliminar(ControlLaboral controlLaboral)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE ControlLaboral SET inactivo=1 ");
            sb.Append("WHERE id = @id");
            string cmdText = sb.ToString();

            List<IDbDataParameter> pars = new List<IDbDataParameter>();
            pars.Add(dbManager.CrearParametro("@id", controlLaboral.Id));

            dbManager.ExecuteNonQuery(CommandType.Text, cmdText, pars);
        }

        public void Modificar(ControlLaboral controlLaboral)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE ControlLaboral SET fecha = @fecha");
            sb.Append("WHERE id = @id");
            string cmdText = sb.ToString();

            List<IDbDataParameter> pars = new List<IDbDataParameter>();
            pars.Add(dbManager.CrearParametro("@fecha", controlLaboral.Fecha)); //TODO aca tengo dudas. andres.

            dbManager.ExecuteNonQuery(CommandType.Text, cmdText, pars);
        }

        public List<ControlLaboral> ListarTodos()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT id, dia, fechaDesde, fechaHasta ");
            sb.Append("FROM ControlLaboral WHERE inactivo = 0");
            string cmdText = sb.ToString();

            List<ControlLaboral> controlLaborals = new List<ControlLaboral>();
            using (IDataReader reader = dbManager.ExecuteReader(CommandType.Text, cmdText))
            {
                while (reader.Read())
                {
                    ControlLaboral controlLaboral = ConstruirControlLaboral(reader);

                    controlLaborals.Add(controlLaboral);
                }
            }
            return controlLaborals;
        }

        //RECORRER TODAS LAS Asistencias y Ausencias
        //de las que tengan id_ControlLaboral en el id de este ControlLaboral, setearselas al objeto
        public List<Asistencia> ListarAsistenciasDelControlLaboral(int idControlLaboral)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * ");
            sb.Append("FROM Asistencia WHERE inactivo = 0 AND id_ControlLaboral = @id_ControlLaboral");
            string cmdText = sb.ToString();

            List<IDbDataParameter> pars = new List<IDbDataParameter>();
            pars.Add(dbManager.CrearParametro("@id_ControlLaboral", idControlLaboral));

            dbManager.ExecuteNonQuery(CommandType.Text, cmdText, pars);


            List<Asistencia> asistenciasDelControlLaboral = new List<Asistencia>();
            using (IDataReader reader = dbManager.ExecuteReader(CommandType.Text, cmdText))
            {
                while (reader.Read())
                {
                    //TODO ¿Como construir las asistencias?: Pasar este metodo a Asistencia y el control laboral se levanta sin la relacion, después en la capa de servicio nos encargamos de setearle las Asistencias al Control.
                    Asistencia asistencia = null;// ConstruirAsistencia(reader);

                    asistenciasDelControlLaboral.Add(asistencia);
                }
            }
            return asistenciasDelControlLaboral;
        }

        private ControlLaboral ConstruirControlLaboral(IDataReader reader)
        {
            ControlLaboral controlLaboral = new ControlLaboral();
            controlLaboral.Id = reader.GetInt32(0);
            controlLaboral.Fecha = reader.GetDateTime(1);
            
            //TODO Llamar al metodo ListarAsistenciasDelControlLaboral(controlLaboral.Id) y SETEARLE LAS ASISTENCIAS al ControlLaboral
            //Lo mismo con ausencias... PERO LO DEJAMOS PARA LA CAPA DE SERVICIOS O MAS ARRIBA... NO SE LEVANTA EN CASCADA.

            return controlLaboral;
        }
    }
}
