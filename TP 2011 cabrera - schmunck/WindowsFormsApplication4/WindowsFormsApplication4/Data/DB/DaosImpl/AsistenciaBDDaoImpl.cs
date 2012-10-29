using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ControlAsistencia.Daos;
using ControlAsistencia.Clases;
using System.Data;

namespace ControlAsistencia.Data.DB.DaosImpl
{
    public class AsistenciaBDDaoImpl : DBDao, IAsistenciaDAO   
    {
        public AsistenciaBDDaoImpl(DBEstrategiaPersistenceManager estrategia)
            : base(estrategia)
        { }

        public long Alta(Asistencia asistencia)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("INSERT INTO Asistencia (fechaDesde, fechaHasta, fechaIngresoPautado, fechaEgresoPautado, ");
            sb.Append("id_" + asistencia.Empleado.GetType().Name);
            sb.Append(") VALUES (?fechaDesde, ?fechaHasta, ?fechaIngresoPautado, ?fechaEgresoPautado, ?idEmpleado)");
                        
            string cmdText = sb.ToString();
            List<IDbDataParameter> pars = new List<IDbDataParameter>();

            pars.Add(dbManager.CrearParametro("?fechaDesde", asistencia.FechaDesde));
            pars.Add(dbManager.CrearParametro("?fechaHasta", asistencia.FechaHasta));
            pars.Add(dbManager.CrearParametro("?fechaIngresoPautado", asistencia.FechaIngresoPautado));
            pars.Add(dbManager.CrearParametro("?fechaEgresoPautado", asistencia.FechaEgresoPautado));
            
            
            pars.Add(dbManager.CrearParametro("?idEmpleado", asistencia.Empleado.Id));
            
            dbManager.ExecuteNonQuery(CommandType.Text, cmdText, pars);

            asistencia.Id = dbManager.GetIdentity();
            return asistencia.Id;
        }

        public void Eliminar(Asistencia asistencia)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE Asistencia SET inactivo=1 ");
            sb.Append("WHERE id = @id");
            string cmdText = sb.ToString();

            List<IDbDataParameter> pars = new List<IDbDataParameter>();
            pars.Add(dbManager.CrearParametro("@id", asistencia.Id));

