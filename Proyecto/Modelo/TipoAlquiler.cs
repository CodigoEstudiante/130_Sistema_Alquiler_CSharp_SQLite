using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Modelo
{
    public class TipoAlquiler
    {
        public int IdTipoAlquiler { get; set; }
        public string Descripcion { get; set; }
        public int Dias { get; set; }
        public int DefinidoSistema { get; set; }
        public int AplicaDias { get; set; }
    }
}
