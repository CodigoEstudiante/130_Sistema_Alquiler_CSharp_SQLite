using Proyecto.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Logica
{
    public class InmuebleLogica
    {
        private static InmuebleLogica _instancia = null;

        public InmuebleLogica()
        {

        }

        public static InmuebleLogica Instancia
        {

            get
            {
                if (_instancia == null) _instancia = new InmuebleLogica();
                return _instancia;
            }
        }

        public int Existe(string codigo, int defaultid, out string mensaje)
        {

            mensaje = string.Empty;
            int respuesta = 0;
            try
            {

                using (SQLiteConnection conexion = new SQLiteConnection(Conexion.cadena))
                {

                    conexion.Open();
                    StringBuilder query = new StringBuilder();

                    query.AppendLine("select count(*)[resultado] from INMUEBLE where upper(Codigo) = upper(@codigo) and IdInmueble != @defaultid");

                    SQLiteCommand cmd = new SQLiteCommand(query.ToString(), conexion);
                    cmd.Parameters.Add(new SQLiteParameter("@codigo", codigo));
                    cmd.Parameters.Add(new SQLiteParameter("@defaultid", defaultid));
                    cmd.CommandType = System.Data.CommandType.Text;

                    respuesta = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                    if (respuesta == 1)
                        mensaje = "Ya existe el codigo de inmueble";

                }
            }
            catch (Exception ex)
            {

                respuesta = 0;
                mensaje = ex.Message;
            }

            return respuesta;
        }

        public int Guardar(Inmueble objeto, out string mensaje)
        {
            mensaje = string.Empty;
            int respuesta = 0;
            try
            {

                using (SQLiteConnection conexion = new SQLiteConnection(Conexion.cadena))
                {

                    conexion.Open();
                    StringBuilder query = new StringBuilder();

                    query.AppendLine("insert into INMUEBLE(Codigo,IdTipoInmueble,Direccion,Descripcion,PrecioAlquiler) values (@codigo,@idtipoinmueble,@direccion,@descripcion,@precioalquiler);");
                    query.AppendLine("SELECT ifnull(MAX(IdInmueble),0) FROM INMUEBLE WHERE upper(Codigo) = upper(@codigo) ORDER BY IdInmueble DESC LIMIT 1;");

                    SQLiteCommand cmd = new SQLiteCommand(query.ToString(), conexion);
                    cmd.Parameters.Add(new SQLiteParameter("@codigo", objeto.Codigo));
                    cmd.Parameters.Add(new SQLiteParameter("@idtipoinmueble", objeto.oTipoInmueble.IdTipoInmueble));
                    cmd.Parameters.Add(new SQLiteParameter("@direccion", objeto.Direccion));
                    cmd.Parameters.Add(new SQLiteParameter("@descripcion", objeto.Descripcion));
                    cmd.Parameters.Add(new SQLiteParameter("@precioalquiler", objeto.PrecioAlquiler.ToString("0.00")));
                    cmd.CommandType = System.Data.CommandType.Text;

                    respuesta = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                    if (respuesta < 1)
                        mensaje = "No se pudo registrar elinmueble";

                }
            }
            catch (Exception ex)
            {

                respuesta = 0;
                mensaje = ex.Message;
            }

            return respuesta;
        }

        public int Editar(Inmueble objeto, out string mensaje)
        {
            mensaje = string.Empty;
            int respuesta = 0;
            try
            {

                using (SQLiteConnection conexion = new SQLiteConnection(Conexion.cadena))
                {

                    conexion.Open();
                    StringBuilder query = new StringBuilder();

                    query.AppendLine("update INMUEBLE set Codigo = @codigo,IdTipoInmueble = @idtipoinmueble,Direccion = @direccion,Descripcion = @descripcion,PrecioAlquiler =@precioalquiler");
                    query.AppendLine("where idinmueble = @idinmueble");

                    SQLiteCommand cmd = new SQLiteCommand(query.ToString(), conexion);
                    cmd.Parameters.Add(new SQLiteParameter("@idinmueble", objeto.IdInmueble));
                    cmd.Parameters.Add(new SQLiteParameter("@codigo", objeto.Codigo));
                    cmd.Parameters.Add(new SQLiteParameter("@idtipoinmueble", objeto.oTipoInmueble.IdTipoInmueble));
                    cmd.Parameters.Add(new SQLiteParameter("@direccion", objeto.Direccion));
                    cmd.Parameters.Add(new SQLiteParameter("@descripcion", objeto.Descripcion));
                    cmd.Parameters.Add(new SQLiteParameter("@precioalquiler", objeto.PrecioAlquiler.ToString("0.00")));
                    cmd.CommandType = System.Data.CommandType.Text;

                    respuesta = cmd.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {

                respuesta = 0;
                mensaje = ex.Message;
            }

            return respuesta;
        }


        public List<Inmueble> Listar(out string mensaje)
        {
            mensaje = string.Empty;
            List<Inmueble> oLista = new List<Inmueble>();

            try
            {

                using (SQLiteConnection conexion = new SQLiteConnection(Conexion.cadena))
                {
                    conexion.Open();

                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select i.IdInmueble,i.Codigo,ti.IdTipoInmueble,ti.Descripcion[DescripcionTI],i.Direccion,i.Descripcion,i.Estado,I.PrecioAlquiler from INMUEBLE i");
                    query.AppendLine("inner join TIPO_INMUEBLE ti on ti.IdTipoInmueble = i.IdTipoInmueble");

                    SQLiteCommand cmd = new SQLiteCommand(query.ToString(), conexion);
                    cmd.CommandType = System.Data.CommandType.Text;

                    using (SQLiteDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oLista.Add(new Inmueble()
                            {
                                IdInmueble = int.Parse(dr["IdInmueble"].ToString()),
                                Codigo = dr["Codigo"].ToString(),
                                oTipoInmueble = new TipoInmueble() {
                                    IdTipoInmueble = int.Parse(dr["IdTipoInmueble"].ToString()),
                                    Descripcion = dr["DescripcionTI"].ToString(),
                                },
                                Direccion = dr["Direccion"].ToString(),
                                Descripcion = dr["Descripcion"].ToString(),
                                Estado = dr["Estado"].ToString(),
                                PrecioAlquiler = Convert.ToDecimal(dr["PrecioAlquiler"].ToString()),
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                oLista = new List<Inmueble>();
                mensaje = ex.Message;
            }


            return oLista;
        }


        public int Validar(int id, out string mensaje)
        {

            mensaje = string.Empty;
            int respuesta = 0;
            try
            {

                using (SQLiteConnection conexion = new SQLiteConnection(Conexion.cadena))
                {

                    conexion.Open();
                    StringBuilder query = new StringBuilder();

                    query.AppendLine("select count(*) from INMUEBLE i");
                    query.AppendLine("inner join ALQUILER a on a.IdInmueble = i.IdInmueble");
                    query.AppendLine("where i.IdInmueble = @id");

                    SQLiteCommand cmd = new SQLiteCommand(query.ToString(), conexion);
                    cmd.Parameters.Add(new SQLiteParameter("@id", id));
                    cmd.CommandType = System.Data.CommandType.Text;

                    respuesta = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                    if (respuesta == 1)
                        mensaje = "No se puede eliminar.\nEl inmueble ya se encuentra asignado a un Alquiler.";

                }
            }
            catch (Exception ex)
            {

                respuesta = 0;
                mensaje = ex.Message;
            }

            return respuesta;
        }


        public int Eliminar(int id)
        {
            int respuesta = 0;
            try
            {
                using (SQLiteConnection conexion = new SQLiteConnection(Conexion.cadena))
                {

                    conexion.Open();
                    StringBuilder query = new StringBuilder();

                    query.AppendLine("delete from INMUEBLE where IdInmueble= @idinmueble;");

                    SQLiteCommand cmd = new SQLiteCommand(query.ToString(), conexion);
                    cmd.Parameters.Add(new SQLiteParameter("@idinmueble", id));
                    cmd.CommandType = System.Data.CommandType.Text;

                    respuesta = cmd.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {

                respuesta = 0;
            }

            return respuesta;
        }

    }
}
