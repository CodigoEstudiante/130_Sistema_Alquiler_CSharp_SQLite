using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Modelo
{
    public class Inmueble
    {
        public int IdInmueble { get; set; }
        public string Codigo { get; set; }
        public TipoInmueble oTipoInmueble { get; set; }
        public string Direccion { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
        public decimal PrecioAlquiler { get; set; }

    }
}