            dbManager.ExecuteNonQuery(CommandType.Text, cmdText, pars);
        }

        public void Modificar(Asistencia asistencia)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE Asistencia SET fechaDesde = @fechaDesde, fechaHasta = @fechaHasta, fechaIngresoPautado = @fechaIngresoPautado, fechaEgresoPautado = @fechaEgresoPautado ");
            sb.Append("WHERE id = @id");
            string cmdText = sb.ToString();

            List<IDbDataParameter> pars = new List<IDbDataParameter>();
            pars.Add(dbManager.CrearParametro("@id", asistencia.Id));
            pars.Add(dbManager.CrearParametro("@fechaDesde", asistencia.FechaDesde));
            pars.Add(dbManager.CrearParametro("@fechaHasta", asistencia.FechaHasta));
            pars.Add(dbManager.CrearParametro("@fechaIngresoPautado", asistencia.FechaIngresoPautado));
            pars.Add(dbManager.CrearParametro("@fechaEgresoPautado", asistencia.FechaEgresoPautado));

            dbManager.ExecuteNonQuery(CommandType.Text, cmdText, pars);
        }

        public List<Asistencia> ListarTodos()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT id, id_Operario, id_Vendedor, id_Administrativo, fechaDesde, fechaHasta, fechaIngresoPautado, fechaEgresoPautado ");
            sb.Append("FROM Asistencia WHERE inactivo = 0");
            string cmdText = sb.ToString();

            List<Asistencia> asistencias = new List<Asistencia>();
            using (IDataReader reader = dbManager.ExecuteReader(CommandType.Text, cmdText))
            {
                while (reader.Read())
                {
                    Asistencia asistencia = ContruirAsistencias(reader);

                    asistencias.Add(asistencia);
                }
            }
            return asistencias;
        }

        private Asistencia ContruirAsistencias(IDataReader reader)
        {
            Asistencia asistencia = new Asistencia();
            asistencia.Id = reader.GetInt32(reader.GetOrdinal("id"));
            asistencia.FechaDesde = reader.GetDateTime(reader.GetOrdinal("fechaDesde"));
            asistencia.FechaHasta = reader.GetDateTime(reader.GetOrdinal("fechaHasta"));
            asistencia.FechaIngresoPautado = reader.GetDateTime(reader.GetOrdinal("fechaIngresoPautado"));
            asistencia.FechaEgresoPautado = reader.GetDateTime(reader.GetOrdinal("fechaEgresoPautado"));
            
            //Carga en la asistencia el empleado indicado por el id
            long idEmpleado;
            if(!reader.IsDBNull(reader.GetOrdinal("id_Operario")))
            {
                idEmpleado = reader.GetInt32(reader.GetOrdinal("id_Operario"));
                asistencia.Empleado = estrategia.OperarioPersistenceManager.ObtenerPorId(idEmpleado);
            }
            else if (!reader.IsDBNull(reader.GetOrdinal("id_Vendedor"))) 
            {
                idEmpleado = reader.GetInt32(reader.GetOrdinal("id_Vendedor"));
                asistencia.Empleado = estrategia.VendedorPersistenceManager.ObtenerPorId(idEmpleado);
            }
            else if (!reader.IsDBNull(reader.GetOrdinal("id_Administrativo")))
            {
                idEmpleado = reader.GetInt32(reader.GetOrdinal("id_Administrativo"));
                asistencia.Empleado = estrategia.AdministrativoPersistenceManager.ObtenerPorId(idEmpleado);
            }

            return asistencia;
        }

        public Asistencia ObtenerPorId(long id)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT id, id_Operario, id_Vendedor, id_Administrativo, fechaDesde, fechaHasta, fechaIngresoPautado, fechaEgresoPautado ");
            sb.Append("FROM Asistencia WHERE id=@id");
            string cmdText = sb.ToString();

            List<IDbDataParameter> pars = new List<IDbDataParameter>();
            pars.Add(dbManager.CrearParametro("@id", id));

            Asistencia asistencia = null;

            using (IDataReader reader = dbManager.ExecuteReader(CommandType.Text, cmdText, pars))
            {
                if (reader.Read())
                {
                    asistencia = ContruirAsistencias(reader);
                }
            }
            return asistencia;
        }

        public List<Asistencia> ListarPorIdAdministrativo(long idEmpleado)
        {
            return ListarPorIdEmpleado(idEmpleado, "id_Administrativo");
        }

        public List<Asistencia> ListarPorIdOperario(long idEmpleado)
        {
            return ListarPorIdEmpleado(idEmpleado, "id_Operario");
        }

        public List<Asistencia> ListarPorIdVendedor(long idEmpleado)
        {
            return ListarPorIdEmpleado(idEmpleado, "id_Vendedor");
        }

        private List<Asistencia> ListarPorIdEmpleado(long idEmpleado, string tipoEmpleado)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT id, id_Operario, id_Vendedor, id_Administrativo, fechaDesde, fechaHasta, fechaIngresoPautado, fechaEgresoPautado ");
            sb.Append("FROM Asistencia WHERE inactivo = 0 AND ");
            sb.Append(tipoEmpleado);
            sb.Append(" = @idEmpleado");
            string cmdText = sb.ToString();

            List<IDbDataParameter> pars = new List<IDbDataParameter>();
            pars.Add(dbManager.CrearParametro("@idEmpleado", idEmpleado));
            List<Asistencia> asistencias = new List<Asistencia>();
            using (IDataReader reader = dbManager.ExecuteReader(CommandType.Text, cmdText, pars))
            {
                while (reader.Read())
                {
                    Asistencia asistencia = ContruirAsistencias(reader);

                    asistencias.Add(asistencia);
                }
            }
            return asistencias;
        }
    }
}
