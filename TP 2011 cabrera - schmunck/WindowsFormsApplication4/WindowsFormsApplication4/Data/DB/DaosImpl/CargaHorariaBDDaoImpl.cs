using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ControlAsistencia.Clases;
using ControlAsistencia.Daos;
using System.Data;

namespace ControlAsistencia.Data.DB.DaosImpl
{
    public class CargaHorariaBDDaoImpl : DBDao, ICargaHorariaDAO
    {

        public CargaHorariaBDDaoImpl(DBEstrategiaPersistenceManager estrategia)
            : base(estrategia)
        { }

        public long Alta(CargaHoraria cargaHoraria)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO CargaHoraria () VALUES ()");

            string cmdText = sb.ToString();
            
            dbManager.ExecuteNonQuery(CommandType.Text, cmdText);

            cargaHoraria.Id = dbManager.GetIdentity();
            return cargaHoraria.Id;
        }

        public void Eliminar(CargaHoraria cargaHoraria)
        {
            foreach (Horario horario in cargaHoraria.Horarios)
            {
                estrategia.HorarioPersistenceManager.Eliminar(horario);
            }
            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE CargaHoraria SET inactivo=1 ");
            sb.Append("WHERE id = @id");
            string cmdText = sb.ToString();

            List<IDbDataParameter> pars = new List<IDbDataParameter>();
            pars.Add(dbManager.CrearParametro("@id", cargaHoraria.Id));

            dbManager.ExecuteNonQuery(CommandType.Text, cmdText, pars);
        }

        public void Modificar(CargaHoraria cargaHoraria)
        {
            /*
            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE CargaHoraria");
            sb.Append("WHERE id = @id");
            string cmdText = sb.ToString();

            dbManager.ExecuteNonQuery(CommandType.Text, cmdText);
             */
        }

        public List<CargaHoraria> ListarTodos()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT id ");
            sb.Append("FROM CargaHoraria WHERE inactivo = 0");
            string cmdText = sb.ToString();

            List<CargaHoraria> cargasHorarias = new List<CargaHoraria>();
            using (IDataReader reader = dbManager.ExecuteReader(CommandType.Text, cmdText))
            {
                while (reader.Read())
                {
                    CargaHoraria cargaHoraria = ConstruirCargaHoraria(reader);
                    
                    cargasHorarias.Add(cargaHoraria);
                }
            }
            return cargasHorarias;
        }

        private CargaHoraria ConstruirCargaHoraria(IDataReader reader)
        {
            CargaHoraria cargaHoraria = new CargaHoraria();
            cargaHoraria.Id = reader.GetInt32(reader.GetOrdinal("id"));
            cargaHoraria.Horarios = estrategia.HorarioPersistenceManager.ListarPorIdDeCargaHoraria(cargaHoraria.Id);
            return cargaHoraria; 
        }

        public CargaHoraria ObtenerPorId(long id)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT id ");
            sb.Append("FROM CargaHoraria WHERE id = @id");
            string cmdText = sb.ToString();

            List<IDbDataParameter> pars = new List<IDbDataParameter>();
            pars.Add(dbManager.CrearParametro("@id", id));

            CargaHoraria cargaHoraria = null;

            using (IDataReader reader = dbManager.ExecuteReader(CommandType.Text, cmdText, pars))
            {
                if (reader.Read())
                {
                    cargaHoraria = ConstruirCargaHoraria(reader);
                }
            }


            return cargaHoraria;
        }

        //public CargaHoraria ObtenerPorIdEmpleado(long idEmpleado)
        //{
        //    StringBuilder sb = new StringBuilder();
        //    sb.Append("SELECT id ");
        //    sb.Append("FROM CargaHoraria WHERE id = @id");
        //    string cmdText = sb.ToString();

        //    List<IDbDataParameter> pars = new List<IDbDataParameter>();
        //    pars.Add(dbManager.CrearParametro("@id", id));

        //    CargaHoraria cargaHoraria = null;

        //    using (IDataReader reader = dbManager.ExecuteReader(CommandType.Text, cmdText, pars))
        //    {
        //        if (reader.Read())
        //        {
        //            cargaHoraria = ConstruirCargaHoraria(reader);
        //        }
        //    }

        //    return cargaHoraria;
        //}
    }
}
