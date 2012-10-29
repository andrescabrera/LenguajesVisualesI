using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ControlAsistencia.Clases;
using ControlAsistencia.Daos;
using ControlAsistencia.Data.DB.DaosImpl;
using ControlAsistencia.Data;

namespace Controlausencia.Data.DB.DaosImpl
{
    public class AusenciaBDDaoImpl : DBDao, IAusenciaDAO   
    {
        public AusenciaBDDaoImpl(DBEstrategiaPersistenceManager estrategia) : base(estrategia)
        { }

        public long Alta(Ausencia ausencia)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("INSERT INTO Ausencia (motivo, fechaIngresoPautado, fechaEgresoPautado, ");
            sb.Append("id_");
            sb.Append(ausencia.Empleado.GetType().Name);
            sb.Append(") VALUES (@motivo, @fechaIngresoPautado, @fechaEgresoPautado, @idEmpleado)");

            string cmdText = sb.ToString();

            List<IDbDataParameter> pars = new List<IDbDataParameter>();
            pars.Add(dbManager.CrearParametro("@motivo", ausencia.Motivo));
            pars.Add(dbManager.CrearParametro("@fechaIngresoPautado", ausencia.FechaIngresoPautado));
            pars.Add(dbManager.CrearParametro("@fechaEgresoPautado", ausencia.FechaEgresoPautado));
            pars.Add(dbManager.CrearParametro("@idEmpleado", ausencia.Empleado.Id));

            dbManager.ExecuteNonQuery(CommandType.Text, cmdText, pars);

            ausencia.Id = dbManager.GetIdentity();
            return ausencia.Id;
        }

        public void Eliminar(Ausencia ausencia)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE Ausencia SET inactivo=1 ");
            sb.Append("WHERE id = @id");
            string cmdText = sb.ToString();

            List<IDbDataParameter> pars = new List<IDbDataParameter>();
            pars.Add(dbManager.CrearParametro("@id", ausencia.Id));

            dbManager.ExecuteNonQuery(CommandType.Text, cmdText, pars);
        }

        public void Modificar(Ausencia ausencia)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE Ausencia SET motivo = @motivo, fechaIngresoPautado = @fechaIngresoPautado, fechaEgresoPautado = @fechaEgresoPautado ");
            sb.Append("WHERE id = @id");
            string cmdText = sb.ToString();

            List<IDbDataParameter> pars = new List<IDbDataParameter>();
            pars.Add(dbManager.CrearParametro("@id", ausencia.Id));
            pars.Add(dbManager.CrearParametro("@motivo", ausencia.Motivo));
            pars.Add(dbManager.CrearParametro("@fechaIngresoPautado", ausencia.FechaIngresoPautado));
            pars.Add(dbManager.CrearParametro("@fechaEgresoPautado", ausencia.FechaEgresoPautado));

            dbManager.ExecuteNonQuery(CommandType.Text, cmdText, pars);
        }

        public List<Ausencia> ListarTodos()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT id, motivo, fechaIngresoPautado, fechaEgresoPautado ");
            sb.Append("FROM Ausencia WHERE inactivo = 0");
            string cmdText = sb.ToString();

            List<Ausencia> ausencias = new List<Ausencia>();
            using (IDataReader reader = dbManager.ExecuteReader(CommandType.Text, cmdText))
            {
                while (reader.Read())
                {
                    Ausencia ausencia = ConstruirAusencia(reader);

                    ausencias.Add(ausencia);
                }
            }
            return ausencias;
        }

        private Ausencia ConstruirAusencia(IDataReader reader)
        {
            Ausencia ausencia = new Ausencia();
            ausencia.Id = reader.GetInt32(reader.GetOrdinal("id"));
            ausencia.Motivo = reader.GetString(reader.GetOrdinal("motivo"));
            ausencia.FechaIngresoPautado = reader.GetDateTime(reader.GetOrdinal("fechaIngresoPautado"));
            ausencia.FechaEgresoPautado = reader.GetDateTime(reader.GetOrdinal("fechaEgresoPautado"));

            //Carga en la ausencia el empleado indicado por el id
            long idEmpleado;
            if(!reader.IsDBNull(reader.GetOrdinal("id_Operario")))
            {
                idEmpleado = reader.GetInt32(reader.GetOrdinal("id_Operario"));
                ausencia.Empleado = estrategia.OperarioPersistenceManager.ObtenerPorId(idEmpleado);
            }
            else if (!reader.IsDBNull(reader.GetOrdinal("id_Vendedor"))) 
            {
                idEmpleado = reader.GetInt32(reader.GetOrdinal("id_Vendedor"));
                ausencia.Empleado = estrategia.VendedorPersistenceManager.ObtenerPorId(idEmpleado);
            }
            else
            {
                idEmpleado = reader.GetInt32(reader.GetOrdinal("id_Administrativo"));
                ausencia.Empleado = estrategia.AdministrativoPersistenceManager.ObtenerPorId(idEmpleado);
            }


            return ausencia;
        }

        public Ausencia ObtenerPorId(long id)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT id, motivo, fechaIngresoPautado, fechaEgresoPautado ");
            sb.Append("FROM Ausencia WHERE id=@id");
            string cmdText = sb.ToString();

            List<IDbDataParameter> pars = new List<IDbDataParameter>();
            pars.Add(dbManager.CrearParametro("@id", id));

            Ausencia ausencia = null;

            using (IDataReader reader = dbManager.ExecuteReader(CommandType.Text, cmdText, pars))
            {
                if (reader.Read())
                {
                    ausencia = ConstruirAusencia(reader);
                }
            }
            return ausencia;
        }


        public List<Ausencia> ListarPorIdVendedor(long p)
        {
            return ListarPorIdDeEmpleado(p, typeof(Vendedor).Name);
        }

        public List<Ausencia> ListarPorIdOperario(long p)
        {
            return ListarPorIdDeEmpleado(p, typeof(Operario).Name);
        }

        public List<Ausencia> ListarPorIdAdministrativo(long p)
        {
            return ListarPorIdDeEmpleado(p, typeof(Administrativo).Name);
        }

        public List<Ausencia> ListarPorIdDeEmpleado(long idEmpleado, string tipoEmpleado)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT id, id_Operario, id_Vendedor, id_Administrativo, motivo, fechaIngresoPautado, fechaEgresoPautado ");
            sb.Append("FROM Ausencia WHERE inactivo = 0 AND ");
            sb.Append("id_");
            sb.Append(tipoEmpleado);
            sb.Append(" = @idEmpleado");
            string cmdText = sb.ToString();
            List<IDbDataParameter> pars = new List<IDbDataParameter>();
            pars.Add(dbManager.CrearParametro("@idEmpleado", idEmpleado));
            List<Ausencia> ausencias = new List<Ausencia>();
            using (IDataReader reader = dbManager.ExecuteReader(CommandType.Text, cmdText, pars))
            {
                while (reader.Read())
                {
                    Ausencia ausencia = ConstruirAusencia(reader);

                    ausencias.Add(ausencia);
                }
            }
            return ausencias;
        }
    }
}
