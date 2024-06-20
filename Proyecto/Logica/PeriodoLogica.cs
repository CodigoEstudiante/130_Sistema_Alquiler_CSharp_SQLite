using Proyecto.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Logica
{
    public class PeriodoLogica
    {
        private static PeriodoLogica _instancia = null;

        public PeriodoLogica()
        {

        }

        public static PeriodoLogica Instancia
        {

            get
            {
                if (_instancia == null) _instancia = new PeriodoLogica();
                return _instancia;
            }
        }

        public List<Periodo> Listar(int idalquiler)
        {
            List<Periodo> oLista = new List<Periodo>();
            try
            {
                using (SQLiteConnection conexion = new SQLiteConnection(Conexion.cadena))
                {
                    conexion.Open();
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select IdPeriodo,NumeroPeriodo,strftime('%d/%m/%Y', date(FechaLimitePeriodo))[FechaLimitePeriodo] ,EstadoPeriodo,ProximoPagar,ifnull(Monto,'')[Monto],strftime('%d/%m/%Y', date(FechaPago))[FechaPago] from PERIODO");
                    query.AppendLine("where IdAlquiler = @id");

                    SQLiteCommand cmd = new SQLiteCommand(query.ToString(), conexion);
                    cmd.Parameters.Add(new SQLiteParameter("@id", idalquiler));
                    cmd.CommandType = System.Data.CommandType.Text;

                    using (SQLiteDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oLista.Add(new Periodo()
                            {
                                IdPeriodo = Convert.ToInt32(dr["IdPeriodo"].ToString()),
                                NumeroPeriodo = Convert.ToInt32(dr["NumeroPeriodo"].ToString()),
                                FechaLimitePeriodo = dr["FechaLimitePeriodo"].ToString(),
                                EstadoPeriodo = dr["EstadoPeriodo"].ToString(),
                                ProximoPagar = Convert.ToInt32(dr["ProximoPagar"].ToString()),
                                Monto = dr["Monto"].ToString() == ""? 0 : Convert.ToDecimal(dr["Monto"].ToString()),
                                FechaPago = dr["FechaPago"].ToString()
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                oLista = new List<Periodo>();
            }


            return oLista;
        }
    }
}
