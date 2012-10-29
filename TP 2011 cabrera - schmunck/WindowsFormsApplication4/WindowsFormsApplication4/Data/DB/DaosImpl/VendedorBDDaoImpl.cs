using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ControlAsistencia.Data.DB;
using ControlAsistencia.Daos;
using ControlAsistencia.Clases;
using System.Data;
using ControlAsistencia.Data;
using ControlAsistencia.Data.DB.DaosImpl;

namespace ControlAsistencia.Data.DB.DaosImpl
{
    public class VendedorBDDaoImpl : DBDao, IVendedorDAO 
    { 

        public VendedorBDDaoImpl(DBEstrategiaPersistenceManager estrategia) : base(estrategia)
        { }


        public long Alta(Vendedor vendedor)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO Vendedor (legajo, nombre, apellido, direccion, telefono, comision, id_CargaHoraria) ");
            sb.Append("VALUES (@legajo, @nombre, @apellido, @direccion, @telefono, @comision, @id_CargaHoraria)");
            string cmdText = sb.ToString();
            
            List<IDbDataParameter> pars = new List<IDbDataParameter>();
            pars.Add(dbManager.CrearParametro("@legajo", vendedor.Legajo));
            pars.Add(dbManager.CrearParametro("@nombre", vendedor.Nombre));
            pars.Add(dbManager.CrearParametro("@apellido", vendedor.Apellido));
            pars.Add(dbManager.CrearParametro("@direccion", vendedor.Direccion));
            pars.Add(dbManager.CrearParametro("@telefono", vendedor.Telefono));
            pars.Add(dbManager.CrearParametro("@comision", vendedor.Comision));
            if(vendedor.CargaHoraria != null)
                pars.Add(dbManager.CrearParametro("@id_CargaHoraria", vendedor.CargaHoraria.Id));
            else
                pars.Add(dbManager.CrearParametro("@id_CargaHoraria", null));
            dbManager.ExecuteNonQuery(CommandType.Text, cmdText, pars);

            vendedor.Id = dbManager.GetIdentity();
            return vendedor.Id;
        }

        public void Eliminar(Vendedor vendedor)
        {
            if(vendedor.CargaHoraria != null)
                estrategia.CargaHorariaPersistenceManager.Eliminar(vendedor.CargaHoraria);
            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE Vendedor SET inactivo=1 ");
            sb.Append("WHERE id = @id");
            string cmdText = sb.ToString();

            List<IDbDataParameter> pars = new List<IDbDataParameter>();
            pars.Add(dbManager.CrearParametro("@id", vendedor.Id));

            dbManager.ExecuteNonQuery(CommandType.Text, cmdText, pars);
        }

        public void Modificar(Vendedor vendedor)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE Vendedor SET legajo = @legajo, nombre = @nombre, apellido = @apellido, ");
            sb.Append("direccion = @direccion, telefono = @telefono, comision = @comision, id_CargaHoraria = @id_CargaHoraria ");
            sb.Append("WHERE id = @id");
            string cmdText = sb.ToString();
            
            List<IDbDataParameter> pars = new List<IDbDataParameter>();
            pars.Add(dbManager.CrearParametro("@id", vendedor.Id));
            pars.Add(dbManager.CrearParametro("@legajo", vendedor.Legajo));
            pars.Add(dbManager.CrearParametro("@nombre", vendedor.Nombre));
            pars.Add(dbManager.CrearParametro("@apellido", vendedor.Apellido));
            pars.Add(dbManager.CrearParametro("@direccion", vendedor.Direccion));
            pars.Add(dbManager.CrearParametro("@telefono", vendedor.Telefono));
            pars.Add(dbManager.CrearParametro("@comision", vendedor.Comision));
            if (vendedor.CargaHoraria != null)
                pars.Add(dbManager.CrearParametro("@id_CargaHoraria", vendedor.CargaHoraria.Id));
            else
                pars.Add(dbManager.CrearParametro("@id_CargaHoraria", null));

            dbManager.ExecuteNonQuery(CommandType.Text, cmdText, pars);
        }

        public List<Vendedor> ListarTodos()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT id, legajo, nombre, apellido, telefono, direccion, id_CargaHoraria, comision ");
            sb.Append("FROM Vendedor WHERE inactivo = 0");
            string cmdText = sb.ToString();

            List<Vendedor> vendedores = new List<Vendedor>();
            using (IDataReader reader = dbManager.ExecuteReader(CommandType.Text, cmdText))
            {
                while (reader.Read())
                {
                    Vendedor vendedor = ConstruirVendedor(reader);

                    vendedores.Add(vendedor);
                }
            }
            return vendedores;
        }

        private Vendedor ConstruirVendedor(IDataReader reader) 
        {
            Vendedor vendedor = new Vendedor();
            vendedor.Id = reader.GetInt32(reader.GetOrdinal("id"));
            vendedor.Legajo = reader.GetInt32(reader.GetOrdinal("legajo"));
            vendedor.Nombre = reader.GetString(reader.GetOrdinal("nombre"));
            vendedor.Apellido = reader.GetString(reader.GetOrdinal("apellido"));
            vendedor.Telefono = reader.GetString(reader.GetOrdinal("telefono"));
            vendedor.Direccion = reader.GetString(reader.GetOrdinal("direccion"));
            vendedor.Comision = reader.GetDecimal(reader.GetOrdinal("comision"));

            if (!reader.IsDBNull(reader.GetOrdinal("id_CargaHoraria")))
                vendedor.CargaHoraria = estrategia.CargaHorariaPersistenceManager.ObtenerPorId(reader.GetInt32(reader.GetOrdinal("id_CargaHoraria"))); 

            return vendedor;
        }

        public Vendedor ObtenerPorId(long id)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT id, legajo, nombre, apellido, telefono, direccion, id_CargaHoraria, comision ");
            sb.Append("FROM Vendedor WHERE id=@id");
            string cmdText = sb.ToString();

            List<IDbDataParameter> pars = new List<IDbDataParameter>();
            pars.Add(dbManager.CrearParametro("@id", id));

            Vendedor vendedor = null;

            using (IDataReader reader = dbManager.ExecuteReader(CommandType.Text, cmdText, pars))
            {
                if (reader.Read())
                {
                    vendedor = ConstruirVendedor(reader);
                }
            }

            return vendedor;
        }
    }
}
