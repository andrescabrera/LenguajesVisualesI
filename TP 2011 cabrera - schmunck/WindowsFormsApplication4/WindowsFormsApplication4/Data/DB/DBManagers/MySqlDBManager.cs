using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ControlAsistencia.Daos;
using MySql.Data.MySqlClient;
using System.Data;

namespace ControlAsistencia.Data.DB.DBManagers
{
    public class MySqlDBManager : IDBManager
    {
        private const string connectionString = "server=127.0.0.1;uid=root;pwd=terabyte;database=tplenguajesvisuales1;";
        private const string identitySql = "SELECT @@IDENTITY";
        private MySql.Data.MySqlClient.MySqlConnection connection;
        private MySql.Data.MySqlClient.MySqlTransaction transaction;

        public void ExecuteNonQuery(System.Data.CommandType commandType, string cmdText, List<System.Data.IDbDataParameter> pars)
        {
            try
            {
                MySqlCommand command = new MySqlCommand(cmdText, connection, transaction);
                foreach (IDbDataParameter par in pars)
                {
                    command.Parameters.Add(par);
                }
                command.ExecuteNonQuery();
            } catch (MySqlException) {
                MySqlConnection connection2 = new MySqlConnection(connectionString);
                connection2.Open();
                MySqlCommand command2 = new MySqlCommand(cmdText, connection2, transaction);
                foreach (IDbDataParameter par in pars)
                {
                    command2.Parameters.Add(par);
                }

                command2.ExecuteNonQuery();
            }
        }

        public System.Data.IDataReader ExecuteReader(System.Data.CommandType commandType, string cmdText)
        {
            return ExecuteReader(commandType, cmdText, new List<IDbDataParameter>());
        }

        public System.Data.IDbDataParameter CrearParametro(string nombre, string valor)
        {
            MySqlParameter par = new MySqlParameter(nombre, valor);

            return par;
        }

        public System.Data.IDbDataParameter CrearParametro(string nombre, decimal valor)
        {
            MySqlParameter par = new MySqlParameter(nombre, valor);

            return par;
        }

        public System.Data.IDbDataParameter CrearParametro(string nombre, DateTime valor)
        {
            //TODO ojo con esto
            MySqlParameter par = new MySqlParameter(nombre, valor);

            return par;
        }

        public System.Data.IDbDataParameter CrearParametro(string nombre, int valor)
        {
            MySqlParameter par = new MySqlParameter(nombre, valor);

            return par;
        }

        public System.Data.IDbDataParameter CrearParametro(string nombre, bool valor)
        {
            MySqlParameter par = new MySqlParameter(nombre, valor ? 1 : 0);

            return par;
        }

        public System.Data.IDbDataParameter CrearParametro(string nombre, long valor)
        {
            MySqlParameter par = new MySqlParameter(nombre, valor);

            return par;
        }

        public int GetIdentity()
        {
            MySqlCommand command = new MySqlCommand("SELECT LAST_INSERT_ID();", connection, transaction);

            IDataReader mDataReader = command.ExecuteReader();
            mDataReader.Read();
            int identity = mDataReader.GetInt32(0);
            mDataReader.Close();
            return identity;
        }

        public void Begin()
        {
            this.connection = new MySqlConnection(connectionString);
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

        public System.Data.IDataReader ExecuteReader(System.Data.CommandType commandType, string cmdText, List<System.Data.IDbDataParameter> pars)
        {
            try
            {
                MySqlCommand command = new MySqlCommand(cmdText, connection, transaction);
                foreach (IDbDataParameter par in pars)
                {
                    command.Parameters.Add(par);
                }
                return command.ExecuteReader();
            } catch (MySqlException) {
                MySqlConnection connection2 = new MySqlConnection(connectionString);
                connection2.Open();       
                MySqlCommand command2 = new MySqlCommand(cmdText, connection2, transaction);
                foreach (IDbDataParameter par in pars)
                {
                    command2.Parameters.Add(par);
                }
                
                return command2.ExecuteReader();
            }
        }


        public void ExecuteNonQuery(CommandType commandType, string cmdText)
        {
            MySqlCommand command = new MySqlCommand(cmdText, connection, transaction);
            
            command.ExecuteNonQuery();
        }
    }
}
