using Proyecto.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Logica
{
    public class TipoMonedaLogica
    {
        private static TipoMonedaLogica _instancia = null;

        public TipoMonedaLogica()
        {

        }

        public static TipoMonedaLogica Instancia
        {

            get
            {
                if (_instancia == null) _instancia = new TipoMonedaLogica();
                return _instancia;
            }
        }


        public List<TipoMoneda> Listar(out string mensaje)
        {
            mensaje = string.Empty;
            List<TipoMoneda> oLista = new List<TipoMoneda>();

            try
            {

                using (SQLiteConnection conexion = new SQLiteConnection(Conexion.cadena))
                {
                    conexion.Open();

                    string query = "select IdTipoMoneda,Descripcion from TIPO_MONEDA;";
                    SQLiteCommand cmd = new SQLiteCommand(query, conexion);
                    cmd.CommandType = System.Data.CommandType.Text;

                    using (SQLiteDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oLista.Add(new TipoMoneda()
                            {
                                IdTipoMoneda = int.Parse(dr["IdTipoMoneda"].ToString()),
                                Descripcion = dr["Descripcion"].ToString()
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                oLista = new List<TipoMoneda>();
                mensaje = ex.Message;
            }


            return oLista;
        }

        public int Existe(string Descripcion, int defaultid, out string mensaje)
        {

            mensaje = string.Empty;
            int respuesta = 0;
            try
            {

                using (SQLiteConnection conexion = new SQLiteConnection(Conexion.cadena))
                {

                    conexion.Open();
                    StringBuilder query = new StringBuilder();

                    query.AppendLine("select count(*)[resultado] from TIPO_MONEDA where upper(Descripcion) = upper(@descripcion) and IdTipoMoneda != @defaultid");

                    SQLiteCommand cmd = new SQLiteCommand(query.ToString(), conexion);
                    cmd.Parameters.Add(new SQLiteParameter("@descripcion", Descripcion));
                    cmd.Parameters.Add(new SQLiteParameter("@defaultid", defaultid));
                    cmd.CommandType = System.Data.CommandType.Text;

                    respuesta = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                    if (respuesta == 1)
                        mensaje = "Ya existe el tipo de moneda";

                }
            }
            catch (Exception ex)
            {

                respuesta = 0;
                mensaje = ex.Message;
            }

            return respuesta;
        }

        public int Guardar(TipoMoneda objeto, out string mensaje)
        {
            mensaje = string.Empty;
            int respuesta = 0;
            try
            {

                using (SQLiteConnection conexion = new SQLiteConnection(Conexion.cadena))
                {

                    conexion.Open();
                    StringBuilder query = new StringBuilder();

                    query.AppendLine("insert into TIPO_MONEDA(Descripcion) values (@descripcion);");
                    query.AppendLine("SELECT ifnull(MAX(IdTipoMoneda),0) FROM TIPO_MONEDA WHERE upper(Descripcion) = upper(@descripcion) ORDER BY IdTipoMoneda DESC LIMIT 1;");

                    SQLiteCommand cmd = new SQLiteCommand(query.ToString(), conexion);
                    cmd.Parameters.Add(new SQLiteParameter("@descripcion", objeto.Descripcion));
                    cmd.CommandType = System.Data.CommandType.Text;

                    respuesta = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                    if (respuesta < 1)
                        mensaje = "No se pudo registrar el tipo de moneda";

                }
            }
            catch (Exception ex)
            {

                respuesta = 0;
                mensaje = ex.Message;
            }

            return respuesta;
        }


        public int Editar(TipoMoneda objeto, out string mensaje)
        {
            mensaje = string.Empty;
            int respuesta = 0;
            try
            {

                using (SQLiteConnection conexion = new SQLiteConnection(Conexion.cadena))
                {

                    conexion.Open();
                    StringBuilder query = new StringBuilder();

                    query.AppendLine("update TIPO_MONEDA set Descripcion = @descripcion where IdTipoMoneda= @id;");

                    SQLiteCommand cmd = new SQLiteCommand(query.ToString(), conexion);
                    cmd.Parameters.Add(new SQLiteParameter("@id", objeto.IdTipoMoneda));
                    cmd.Parameters.Add(new SQLiteParameter("@descripcion", objeto.Descripcion));
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

                    query.AppendLine("select count(*) from ALQUILER a");
                    query.AppendLine("inner join TIPO_MONEDA tm on tm.IdTipoMoneda = a.IdTipoMoneda");
                    query.AppendLine("where tm.IdTipoMoneda = @id");

                    SQLiteCommand cmd = new SQLiteCommand(query.ToString(), conexion);
                    cmd.Parameters.Add(new SQLiteParameter("@id", id));
                    cmd.CommandType = System.Data.CommandType.Text;

                    respuesta = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                    if (respuesta == 1)
                        mensaje = "No se puede eliminar el tipo de moneda.\nEl tipo de moneda ya se encuentra asignado a un ALQULER.";

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

                    query.AppendLine("delete from TIPO_MONEDA where IdTipoMoneda= @id;");

                    SQLiteCommand cmd = new SQLiteCommand(query.ToString(), conexion);
                    cmd.Parameters.Add(new SQLiteParameter("@id", id));
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
