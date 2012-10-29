using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ControlAsistencia.Daos;
using ControlAsistencia.Clases;
using System.Data;

namespace ControlAsistencia.Data.DB.DaosImpl
{
    public class OperarioBDDaoImpl : DBDao, IOperarioDAO  
    {
        
        public OperarioBDDaoImpl(DBEstrategiaPersistenceManager estrategia) : base(estrategia)
        { }

        public long Alta(Operario operario)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO Operario (legajo, nombre, apellido, direccion, telefono, id_CargaHoraria) ");
            sb.Append("VALUES (@legajo, @nombre, @apellido, @direccion, @telefono, @id_CargaHoraria)");
            string cmdText = sb.ToString();
            
            List<IDbDataParameter> pars = new List<IDbDataParameter>();
            pars.Add(dbManager.CrearParametro("@legajo", operario.Legajo));
            pars.Add(dbManager.CrearParametro("@nombre", operario.Nombre));
            pars.Add(dbManager.CrearParametro("@apellido", operario.Apellido));
            pars.Add(dbManager.CrearParametro("@direccion", operario.Direccion));
            pars.Add(dbManager.CrearParametro("@telefono", operario.Telefono));

            if (operario.CargaHoraria != null)
                pars.Add(dbManager.CrearParametro("@id_CargaHoraria", operario.CargaHoraria.Id));
            else
                pars.Add(dbManager.CrearParametro("@id_CargaHoraria", null));

            dbManager.ExecuteNonQuery(CommandType.Text, cmdText, pars);

            operario.Id = dbManager.GetIdentity();
            return operario.Id;
        }

        public void Eliminar(Operario operario)
        {
            if(operario.CargaHoraria != null)
                estrategia.CargaHorariaPersistenceManager.Eliminar(operario.CargaHoraria);

            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE Operario SET inactivo=1 ");
            sb.Append("WHERE id = @id");
            string cmdText = sb.ToString();

            List<IDbDataParameter> pars = new List<IDbDataParameter>();
            pars.Add(dbManager.CrearParametro("@id", operario.Id));

            dbManager.ExecuteNonQuery(CommandType.Text, cmdText, pars);
        }

        public void Modificar(Operario operario)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE Operario SET legajo = @legajo, nombre = @nombre, apellido = @apellido, ");
            sb.Append("direccion = @direccion, telefono = @telefono, id_CargaHoraria = @id_CargaHoraria ");
            sb.Append("WHERE id = @id");
            string cmdText = sb.ToString();
            
            List<IDbDataParameter> pars = new List<IDbDataParameter>();
            pars.Add(dbManager.CrearParametro("@id", operario.Id));
            pars.Add(dbManager.CrearParametro("@legajo", operario.Legajo));
            pars.Add(dbManager.CrearParametro("@nombre", operario.Nombre));
            pars.Add(dbManager.CrearParametro("@apellido", operario.Apellido));
            pars.Add(dbManager.CrearParametro("@direccion", operario.Direccion));
            pars.Add(dbManager.CrearParametro("@telefono", operario.Telefono));
            if (operario.CargaHoraria != null)
                pars.Add(dbManager.CrearParametro("@id_CargaHoraria", operario.CargaHoraria.Id));
            else
                pars.Add(dbManager.CrearParametro("@id_CargaHoraria", null));

            dbManager.ExecuteNonQuery(CommandType.Text, cmdText, pars);
        }

        public List<Operario> ListarTodos()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT id, legajo, nombre, apellido, telefono, direccion, id_CargaHoraria");
            sb.Append(" FROM Operario WHERE inactivo = 0");
            string cmdText = sb.ToString();

            List<Operario> operarios = new List<Operario>();
            using (IDataReader reader = dbManager.ExecuteReader(CommandType.Text, cmdText))
            {
                while (reader.Read())
                {
                    Operario operario = ConstruirOperario(reader);

                    operarios.Add(operario);
                }
            }
            return operarios;
        }

        private Operario ConstruirOperario(IDataReader reader) 
        {
            Operario operario = new Operario();
            operario.Id = reader.GetInt32(reader.GetOrdinal("id"));
            operario.Legajo = reader.GetInt32(reader.GetOrdinal("legajo"));
            operario.Nombre = reader.GetString(reader.GetOrdinal("nombre"));
            operario.Apellido = reader.GetString(reader.GetOrdinal("apellido"));
            operario.Telefono = reader.GetString(reader.GetOrdinal("telefono"));
            operario.Direccion = reader.GetString(reader.GetOrdinal("direccion"));

            if (!reader.IsDBNull(reader.GetOrdinal("id_CargaHoraria")))
                operario.CargaHoraria = estrategia.CargaHorariaPersistenceManager.ObtenerPorId(reader.GetInt32(reader.GetOrdinal("id_CargaHoraria")));

            return operario;
        }

        public Operario ObtenerPorId(long id)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT id, legajo, nombre, apellido, telefono, direccion, id_CargaHoraria");
            sb.Append(" FROM Operario WHERE id=@id");
            string cmdText = sb.ToString();

            List<IDbDataParameter> pars = new List<IDbDataParameter>();
            pars.Add(dbManager.CrearParametro("@id", id));

            Operario operario = null;

            using (IDataReader reader = dbManager.ExecuteReader(CommandType.Text, cmdText, pars))
            {
                if (reader.Read())
                {
                    operario = ConstruirOperario(reader);
                }
            }

            return operario;
        }
    }
}
