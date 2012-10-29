using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using ControlAsistencia.Daos;

namespace ControlAsistencia.Data.DB.DBManagers
{
    public class OleDBManager : IDBManager
    {
        private const string connectionString = "Provider=MySQL;Data Source=tplenguajesvisuales1;Persist Security Info=True;User ID=root;Password=buscandosalidas3;Location=localhost";
        private const string identitySql = "SELECT @@IDENTITY";
        private OleDbConnection connection;
        private OleDbTransaction transaction;

        public OleDBManager()
        {
        }

        public void ExecuteNonQuery(CommandType commandType, string cmdText, List<IDbDataParameter> pars)
        {
            OleDbCommand command = new OleDbCommand(cmdText, connection, transaction);
            foreach (IDbDataParameter par in pars)
            {
                command.Parameters.Add(par);
            }
            command.ExecuteNonQuery();
        }

        public IDbDataParameter CrearParametro(string nombre, string valor)
        {
            OleDbParameter par = new OleDbParameter(nombre, valor);

            return par;
        }

        public IDbDataParameter CrearParametro(string nombre, long valor)
        {
            OleDbParameter par = new OleDbParameter(nombre, valor);

            return par;
        }

        public IDbDataParameter CrearParametro(string nombre, decimal valor)
        {
            OleDbParameter par = new OleDbParameter(nombre, valor);

            return par;
        }

        public IDbDataParameter CrearParametro(string nombre, DateTime valor)
        {
            OleDbParameter par = new OleDbParameter(nombre, valor);

            return par;
        }

        public IDbDataParameter CrearParametro(string nombre, int valor)
        {
            OleDbParameter par = new OleDbParameter(nombre, valor);

            return par;
        }

        public IDbDataParameter CrearParametro(string nombre, bool valor)
        {
            OleDbParameter par = new OleDbParameter(nombre, valor ? 1 : 0);

            return par;
        }

        public int GetIdentity()
        {
            OleDbCommand command = new OleDbCommand(identitySql, connection, transaction);
            int identity = (int)command.ExecuteScalar();

            return identity;
        }




        public void Begin()
        {
            this.connection = new OleDbConnection(connectionString);
            this.connection.Open();
            this.transaction = this.connection.BeginTransaction();
        }

        public void End()
        {
            transaction.Commit();
            this.connection.Close();
        }

        public void Dispose()
        {
            if (connection != null)
            {
                connection.Close();
            }
        }

        public IDataReader ExecuteReader(CommandType commandType, string cmdText, List<IDbDataParameter> pars)
        {
            OleDbCommand command = new OleDbCommand(cmdText, connection, transaction);
            foreach (IDbDataParameter par in pars)
            {
                command.Parameters.Add(par);
            }
            return command.ExecuteReader();
        }

        public IDataReader ExecuteReader(CommandType commandType, string cmdText)
        {
            return ExecuteReader(commandType, cmdText, new List<IDbDataParameter>());
        }


        public void ExecuteNonQuery(CommandType commandType, string cmdText)
        {
            throw new NotImplementedException();
        }
    }
}


