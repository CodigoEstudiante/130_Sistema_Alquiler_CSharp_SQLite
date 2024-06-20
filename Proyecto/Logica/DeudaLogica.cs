using Proyecto.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Logica
{
    class DeudaLogica
    {
        private static DeudaLogica _instancia = null;

        public DeudaLogica()
        {

        }

        public static DeudaLogica Instancia
        {

            get
            {
                if (_instancia == null) _instancia = new DeudaLogica();
                return _instancia;
            }
        }

        public int Pagar(Deuda objeto,int idalquiler, out string mensaje)
        {
            mensaje = string.Empty;
            int respuesta = 0;
            try
            {

                using (SQLiteConnection conexion = new SQLiteConnection(Conexion.cadena))
                {

                    conexion.Open();
                    StringBuilder query = new StringBuilder();

                    query.AppendLine("update DEUDA set EstadoDeuda = 'CANCELADO', FechaPago=@pfechapago WHERE IdDeuda = @pideuda;");
                    query.AppendLine("UPDATE PERIODO set EstadoPeriodo = 'CANCELADO' WHERE IdPeriodo = @pidperiodo and IdAlquiler = @idalquiler;");

                    SQLiteCommand cmd = new SQLiteCommand(query.ToString(), conexion);
                    cmd.Parameters.Add(new SQLiteParameter("@pfechapago", objeto.FechaPago));
                    cmd.Parameters.Add(new SQLiteParameter("@pideuda", objeto.IdDeuda));
                    cmd.Parameters.Add(new SQLiteParameter("@pidperiodo", objeto.IdPeriodo));
                    cmd.Parameters.Add(new SQLiteParameter("@idalquiler", idalquiler));
                    cmd.CommandType = System.Data.CommandType.Text;
                    respuesta = cmd.ExecuteNonQuery();
                    if (respuesta < 1)
                        mensaje = "No se puede registrar el pago";

                }
            }
            catch (Exception ex)
            {

                respuesta = 0;
                mensaje = ex.Message;
            }

            return respuesta;
        }

        public List<Deuda> Listar(int idalquiler)
        {
            List<Deuda> oLista = new List<Deuda>();

            try
            {

                using (SQLiteConnection conexion = new SQLiteConnection(Conexion.cadena))
                {
                    conexion.Open();


                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select d.IdDeuda,p.IdPeriodo, p.NumeroPeriodo,d.MontoDeuda,d.EstadoDeuda,strftime('%d/%m/%Y', date(d.FechaPago))[FechaPago] from DEUDA d");
                    query.AppendLine("inner join PERIODO p on p.IdPeriodo = d.IdPeriodo");
                    query.AppendLine("inner join ALQUILER a on a.IdAlquiler = p.IdAlquiler");
                    query.AppendLine("where a.IdAlquiler = @pid");

                    SQLiteCommand cmd = new SQLiteCommand(query.ToString(), conexion);
                    cmd.Parameters.Add(new SQLiteParameter("@pid", idalquiler));
                    cmd.CommandType = System.Data.CommandType.Text;

                    using (SQLiteDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oLista.Add(new Deuda()
                            {
                                IdDeuda = int.Parse(dr["IdDeuda"].ToString()),
                                IdPeriodo = int.Parse(dr["IdPeriodo"].ToString()),
                                NumeroPeriodo = int.Parse(dr["NumeroPeriodo"].ToString()),
                                MontoDeuda = dr["MontoDeuda"].ToString(),
                                EstadoDeuda = dr["EstadoDeuda"].ToString(),
                                FechaPago = dr["FechaPago"].ToString()
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                oLista = new List<Deuda>();
            }


            return oLista;
        }
    }
}
