using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto.Modelo;

namespace Proyecto.Logica
{
    public class AlquilerLogica
    {

        private static AlquilerLogica _instancia = null;

        public AlquilerLogica()
        {

        }

        public static AlquilerLogica Instancia
        {

            get
            {
                if (_instancia == null) _instancia = new AlquilerLogica();
                return _instancia;
            }
        }

        public int ObtenerCorrelativo(out string mensaje)
        {

            mensaje = string.Empty;
            int respuesta = 0;
            try
            {

                using (SQLiteConnection conexion = new SQLiteConnection(Conexion.cadena))
                {

                    conexion.Open();
                    StringBuilder query = new StringBuilder();

                    query.AppendLine("select count(*) + 1 from ALQUILER");

                    SQLiteCommand cmd = new SQLiteCommand(query.ToString(), conexion);
                    cmd.CommandType = System.Data.CommandType.Text;

                    respuesta = Convert.ToInt32(cmd.ExecuteScalar().ToString());

                }
            }
            catch (Exception ex)
            {

                respuesta = 0;
                mensaje = ex.Message;
            }

            return respuesta;
        }


        public int Registrar(Alquiler oAlquiler, List<Periodo> oListaPeriodo, out string mensaje)
        {

            mensaje = string.Empty;
            int respuesta = 0;
            SQLiteTransaction objTransaccion = null;

            using (SQLiteConnection conexion = new SQLiteConnection(Conexion.cadena))
            {
                try
                {
                    conexion.Open();
                    objTransaccion = conexion.BeginTransaction();
                    StringBuilder query = new StringBuilder();

                    query.AppendLine("CREATE TEMP TABLE _TEMP(id INTEGER);");

                    query.AppendLine(string.Format("Insert into ALQUILER(CodigoAlquiler,NombreCliente,TipoDocumentoCliente,DocumentoCliente,TelefonoCliente,CorreoCliente,NacionalidadCliente,IdInmueble,IdTipoAlquiler,IdTipoMoneda,CantidadPeriodo,PrecioAlquiler,FechaInicioAlquiler,FechaFinAlquiler,FechaRegistro,Clausulas,Estado) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}',{7},{8},{9},{10},'{11}','{12}','{13}','{14}','{15}','{16}');",
                        oAlquiler.CodigoAlquiler,
                        oAlquiler.NombreCliente,
                        oAlquiler.TipoDocumentoCliente,
                        oAlquiler.DocumentoCliente,
                        oAlquiler.TelefonoCliente,
                        oAlquiler.CorreoCliente,
                        oAlquiler.NacionalidadCliente,
                        oAlquiler.oInmueble.IdInmueble,
                        oAlquiler.oTipoAlquiler.IdTipoAlquiler,
                        oAlquiler.oTipoMoneda.IdTipoMoneda,
                        oAlquiler.CantidadPeriodo,
                        oAlquiler.PrecioAlquiler.ToString("0.00"),
                        oAlquiler.FechaInicioAlquiler,
                        oAlquiler.FechaFinAlquiler,
                        oAlquiler.FechaRegistro,
                        oAlquiler.Clausulas,
                        "EN CURSO"
                        ));

                    query.AppendLine(string.Format("UPDATE INMUEBLE SET Estado = 'OCUPADO' WHERE IdInmueble = {0};", oAlquiler.oInmueble.IdInmueble));

                    query.AppendLine("INSERT INTO _TEMP (id) VALUES (last_insert_rowid());");
                
                    foreach (Periodo p in oListaPeriodo)
                    {
                        query.AppendLine(string.Format("insert into PERIODO(NumeroPeriodo,IdAlquiler,FechaLimitePeriodo,EstadoPeriodo,ProximoPagar) values({0},{1},'{2}','{3}',{4});",
                            p.NumeroPeriodo,
                            "(select id from _TEMP)",
                            p.FechaLimitePeriodo,
                            p.EstadoPeriodo,
                            p.ProximoPagar
                            ));
                    }

                    query.AppendLine("DROP TABLE _TEMP;");

                    SQLiteCommand cmd = new SQLiteCommand(query.ToString(), conexion);
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Transaction = objTransaccion;
                    respuesta = cmd.ExecuteNonQuery();


                    if (respuesta < 1)
                    {
                        objTransaccion.Rollback();
                        mensaje = "No se pudo registrar el alquiler";
                    }

                    objTransaccion.Commit();

                }
                catch (Exception ex)
                {
                    objTransaccion.Rollback();
                    respuesta = 0;
                    mensaje = ex.Message;
                }
            }
            

            return respuesta;
        }

