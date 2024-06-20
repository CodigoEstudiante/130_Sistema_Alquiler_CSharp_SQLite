using Proyecto.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Logica
{
    public class VistaLogica
    {
        private static VistaLogica _instancia = null;

        public VistaLogica()
        {

        }

        public static VistaLogica Instancia
        {

            get
            {
                if (_instancia == null) _instancia = new VistaLogica();
                return _instancia;
            }
        }


        public List<Vista> ListarPagosPendientes()
        {
            List<Vista> oLista = new List<Vista>();

            try
            {

                using (SQLiteConnection conexion = new SQLiteConnection(Conexion.cadena))
                {
                    conexion.Open();

                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select a.CodigoAlquiler[CodigoContrato],a.NombreCliente[NombreCliente],ta.Descripcion[TipoAlquiler],");
                    query.AppendLine("ti.Descripcion[TipoInmueble],p.NumeroPeriodo[NumeroPeriodo],strftime('%d/%m/%Y', date(p.FechaLimitePeriodo))[FechaLimite]");
                    query.AppendLine("from ALQUILER a");
                    query.AppendLine("INNER JOIN INMUEBLE i on i.IdInmueble = a.IdInmueble");
                    query.AppendLine("INNER JOIN TIPO_INMUEBLE ti on ti.IdTipoInmueble = i.IdTipoInmueble");
                    query.AppendLine("INNER JOIN TIPO_ALQUILER ta on ta.IdTipoAlquiler = a.IdTipoAlquiler");
                    query.AppendLine("inner join PERIODO p on p.IdAlquiler = a.IdAlquiler");
                    query.AppendLine("where p.ProximoPagar = 1");
                    query.AppendLine("and(strftime('%m', date(p.FechaLimitePeriodo)) = strftime('%m', date('now', 'localtime')) or");
                    query.AppendLine("strftime('%m', date(p.FechaLimitePeriodo)) = strftime('%m', date('now', 'localtime', '-1 month')))");
                    query.AppendLine("order by date(p.FechaLimitePeriodo) ASC");

                    SQLiteCommand cmd = new SQLiteCommand(query.ToString(), conexion);
                    cmd.CommandType = System.Data.CommandType.Text;

                    using (SQLiteDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oLista.Add(new Vista()
                            {
                                CodigoContrato = dr["CodigoContrato"].ToString(),
                                NombreCliente = dr["NombreCliente"].ToString(),
                                TipoAlquiler = dr["TipoAlquiler"].ToString(),
                                TipoInmueble = dr["TipoInmueble"].ToString(),
                                NumeroPeriodo = dr["NumeroPeriodo"].ToString(),
                                FechaLimite = dr["FechaLimite"].ToString()
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                oLista = new List<Vista>();
            }


            return oLista;
        }


        public List<Vista> ListarDeudas()
        {
            List<Vista> oLista = new List<Vista>();

            try
            {

                using (SQLiteConnection conexion = new SQLiteConnection(Conexion.cadena))
                {
                    conexion.Open();

                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select a.CodigoAlquiler[CodigoContrato],a.NombreCliente[NombreCliente],ta.Descripcion[TipoAlquiler],");
                    query.AppendLine("ti.Descripcion[TipoInmueble],p.NumeroPeriodo[NumeroPeriodo],d.MontoDeuda");
                    query.AppendLine("from ALQUILER a");
                    query.AppendLine("INNER JOIN INMUEBLE i on i.IdInmueble = a.IdInmueble");
                    query.AppendLine("INNER JOIN TIPO_INMUEBLE ti on ti.IdTipoInmueble = i.IdTipoInmueble");
                    query.AppendLine("INNER JOIN TIPO_ALQUILER ta on ta.IdTipoAlquiler = a.IdTipoAlquiler");
                    query.AppendLine("inner join PERIODO p on p.IdAlquiler = a.IdAlquiler");
                    query.AppendLine("INNER join DEUDA d on d.IdPeriodo = p.IdPeriodo");
                    query.AppendLine("where d.EstadoDeuda = 'PENDIENTE'");
                    SQLiteCommand cmd = new SQLiteCommand(query.ToString(), conexion);
                    cmd.CommandType = System.Data.CommandType.Text;

                    using (SQLiteDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oLista.Add(new Vista()
                            {
                                CodigoContrato = dr["CodigoContrato"].ToString(),
                                NombreCliente = dr["NombreCliente"].ToString(),
                                TipoAlquiler = dr["TipoAlquiler"].ToString(),
                                TipoInmueble = dr["TipoInmueble"].ToString(),
                                NumeroPeriodo = dr["NumeroPeriodo"].ToString(),
                                MontoDeuda = dr["MontoDeuda"].ToString()
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                oLista = new List<Vista>();
            }


            return oLista;
        }

    }
}
