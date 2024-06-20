using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Modelo
{
    public class Alquiler
    {

        public int IdAlquiler { get; set; }
        public string CodigoAlquiler { get; set; }
        public string NombreCliente { get; set; }
        public string TipoDocumentoCliente { get; set; }
        public string DocumentoCliente { get; set; }
        public string TelefonoCliente { get; set; }
        public string CorreoCliente { get; set; }
        public string NacionalidadCliente { get; set; }
        public Inmueble oInmueble { get; set; }
        public TipoAlquiler oTipoAlquiler { get; set; }
        public TipoMoneda oTipoMoneda { get; set; }
        public int CantidadPeriodo { get; set; }
        public decimal PrecioAlquiler { get; set; }
        public string FechaInicioAlquiler { get; set; }
        public string FechaFinAlquiler { get; set; }
        public string FechaRegistro { get; set; }
        public string Clausulas { get; set; }
        public string Estado { get; set; }
    }
}
