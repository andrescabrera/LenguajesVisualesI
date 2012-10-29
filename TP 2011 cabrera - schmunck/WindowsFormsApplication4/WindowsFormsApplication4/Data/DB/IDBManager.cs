using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ControlAsistencia.Daos
{
    public interface IDBManager 
    {
        void ExecuteNonQuery(System.Data.CommandType commandType, string cmdText, List<IDbDataParameter> pars);
        void ExecuteNonQuery(System.Data.CommandType commandType, string cmdText);
        //IDataReader ExecuteReader(CommandType commandType, string cmdText, List<IDbDataAdapter> pars);
        
        IDataReader ExecuteReader(CommandType commandType, string cmdText, List<IDbDataParameter> pars);
        IDataReader ExecuteReader(System.Data.CommandType commandType, string cmdText);

        IDbDataParameter CrearParametro(string nombre, string valor);
        IDbDataParameter CrearParametro(string nombre, decimal valor);
        IDbDataParameter CrearParametro(string nombre, DateTime valor);
        IDbDataParameter CrearParametro(string nombre, int valor);
        IDbDataParameter CrearParametro(string nombre, bool valor);
        IDbDataParameter CrearParametro(string nombre, long valor);
        
        int GetIdentity();

        void Begin();

        void End();

        void Dispose();
    }
}
