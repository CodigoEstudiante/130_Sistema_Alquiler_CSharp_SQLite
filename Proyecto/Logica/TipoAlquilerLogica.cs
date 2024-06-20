using Proyecto.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Logica
{
    public class TipoAlquilerLogica
    {
        private static TipoAlquilerLogica _instancia = null;

        public TipoAlquilerLogica()
        {

        }

        public static TipoAlquilerLogica Instancia
        {

            get
            {
                if (_instancia == null) _instancia = new TipoAlquilerLogica();
                return _instancia;
            }
        }


        public List<TipoAlquiler> Listar(out string mensaje)
        {
            mensaje = string.Empty;
            List<TipoAlquiler> oLista = new List<TipoAlquiler>();

            try
            {

                using (SQLiteConnection conexion = new SQLiteConnection(Conexion.cadena))
                {
                    conexion.Open();

                    string query = "select IdTipoAlquiler,Descripcion,Dias,DefinidoSistema,AplicaDias from TIPO_ALQUILER";
                    SQLiteCommand cmd = new SQLiteCommand(query, conexion);
                    cmd.CommandType = System.Data.CommandType.Text;

                    using (SQLiteDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oLista.Add(new TipoAlquiler()
                            {
                                IdTipoAlquiler = int.Parse(dr["IdTipoAlquiler"].ToString()),
                                Descripcion = dr["Descripcion"].ToString(),
                                Dias = int.Parse(dr["Dias"].ToString()),
                                DefinidoSistema = int.Parse(dr["DefinidoSistema"].ToString()),
                                AplicaDias = int.Parse(dr["AplicaDias"].ToString()),
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                oLista = new List<TipoAlquiler>();
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

                    query.AppendLine("select count(*)[resultado] from TIPO_ALQUILER where upper(Descripcion) = upper(@descripcion) and IdTipoAlquiler != @defaultid");

                    SQLiteCommand cmd = new SQLiteCommand(query.ToString(), conexion);
                    cmd.Parameters.Add(new SQLiteParameter("@descripcion", Descripcion));
                    cmd.Parameters.Add(new SQLiteParameter("@defaultid", defaultid));
                    cmd.CommandType = System.Data.CommandType.Text;

                    respuesta = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                    if (respuesta == 1)
                        mensaje = "Ya existe el tipo de alquiler";

                }
            }
            catch (Exception ex)
            {

                respuesta = 0;
                mensaje = ex.Message;
            }

            return respuesta;
        }

        public int Guardar(TipoAlquiler objeto, out string mensaje)
        {
            mensaje = string.Empty;
            int respuesta = 0;
            try
            {

                using (SQLiteConnection conexion = new SQLiteConnection(Conexion.cadena))
                {

                    conexion.Open();
                    StringBuilder query = new StringBuilder();

                    query.AppendLine("insert into TIPO_ALQUILER(Descripcion,Dias,DefinidoSistema,AplicaDias) values (@descripcion,@dias,@definidosistema,@aplicadias);");
                    query.AppendLine("SELECT ifnull(MAX(IdTipoAlquiler),0) FROM TIPO_ALQUILER WHERE upper(Descripcion) = upper(@descripcion) ORDER BY IdTipoAlquiler DESC LIMIT 1;");

                    SQLiteCommand cmd = new SQLiteCommand(query.ToString(), conexion);
                    cmd.Parameters.Add(new SQLiteParameter("@descripcion", objeto.Descripcion));
                    cmd.Parameters.Add(new SQLiteParameter("@dias", objeto.Dias));
                    cmd.Parameters.Add(new SQLiteParameter("@definidosistema", "0"));
                    cmd.Parameters.Add(new SQLiteParameter("@aplicadias", "1"));
                    cmd.CommandType = System.Data.CommandType.Text;

                    respuesta = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                    if (respuesta < 1)
                        mensaje = "No se pudo registrar el tipo de alquiler";

                }
            }
            catch (Exception ex)
            {

                respuesta = 0;
                mensaje = ex.Message;
            }

            return respuesta;
        }


        public int Editar(TipoAlquiler objeto, out string mensaje)
        {
            mensaje = string.Empty;
            int respuesta = 0;
            try
            {

                using (SQLiteConnection conexion = new SQLiteConnection(Conexion.cadena))
                {

                    conexion.Open();
                    StringBuilder query = new StringBuilder();

                    query.AppendLine("update TIPO_ALQUILER set Descripcion = @descripcion,Dias = @dias where IdTipoAlquiler= @idtipoalquiler;");

                    SQLiteCommand cmd = new SQLiteCommand(query.ToString(), conexion);
                    cmd.Parameters.Add(new SQLiteParameter("@idtipoalquiler", objeto.IdTipoAlquiler));
                    cmd.Parameters.Add(new SQLiteParameter("@descripcion", objeto.Descripcion));
                    cmd.Parameters.Add(new SQLiteParameter("@dias", objeto.Dias));
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


        public int ValidarDefinido(int id, out string mensaje)
        {

            mensaje = string.Empty;
            int respuesta = 0;
            try
            {

                using (SQLiteConnection conexion = new SQLiteConnection(Conexion.cadena))
                {

                    conexion.Open();
                    StringBuilder query = new StringBuilder();

                    query.AppendLine("select count(*) from TIPO_ALQUILER where IdTipoAlquiler = @id and DefinidoSistema =1");

                    SQLiteCommand cmd = new SQLiteCommand(query.ToString(), conexion);
                    cmd.Parameters.Add(new SQLiteParameter("@id", id));
                    cmd.CommandType = System.Data.CommandType.Text;

                    respuesta = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                    if (respuesta == 1)
                        mensaje = "No esta permitido editar o eliminar este tipo de alquiler.\nEsta configurado internamente por el sistema.";

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
                    query.AppendLine("inner join TIPO_ALQUILER ta on ta.IdTipoAlquiler = a.IdTipoAlquiler");
                    query.AppendLine("where ta.IdTipoAlquiler = @id");

                    SQLiteCommand cmd = new SQLiteCommand(query.ToString(), conexion);
                    cmd.Parameters.Add(new SQLiteParameter("@id", id));
                    cmd.CommandType = System.Data.CommandType.Text;

                    respuesta = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                    if (respuesta == 1)
                        mensaje = "No se puede eliminar.\nEl tipo de alquiler ya se encuentra asignado a un ALQUILER.";

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

                    query.AppendLine("delete from TIPO_ALQUILER where IdTipoAlquiler= @id;");

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