        public List<Alquiler> Listar(string codigoalquiler, int idinmueble, string fechainicio = "", string fechafin = "")
        {
            List<Alquiler> oLista = new List<Alquiler>();

            try
            {

                using (SQLiteConnection conexion = new SQLiteConnection(Conexion.cadena))
                {
                    conexion.Open();

                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select a.IdAlquiler, a.CodigoAlquiler,a.NombreCliente,a.TipoDocumentoCliente,a.DocumentoCliente,a.TelefonoCliente,a.CorreoCliente,");
                    query.AppendLine("a.NacionalidadCliente,i.Codigo,ti.Descripcion[DescripcionTI],i.Descripcion[DescripcionI],");
                    query.AppendLine("ta.Descripcion[DescripcionTA],a.CantidadPeriodo,tm.Descripcion[DescripcionTM],a.PrecioAlquiler,");
                    query.AppendLine("strftime('%d/%m/%Y', date(a.FechaInicioAlquiler))[FechaInicioAlquiler],Clausulas,strftime('%d/%m/%Y', date(a.FechaRegistro))[FechaRegistro],a.Estado");
                    query.AppendLine("from ALQUILER a");
                    query.AppendLine("inner join INMUEBLE i on i.IdInmueble = a.IdInmueble");
                    query.AppendLine("inner join TIPO_INMUEBLE ti on ti.IdTipoInmueble = i.IdTipoInmueble");
                    query.AppendLine("inner join TIPO_ALQUILER ta on ta.IdTipoAlquiler = a.IdTipoAlquiler");
                    query.AppendLine("inner join TIPO_MONEDA tm on tm.IdTipoMoneda = a.IdTipoMoneda");
                    query.AppendLine("where upper(a.CodigoAlquiler) = iif(upper(@pcodigoalquiler) ='',a.CodigoAlquiler,upper(@pcodigoalquiler))");
                    query.AppendLine("and i.IdInmueble = iif(@pidinmueble=0,i.IdInmueble,@pidinmueble)");
                    query.AppendLine("and DATE(a.FechaRegistro) BETWEEN iif(@pfechainicio='',DATE(a.FechaRegistro),DATE(@pfechainicio))  AND iif(@pfechafin='',DATE(a.FechaRegistro),DATE(@pfechafin))");

                    SQLiteCommand cmd = new SQLiteCommand(query.ToString(), conexion);
                    cmd.Parameters.Add(new SQLiteParameter("@pcodigoalquiler", codigoalquiler));
                    cmd.Parameters.Add(new SQLiteParameter("@pidinmueble", idinmueble));
                    cmd.Parameters.Add(new SQLiteParameter("@pfechainicio", fechainicio));
                    cmd.Parameters.Add(new SQLiteParameter("@pfechafin", fechafin));
                    cmd.CommandType = System.Data.CommandType.Text;

                    using (SQLiteDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oLista.Add(new Alquiler()
                            {
                                IdAlquiler = Convert.ToInt32(dr["IdAlquiler"].ToString()),
                                CodigoAlquiler = dr["CodigoAlquiler"].ToString(),
                                NombreCliente = dr["NombreCliente"].ToString(),
                                TipoDocumentoCliente = dr["TipoDocumentoCliente"].ToString(),
                                DocumentoCliente = dr["DocumentoCliente"].ToString(),
                                TelefonoCliente = dr["TelefonoCliente"].ToString(),
                                CorreoCliente = dr["CorreoCliente"].ToString(),
                                NacionalidadCliente = dr["NacionalidadCliente"].ToString(),
                                oInmueble = new Inmueble()
                                {
                                    Codigo = dr["Codigo"].ToString(),
                                    oTipoInmueble = new TipoInmueble() { Descripcion = dr["DescripcionTI"].ToString() },
                                    Descripcion = dr["DescripcionI"].ToString()
                                },
                                oTipoAlquiler = new TipoAlquiler() { Descripcion = dr["DescripcionTA"].ToString() },
                                CantidadPeriodo = int.Parse(dr["CantidadPeriodo"].ToString()),
                                oTipoMoneda = new TipoMoneda() { Descripcion = dr["DescripcionTM"].ToString() },
                                PrecioAlquiler = Convert.ToDecimal(dr["PrecioAlquiler"].ToString()),
                                FechaInicioAlquiler = dr["FechaInicioAlquiler"].ToString(),
                                Clausulas = dr["Clausulas"].ToString(),
                                FechaRegistro = dr["FechaRegistro"].ToString(),
                                Estado = dr["Estado"].ToString()

                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                oLista = new List<Alquiler>();
            }


            return oLista;
        }


        public Alquiler Obtener(string codigoalquiler, int idinmueble)
        {
            Alquiler objeto = new Alquiler();

            try
            {
                using (SQLiteConnection conexion = new SQLiteConnection(Conexion.cadena))
                {
                    conexion.Open();
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select a.IdAlquiler, a.CodigoAlquiler,a.NombreCliente,a.TipoDocumentoCliente,a.DocumentoCliente,a.TelefonoCliente,a.CorreoCliente,");
                    query.AppendLine("a.NacionalidadCliente,i.Codigo,ti.Descripcion[DescripcionTI],i.Descripcion[DescripcionI],");
                    query.AppendLine("ta.Descripcion[DescripcionTA],a.CantidadPeriodo,tm.Descripcion[DescripcionTM],a.PrecioAlquiler,");
                    query.AppendLine("strftime('%d/%m/%Y', date(a.FechaInicioAlquiler))[FechaInicioAlquiler],Clausulas,strftime('%d/%m/%Y', date(a.FechaRegistro))[FechaRegistro],a.Estado");
                    query.AppendLine("from ALQUILER a");
                    query.AppendLine("inner join INMUEBLE i on i.IdInmueble = a.IdInmueble");
                    query.AppendLine("inner join TIPO_INMUEBLE ti on ti.IdTipoInmueble = i.IdTipoInmueble");
                    query.AppendLine("inner join TIPO_ALQUILER ta on ta.IdTipoAlquiler = a.IdTipoAlquiler");
                    query.AppendLine("inner join TIPO_MONEDA tm on tm.IdTipoMoneda = a.IdTipoMoneda");
                    query.AppendLine("where upper(a.CodigoAlquiler) = iif(upper(@pcodigoalquiler) ='',a.CodigoAlquiler,upper(@pcodigoalquiler))");
                    query.AppendLine("and i.IdInmueble = iif(@pidinmueble=0,i.IdInmueble,@pidinmueble)");
                    query.AppendLine("ORDER BY a.IdAlquiler DESC LIMIT 1;");

                    SQLiteCommand cmd = new SQLiteCommand(query.ToString(), conexion);
                    cmd.Parameters.Add(new SQLiteParameter("@pcodigoalquiler", codigoalquiler));
                    cmd.Parameters.Add(new SQLiteParameter("@pidinmueble", idinmueble));
                    cmd.CommandType = System.Data.CommandType.Text;

                    using (SQLiteDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            objeto = new Alquiler()
                            {
                                IdAlquiler = Convert.ToInt32(dr["IdAlquiler"].ToString()),
                                CodigoAlquiler = dr["CodigoAlquiler"].ToString(),
                                NombreCliente = dr["NombreCliente"].ToString(),
                                TipoDocumentoCliente = dr["TipoDocumentoCliente"].ToString(),
                                DocumentoCliente = dr["DocumentoCliente"].ToString(),
                                TelefonoCliente = dr["TelefonoCliente"].ToString(),
                                CorreoCliente = dr["CorreoCliente"].ToString(),
                                NacionalidadCliente = dr["NacionalidadCliente"].ToString(),
                                oInmueble = new Inmueble() {
                                    Codigo = dr["Codigo"].ToString(),
                                    oTipoInmueble = new TipoInmueble() { Descripcion = dr["DescripcionTI"].ToString() },
                                    Descripcion = dr["DescripcionI"].ToString()
                                },
                                oTipoAlquiler = new TipoAlquiler() { Descripcion = dr["DescripcionTA"].ToString() },
                                CantidadPeriodo = int.Parse(dr["CantidadPeriodo"].ToString()),
                                oTipoMoneda = new TipoMoneda() { Descripcion = dr["DescripcionTM"].ToString() },
                                PrecioAlquiler = Convert.ToDecimal(dr["PrecioAlquiler"].ToString()),
                                FechaInicioAlquiler = dr["FechaInicioAlquiler"].ToString(),
                                Clausulas = dr["Clausulas"].ToString(),
                                FechaRegistro = dr["FechaRegistro"].ToString(),
                                Estado = dr["Estado"].ToString()

                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                objeto = new Alquiler();
            }
            return objeto;
        }



        public int Cancelar(int IdAlquiler, out string mensaje)
        {

            mensaje = string.Empty;
            int respuesta = 0;
            SQLiteTransaction objTransaccion = null;
            
            using (SQLiteConnection conexion = new SQLiteConnection(Conexion.cadena))
            {

                try
                {
                    conexion.Open();
                    objTransaccion = conexion.BeginTransaction();
                    StringBuilder query = new StringBuilder();

                    query.AppendLine(string.Format("UPDATE INMUEBLE SET Estado = 'LIBRE' WHERE IdInmueble = (SELECT IdInmueble FROM ALQUILER WHERE IdAlquiler = {0});",IdAlquiler));
                    query.AppendLine(string.Format("UPDATE ALQUILER SET Estado = '{0}' WHERE IdAlquiler = {1};","CANCELADO",IdAlquiler));

                

                    SQLiteCommand cmd = new SQLiteCommand(query.ToString(), conexion);
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Transaction = objTransaccion;
                    respuesta = cmd.ExecuteNonQuery();


                    if (respuesta < 1)
                    {
                        objTransaccion.Rollback();
                        mensaje = "No se pudo cancelar el contrato";
                    }

                    objTransaccion.Commit();

                }
                catch (Exception ex)
                {
                    objTransaccion.Rollback();
                    respuesta = 0;
                    mensaje = ex.Message;
                }

            }
            return respuesta;
        }

        public int Editar(Alquiler obj, out string mensaje)
        {

            mensaje = string.Empty;
            int respuesta = 0;
            SQLiteTransaction objTransaccion = null;

            using (SQLiteConnection conexion = new SQLiteConnection(Conexion.cadena))
            {

                try
                {
                    conexion.Open();
                    objTransaccion = conexion.BeginTransaction();
                    StringBuilder query = new StringBuilder();

                    query.AppendLine("UPDATE ALQUILER SET NombreCliente = @pnombre,");
                    query.AppendLine("TipoDocumentoCliente = @ptipodoc,");
                    query.AppendLine("DocumentoCliente = @pdoc,");
                    query.AppendLine("TelefonoCliente = @ptelefono,");
                    query.AppendLine("CorreoCliente = @pcorreo,");
                    query.AppendLine("NacionalidadCliente = @pnacionalidad,");
                    query.AppendLine("Clausulas = @pclausulas");
                    query.AppendLine("WHERE IdAlquiler = @pid;");


                    SQLiteCommand cmd = new SQLiteCommand(query.ToString(), conexion);
                    cmd.Parameters.Add(new SQLiteParameter("@pnombre", obj.NombreCliente));
                    cmd.Parameters.Add(new SQLiteParameter("@ptipodoc", obj.TipoDocumentoCliente));
                    cmd.Parameters.Add(new SQLiteParameter("@pdoc", obj.DocumentoCliente));
                    cmd.Parameters.Add(new SQLiteParameter("@ptelefono", obj.TelefonoCliente));
                    cmd.Parameters.Add(new SQLiteParameter("@pcorreo", obj.CorreoCliente));
                    cmd.Parameters.Add(new SQLiteParameter("@pnacionalidad", obj.NacionalidadCliente));
                    cmd.Parameters.Add(new SQLiteParameter("@pclausulas", obj.Clausulas));
                    cmd.Parameters.Add(new SQLiteParameter("@pid", obj.IdAlquiler));
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Transaction = objTransaccion;
                    respuesta = cmd.ExecuteNonQuery();


                    if (respuesta < 1)
                    {
                        objTransaccion.Rollback();
                        mensaje = "No se pudo guardar los cambios";
                    }

                    objTransaccion.Commit();

                }
                catch (Exception ex)
                {
                    objTransaccion.Rollback();
                    respuesta = 0;
                    mensaje = ex.Message;
                }

            }
            return respuesta;
        }


        public int Pagar(Alquiler oAlquiler, Periodo oPeriodo,bool TieneDeuda, decimal MontoDeuda, out string mensaje)
        {

            mensaje = string.Empty;
            int respuesta = 0;
            SQLiteTransaction objTransaccion = null;

            using (SQLiteConnection conexion = new SQLiteConnection(Conexion.cadena))
            {

                try
                {
                    conexion.Open();
                    objTransaccion = conexion.BeginTransaction();
                    StringBuilder query = new StringBuilder();

                    //VALIDAMOS SI TIENE DEUDA
                    if (TieneDeuda)
                    {
                        query.AppendLine(string.Format("INSERT INTO DEUDA(IdPeriodo,MontoDeuda,EstadoDeuda) VALUES({0},'{1}','PENDIENTE');", oPeriodo.IdPeriodo, MontoDeuda.ToString("0.00")));
                        query.AppendLine(string.Format("update PERIODO set EstadoPeriodo = 'EN DEUDA' , ProximoPagar = 0 , Monto = '{0}', FechaPago='{1}' WHERE IdAlquiler = {2} AND IdPeriodo = {3} AND NumeroPeriodo = {4};", oPeriodo.Monto,oPeriodo.FechaPago, oAlquiler.IdAlquiler, oPeriodo.IdPeriodo, oPeriodo.NumeroPeriodo));
                    }
                    else {
                        query.AppendLine(string.Format("update PERIODO set EstadoPeriodo = 'CANCELADO' , ProximoPagar = 0 , Monto = '{0}', FechaPago='{1}' WHERE IdAlquiler = {2} AND IdPeriodo = {3} AND NumeroPeriodo = {4};", oPeriodo.Monto,oPeriodo.FechaPago, oAlquiler.IdAlquiler, oPeriodo.IdPeriodo, oPeriodo.NumeroPeriodo));
                    }

                    //VALIDAMOS SI ES EL ULTIMO PERIODO A PAGAR
                    if (oAlquiler.CantidadPeriodo > oPeriodo.NumeroPeriodo)
                    {
                        oPeriodo.NumeroPeriodo += 1;
                        query.AppendLine(string.Format("UPDATE PERIODO SET ProximoPagar = 1 WHERE IdAlquiler = {0} AND NumeroPeriodo = {1};", oAlquiler.IdAlquiler, oPeriodo.NumeroPeriodo));
                    }
                    else {
                        query.AppendLine(string.Format("UPDATE ALQUILER SET Estado = 'CERRADO' where IdAlquiler = {0};",oAlquiler.IdAlquiler));
                        query.AppendLine(string.Format("UPDATE INMUEBLE SET Estado = 'LIBRE' WHERE IdInmueble = (SELECT IdInmueble FROM ALQUILER WHERE IdAlquiler ={0});",oAlquiler.IdAlquiler));
                    }
                    

                    SQLiteCommand cmd = new SQLiteCommand(query.ToString(), conexion);
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Transaction = objTransaccion;
                    respuesta = cmd.ExecuteNonQuery();


                    if (respuesta < 1)
                    {
                        objTransaccion.Rollback();
                        mensaje = "No se pudo registrar el pago";
                    }

                    objTransaccion.Commit();

                }
                catch (Exception ex)
                {
                    objTransaccion.Rollback();
                    respuesta = 0;
                    mensaje = ex.Message;
                }

            }
            return respuesta;
        }

    }
}
