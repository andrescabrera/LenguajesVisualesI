using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ControlAsistencia.Daos;
using ControlAsistencia.Clases;
using System.Data;

namespace ControlAsistencia.Data.DB.DaosImpl
{
    public class AdministrativoBDDaoImpl : DBDao, IAdministrativoDAO 
    {
        public AdministrativoBDDaoImpl(DBEstrategiaPersistenceManager estrategia) : base(estrategia)
        { }

        public long Alta(Administrativo administrativo)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO Administrativo (legajo, nombre, apellido, direccion, telefono, id_CargaHoraria) ");
            sb.Append("VALUES (@legajo, @nombre, @apellido, @direccion, @telefono, @id_CargaHoraria)");
            string cmdText = sb.ToString();
            
            List<IDbDataParameter> pars = new List<IDbDataParameter>();
            pars.Add(dbManager.CrearParametro("@legajo", administrativo.Legajo));
            pars.Add(dbManager.CrearParametro("@nombre", administrativo.Nombre));
            pars.Add(dbManager.CrearParametro("@apellido", administrativo.Apellido));
            pars.Add(dbManager.CrearParametro("@direccion", administrativo.Direccion));
            pars.Add(dbManager.CrearParametro("@telefono", administrativo.Telefono));
            if(administrativo.CargaHoraria != null)
                pars.Add(dbManager.CrearParametro("@id_CargaHoraria", administrativo.CargaHoraria.Id));
            else
                pars.Add(dbManager.CrearParametro("@id_CargaHoraria", null));

            dbManager.ExecuteNonQuery(CommandType.Text, cmdText, pars);

            administrativo.Id = dbManager.GetIdentity();
            return administrativo.Id;
        }

        public void Eliminar(Administrativo administrativo)
        {
            if(administrativo.CargaHoraria != null)
                estrategia.CargaHorariaPersistenceManager.Eliminar(administrativo.CargaHoraria);

            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE Administrativo SET inactivo=1 ");
            sb.Append("WHERE id = @id");
            string cmdText = sb.ToString();

            List<IDbDataParameter> pars = new List<IDbDataParameter>();
            pars.Add(dbManager.CrearParametro("@id", administrativo.Id));

            dbManager.ExecuteNonQuery(CommandType.Text, cmdText, pars);
        }

        public void Modificar(Administrativo administrativo)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE Administrativo SET legajo = @legajo, nombre = @nombre, apellido = @apellido, ");
            sb.Append("direccion = @direccion, telefono = @telefono, id_CargaHoraria = @id_CargaHoraria ");
            sb.Append("WHERE id = @id");
            string cmdText = sb.ToString();
            
            List<IDbDataParameter> pars = new List<IDbDataParameter>();
            pars.Add(dbManager.CrearParametro("@id", administrativo.Id));
            pars.Add(dbManager.CrearParametro("@legajo", administrativo.Legajo));
            pars.Add(dbManager.CrearParametro("@nombre", administrativo.Nombre));
            pars.Add(dbManager.CrearParametro("@apellido", administrativo.Apellido));
            pars.Add(dbManager.CrearParametro("@direccion", administrativo.Direccion));
            pars.Add(dbManager.CrearParametro("@telefono", administrativo.Telefono));
            if(administrativo.CargaHoraria != null)
                pars.Add(dbManager.CrearParametro("@id_CargaHoraria", administrativo.CargaHoraria.Id));
            else
                pars.Add(dbManager.CrearParametro("@id_CargaHoraria", null));

            dbManager.ExecuteNonQuery(CommandType.Text, cmdText, pars);
        }

        public List<Administrativo> ListarTodos()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT id, legajo, nombre, apellido, telefono, direccion, id_CargaHoraria ");
            sb.Append("FROM Administrativo WHERE inactivo = 0");
            string cmdText = sb.ToString();

            List<Administrativo> administrativoes = new List<Administrativo>();
            using (IDataReader reader = dbManager.ExecuteReader(CommandType.Text, cmdText))
            {
                while (reader.Read())
                {
                    Administrativo administrativo = ConstruirAdministrativo(reader);

                    administrativoes.Add(administrativo);
                }
            }
            return administrativoes;
        }

        private Administrativo ConstruirAdministrativo(IDataReader reader) 
        {
            Administrativo administrativo = new Administrativo();
            administrativo.Id = reader.GetInt32(reader.GetOrdinal("id"));
            administrativo.Legajo = reader.GetInt32(reader.GetOrdinal("legajo"));
            administrativo.Nombre = reader.GetString(reader.GetOrdinal("nombre"));
            administrativo.Apellido = reader.GetString(reader.GetOrdinal("apellido"));
            administrativo.Telefono = reader.GetString(reader.GetOrdinal("telefono"));
            administrativo.Direccion = reader.GetString(reader.GetOrdinal("direccion"));
            if(!reader.IsDBNull(reader.GetOrdinal("id_CargaHoraria")))
                administrativo.CargaHoraria = estrategia.CargaHorariaPersistenceManager.ObtenerPorId(reader.GetInt32(reader.GetOrdinal("id_CargaHoraria")));
            return administrativo;
        }

        public Administrativo ObtenerPorId(long id)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT id, legajo, nombre, apellido, telefono, direccion, id_CargaHoraria");
            sb.Append(" FROM Administrativo WHERE id=@id");
            string cmdText = sb.ToString();

            List<IDbDataParameter> pars = new List<IDbDataParameter>();
            pars.Add(dbManager.CrearParametro("@id", id));

            Administrativo administrativo = null;

            using (IDataReader reader = dbManager.ExecuteReader(CommandType.Text, cmdText, pars))
            {
                if (reader.Read())
                {
                    administrativo = ConstruirAdministrativo(reader);
                }
            }

            return administrativo;
        }
    }
}
