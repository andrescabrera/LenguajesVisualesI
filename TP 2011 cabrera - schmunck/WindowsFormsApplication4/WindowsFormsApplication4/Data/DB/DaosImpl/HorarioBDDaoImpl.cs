using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ControlAsistencia.Clases;
using ControlAsistencia.Daos;
using System.Data;

namespace ControlAsistencia.Data.DB.DaosImpl
{
    public class HorarioBDDaoImpl : DBDao, IHorarioDAO
    {
        
        public HorarioBDDaoImpl(DBEstrategiaPersistenceManager estrategia) : base(estrategia)
        { }

        public long Alta(Horario horario)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO Horario (dia, fechaDesde, fechaHasta, id_CargaHoraria) VALUES (@dia, @fechaDesde, @fechaHasta, @id_CargaHoraria)");

            string cmdText = sb.ToString();

            List<IDbDataParameter> pars = new List<IDbDataParameter>();
            pars.Add(dbManager.CrearParametro("@dia", (int)horario.Dia));
            pars.Add(dbManager.CrearParametro("@fechaDesde", horario.HoraEntrada));
            pars.Add(dbManager.CrearParametro("@fechaHasta", horario.HoraSalida));
            pars.Add(dbManager.CrearParametro("id_CargaHoraria", horario.CargaHoraria.Id));
            dbManager.ExecuteNonQuery(CommandType.Text, cmdText, pars);

            horario.Id = dbManager.GetIdentity();
            return horario.Id;
        }

        public void Eliminar(Horario horario)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE Horario SET inactivo=1 ");
            sb.Append("WHERE id = @id");
            string cmdText = sb.ToString();

            List<IDbDataParameter> pars = new List<IDbDataParameter>();
            pars.Add(dbManager.CrearParametro("@id", horario.Id));

            dbManager.ExecuteNonQuery(CommandType.Text, cmdText, pars);
        }

        public void Modificar(Horario horario)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE Horario SET dia = @dia, fechaDesde = @fechaDesde, fechaHasta= @fechaHasta ");
            sb.Append("WHERE id = @id");
            string cmdText = sb.ToString();

            List<IDbDataParameter> pars = new List<IDbDataParameter>();
            pars.Add(dbManager.CrearParametro("@id", horario.Id));
            pars.Add(dbManager.CrearParametro("@dia", (int)horario.Dia));
            pars.Add(dbManager.CrearParametro("@fechaDesde", horario.HoraEntrada));
            pars.Add(dbManager.CrearParametro("@fechaHasta", horario.HoraSalida));

            dbManager.ExecuteNonQuery(CommandType.Text, cmdText, pars);
        }

        public List<Horario> ListarTodos()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT id, dia, fechaDesde, fechaHasta ");
            sb.Append("FROM Horario WHERE inactivo = 0");
            string cmdText = sb.ToString();

            List<Horario> horarios = new List<Horario>();
            using (IDataReader reader = dbManager.ExecuteReader(CommandType.Text, cmdText))
            {
                while (reader.Read())
                {
                    Horario horario = ConstruirHorario(reader);

                    horarios.Add(horario);
                }
            }
            return horarios;
        }

        public List<Horario> ListarPorIdDeCargaHoraria(long idCargaHoraria)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT id, dia, fechaDesde, fechaHasta ");
            sb.Append("FROM Horario WHERE inactivo = 0 AND id_CargaHoraria = @id_CargaHoraria");
            string cmdText = sb.ToString();

            List<Horario> horarios = new List<Horario>();
            
            List<IDbDataParameter> pars = new List<IDbDataParameter>();
            pars.Add(dbManager.CrearParametro("@id_CargaHoraria", idCargaHoraria));
            using (IDataReader reader = dbManager.ExecuteReader(CommandType.Text, cmdText, pars))
            {
                while (reader.Read())
                {
                    Horario horario = ConstruirHorario(reader);

                    horarios.Add(horario);
                }
            }
            return horarios;
        }

        private Horario ConstruirHorario(IDataReader reader)
        {
            Horario horario = new Horario();
            horario.Id = reader.GetInt32(reader.GetOrdinal("id"));
            horario.Dia = (DayOfWeek)reader.GetInt32(reader.GetOrdinal("dia")); //TODO fijarse bien como hacer el manejo del dia ya que es de tipo DayOfWeek. Toti.
            horario.HoraEntrada = reader.GetDateTime(reader.GetOrdinal("fechaDesde"));
            horario.HoraSalida = reader.GetDateTime(reader.GetOrdinal("fechaHasta"));

            return horario; 
        }

        public Horario ObtenerPorId(long id)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT id, dia, fechaDesde, fechaHasta ");
            sb.Append("FROM Horario WHERE id = @id");
            string cmdText = sb.ToString();

            List<IDbDataParameter> pars = new List<IDbDataParameter>();
            pars.Add(dbManager.CrearParametro("@id", id));

            Horario horario = null;

            using (IDataReader reader = dbManager.ExecuteReader(CommandType.Text, cmdText, pars))
            {
                if (reader.Read())
                {
                    horario = ConstruirHorario(reader);
                }
            }

            return horario;
        }
    }
}
